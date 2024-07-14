using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
namespace MISFIT
{



	public class Globals
	{
        // eg. MISFIT 2.11.1 would be 2 11 01 99 for the different version segments, 99 for a release version to preserve precedence,
        // e.g.:
        // 2.11.1-alpha   is  2 11 01 00
        // 2.11.1-alpha.1 is  2 11 01 01
        // 2.11.1-beta.3  is  2 11 01 13
        // 2.14.12        is  2 14 12 99
        // and so on and so forth

        public const string VERSION_MISFIT_STRING = "MISFIT 2.11.1-beta";
        public const int VERSION_MISFIT_INT = 2110111;   //must be 7 numbers
        private ArrayList _DaysOfWeekList = new ArrayList();
        private DateTime _MISFITstartUpTime;


        public static string GetUserAgentString()
        {
            return "MISFIT " + VERSION_MISFIT_STRING;
        }

        public static string CreateFileName(string prefix,string extension)
        {
                       
            return prefix + "_" + DateTime.Now.ToFileTimeUtc().ToString() + "_" + Guid.NewGuid().ToString().Substring(0, 8) + extension;

        }
        private static string GetUSER_GUID()
        {
            const string keyName = "USER_GUID";
            RegistryKey rkey = Registry.CurrentUser;

            string myGuid = (string)rkey.GetValue(keyName, string.Empty);
            if (myGuid == string.Empty)
            {
                myGuid = Guid.NewGuid().ToString();
                rkey.SetValue(keyName, myGuid);

            }

            return myGuid;
        }

        
        public enum REMOTE_COMMANDS
		{
			INQUIRE,
			START,
			STOP,
			KILL
		}

		public enum GIMPS_STATS_MODES
		{
			ALL,
			TF,
			LLDC
		}
        	
        public const string DIR_WEB_LOGGING = "WEB_LOGS";
        public const string FILE_DUPLICATE_WORK_REPORT = "_DUPLICATE_WORK_REPORT.CSV";
		public const string FILE_MASTER_CONFIG = "MISFITConfig.txt";
		public const string FILE_MISFIT_HELP = "MISFIT.html";
		public const string FILE_WORK_TODO = "WorkToDo.txt";
        public const string FILE_WORK_TODO_ADD = "worktodo.add";
		public const string FILE_MASTER_EXPORT_CSV = "uploaded_results.csv";
		public const string FILE_RESULTS = "Results.txt";
        //public const string FILE_RESULTS_COMBINED_PREFIX = "RESULTS_COMBINED";  <-- DROPPPED AS OF 10/24/2014
        public const string FILE_PREFIX_RESULTS_HELDBACK = "RESULTS_HELDBACK";
        public const string FILE_PREFIX_RESULTS_EXPORTED = "RESULTS_EXPORTED";
        public const string FILE_PREFIX_STALLED_PROCESS = "STALLED_PROCESS";
        public const string FILE_PREFIX_ERRORFORM = "ERROR_FORM";
        public const string PREFIX_BACKUP_FILE = "BACKUP";
        public const string FILE_MISFIT_WORK_TODO = "MISFITWorkToDo.txt";
		public const string DIR_MISFIT_BACKUPS = "MISFITbackups";
		//public const string FILE_PROGRESS_BAR = "ProgressBar.Txt";
		public const string FILE_GIMPS_STATS_CACHE_ALL = "GimpsStatsCacheAll.XML";
		public const string FILE_GIMPS_STATS_CACHE_TF = "GimpsStatsCacheTF.XML";
		public const string FILE_GIMPS_STATS_CACHE_LLDC = "GimpsStatsCacheLLDC.XML";
		public const string FILE_GIMPS_STATS_FAVORITES = "GimpsStatsFavorites.txt";
        public const string FILE_WORK_TODO_SUSPENDED = "WorkToDoSuspended.txt";
        public const string FILE_WRAPUP_BATCH = "WrapUp.Bat";
        public const string SCHEDULE_WILDCARD = "*";
		public const string PHRASE_WORKTODO_EXPONENT_ROW = "Factor=";
		public const string PHRASE_FACTOR_FOUND = "found ";
		public const string PHRASE_FACTOR_NOT_FOUND = "no factor for M";
        public const string PHRASE_FACTOR = "factor";
        public const string PHRASE_UID = "UID:";
        public const string PHRASE_DEFAULT_SCHEDULE = "Default Schedule";
		public const string APP_CTRLC_SIGNAL = "SendCtrlCode.exe";
		public const string DIR_GIOM_STAGED = "GIOM_STAGED";
		public const string DIR_GIOM_SENT = "GIOM_SENT";



        public const string URI_GIMPS_STATS_TOP_ALL = "https://www.mersenne.org/report_top_500/";
        //public const string URI_GIMPS_STATS_TOP_ALL = "https://www.mersenne.org/report_top_500/";
		public const string URI_GIMPS_STATS_TOP_TF = "https://www.mersenne.org/report_top_500_TF/";
		public const string URI_GIMPS_STATS_TOP_LLDC = "https://www.mersenne.org/report_top_500_LLD/";
		public const string URI_GIMPS_EXPONENT_HISTORY = "https://www.mersenne.org/report_exponent/?";
		public const string URI_GIMPSca_EXPONENT_HISTORY = "http://www.mersenne.ca/exponent.php?exponentdetails=";
        public const string URI_MISFIT_DOWLOADS_PAGE = "https://github.com/brubsby/MISFIT/releases";
        public const string URI_MISFIT_LIST_RELEASES_API = "https://api.github.com/repos/brubsby/MISFIT/releases";


        
		public const int MIN_WORK_BALANCE_DIFFERENCE_TRIGGER = 2;
		public const int DEFAULT_MAX_WORK_TO_ASSIGN = 1000000;
		public const int MaxCounterTimeforGIOM = 1800;
		public bool LastGIOMUploadDetectedResultsNotNeeded = false;
        public const string FILE_EXT_TXT=".txt";
        public const string FILE_EXT_HTML = ".html";
        
		public Config cfg = new Config();
		
        public Random RandomNumber = new Random(); //anyone who needs a random number



        public static int GetCountProcessRunningByName(string ProcessName)
        {
            Process[] processList = Process.GetProcessesByName(ProcessName);
            return processList.Length;
        }



        public static void CreateMisfitDirectories()
        {
            Directory.CreateDirectory(Globals.DIR_GIOM_SENT);
            Directory.CreateDirectory(Globals.DIR_GIOM_STAGED);
            Directory.CreateDirectory(Globals.DIR_MISFIT_BACKUPS);
            Directory.CreateDirectory(Globals.DIR_WEB_LOGGING);
        }


        public static bool AreMisfitDirectoriesIntact()
        {
            bool result = true;
            if (!Directory.Exists(Globals.DIR_GIOM_SENT))
                result = false;

            else if (!Directory.Exists(Globals.DIR_GIOM_STAGED))
                result = false;

            else if (!Directory.Exists(Globals.DIR_MISFIT_BACKUPS))
                result = false;


            else if (!Directory.Exists(Globals.DIR_WEB_LOGGING))
                result = false;
            return result;
        }


		public bool GlobalSendEmail(string Subject, string Body)
		{
			return Emailer.SendMail(this.cfg.settingSMTPFromAddress, this.cfg.settingSMTPRecipients, Subject, Body, this.cfg.settingSMTPServer, this.cfg.settingSMTPPort, this.cfg.settingSMTPRequiresAuthentication, this.cfg.settingSMTPUserID, this.cfg.settingSMTPPassword, this.cfg.settingSMTPUseTLS);
		}

        public enum SanitizeModes
        {
            STARTS_WITH,
            CONTAINS,
        }

        public static List<string> SanitizeListFromFile(string FilePath, string Phrase, SanitizeModes SanitizeMode)
        {
            List<string> FileLines = new List<string>();
            //List<string> SanitizedList = new List<string>();

            FileLines.AddRange(File.ReadAllLines(FilePath));


            return Globals.SanitizeList(FileLines, Phrase, SanitizeMode);
        }


        public static List<string> SanitizeList(List<string> inList, string Phrase, SanitizeModes SanitizeMode)
        {
            List<string> SanitizedList = new List<string>();

            foreach (string item in inList)
            {
                string i = item.Trim();
               
                switch (SanitizeMode)
                {
                    case SanitizeModes.STARTS_WITH:
                        if (i.StartsWith(Phrase))
                            SanitizedList.Add(i);
                        else
                            Debug.WriteLine("Unsanitary -> " + i);
                        break;
                    case SanitizeModes.CONTAINS:
                        if (i.Contains(Phrase))
                            SanitizedList.Add(i);
                        else
                            Debug.WriteLine("Unsanitary -> " + i);
                        break;
                    default:
                        Debug.WriteLine("No Mode");
                        break;

                }

                }
               

            return SanitizedList;
        }
		
		public DateTime MISFITStartupTime
		{
			set
			{
				this._MISFITstartUpTime = value;
				Debug.WriteLine("STARTUP TIME LOGGGED AS " + this._MISFITstartUpTime.ToString());
			}
			get
			{

				return this._MISFITstartUpTime;
			}
		}


        public static void ReplaceFactorLinePlaceHolderWithDate(List<string> FactorList)
        {
            for (int i = 0; i <= FactorList.Count - 1; i++)
            {
                if (FactorList[i].Length > 10)
                {
                    int EqIndex = FactorList[i].IndexOf('=') + 1;
                    int CommaIndex = FactorList[i].IndexOf(',');
                    string theMarker = FactorList[i].Substring(EqIndex, CommaIndex - EqIndex);
                    if (!theMarker.Contains("-"))   //don't change this row if we've previously inserted dashes
                    {
                        DateTime dt = DateTime.Now;
                        FactorList[i] = FactorList[i].Replace(theMarker, dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString());
                    }
                }
            }
        }


		public static void ChangeTOBitLevel(List<string> FactorList, int newBitLevel)
		{
			int CurrentBitLevel = 0;
			for (int i = 0; i <= FactorList.Count - 1; i++)
			{
				CurrentBitLevel = 0;
				if (FactorList[i].Length > 0)
				{
					string[] splitter = FactorList[i].Split(',');

					CurrentBitLevel = int.Parse(splitter[3]);
					if (CurrentBitLevel < newBitLevel)
					{
						FactorList[i] = FactorList[i].Substring(0, FactorList[i].Length - 2) + newBitLevel;//remove last two chars from end of string then add on the new factor value
					}
				}
			}

		}



        public  List<string> FetchGpu72()
        {
            List<string> AssignmentList = new List<string>();
            int WorkType = -1;
            try
            {
                WorkType = this.cfg.settingWorkFetchGPU72WorkType;

                Debug.WriteLine("Calling GPU72 with user config and worktype " + WorkType.ToString());
                AssignmentList = Gpu72.FetchWork(WorkType,this.cfg.settingWorkFetchAssignmentsToFetch, this.cfg.settingWorkFetchGPU72ExponentLow, this.cfg.settingWorkFetchGPU72ExponentHigh, this.cfg.settingWorkFetchBitLevelTo, this.cfg.settingWorkFetchGPU72Preference, this.cfg.settingGPU72UserID, this.cfg.settingGPU72Password,this.cfg.settingWorkFetchGPU72UseGHZdays);
            }
            catch (Exception E)
            {
                if (E.Message == Gpu72.PHRASE_NO_ASSIGNMENTS_AVAILABLE && this.cfg.settingWorkFetchGPU72FallBack)
                {
                    Debug.WriteLine("User Config failed, Falling back to defaults");
                    AssignmentList = Gpu72.FetchWork(WorkType, this.cfg.settingWorkFetchAssignmentsToFetch, Gpu72.EXPONENT_MIN, Gpu72.EXPONENT_MAX, Gpu72.DEFAULT_PLEDGE, (int)Gpu72.GPU72WorkOptionsLLTF.WhatMakesSense, this.cfg.settingGPU72UserID, this.cfg.settingGPU72Password,this.cfg.settingWorkFetchGPU72UseGHZdays);
                }
                else
                {
                    throw E;
                }
            }

            return AssignmentList;
        }


        public List<string> FetchGimps()
        {
            List<string> AssignmentList = new List<string>();
            Debug.WriteLine("Calling GIMPS with user config");
            AssignmentList = Gimps.FetchWork(this.cfg.settingWorkFetchAssignmentsToFetch, this.cfg.settingGIMPSUserID,this.cfg.settingGIMPSPassword);
            return AssignmentList;
        }







		public static string MISFITCRYPTO_KEY()
		{
			StringBuilder sbz = new StringBuilder();
			string GUID = GetUSER_GUID();
			for (int i = 19; i >= 0; i--)
			{
				sbz.Append(GUID[i]);
			}
			return Environment.MachineName.ToUpper() + sbz.ToString() + Environment.UserName.ToUpper();
		}

		


		public static byte[] MISFITCRYPTO_SALT()
		{
			string myGuid = GetUSER_GUID();
			byte[] bytes = new byte[myGuid.Length * sizeof(char)];
			System.Buffer.BlockCopy(myGuid.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		
		public static void LaunchHelp()
		{
			try
			{
				Process.Start(Globals.FILE_MISFIT_HELP);
			}
			catch (Exception E)
			{

				Globals.simpleMessageBox(E.Message);
			}
		}

        public static void LogWebIO(string FileNamePrefix,string Payload,string FileEXT)
        {
            Encoding fileEncoding = Encoding.ASCII;
            if (FileEXT == Globals.FILE_EXT_HTML)
                fileEncoding = Encoding.UTF8;


            File.WriteAllText(Globals.CreateFileName(Globals.DIR_WEB_LOGGING + "\\" + FileNamePrefix,FileEXT), Payload, fileEncoding );

        }

		

        public static int GetCountOfValidRowsFromFile(string fileName, string PhraseToCheck, bool RowMustStartWithPhraseToCheck)
        {

            int calculation = 0;


            List<string> fileRows = Globals.FileReadAllLinesIntoList(fileName);
            foreach (string row in fileRows)
            {
                string r = row.Trim();

                if (RowMustStartWithPhraseToCheck)
                {
                    if (r.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                    {
                        calculation += 1;
                    }
                }
                else
                {
                    if (r.Contains(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                    {
                        calculation += 1;
                    }

                }

            }
            return calculation;
        }

        public static double CalcGhzDaysFromWorkToDoFile(string fileName)
        {
            double calculation = 0;

            List<string> fileRows = Globals.FileReadAllLinesIntoList(fileName);
            foreach (string row in fileRows)
            {
                string r = row.Trim();
                if (r.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                {
                    string[] splitter = r.Split(',');

                    try
                    {
                        calculation += Globals.CalcGHDZ(Convert.ToInt32(splitter[1]), Convert.ToInt32(splitter[2]), Convert.ToInt32(splitter[3]));

                    }
                    catch
                    {
                        //continue processing;
                    }
                }

            }

            return calculation;
        }


        public static double CalcGhzDaysFromResultsFile(string fileName)
        {
            double calculation = 0;
            // Debug.WriteLine("Processing " + fileName);
            if (!File.Exists(fileName))
                throw new Exception("file " + fileName + " not found");
            List<string> fileRows = Globals.FileReadAllLinesIntoList(fileName);
            foreach (string row in fileRows)
            {

                string r = row.Trim();

                try
                {
                    //Debug.WriteLine("About to call Globals.ParseOutFactorInfoFromAResultsRow");
                    int[] values = Globals.ParseOutFactorInfoFromAResultsRow(r);
                    // Debug.WriteLine("About to call Globals.CalcGHDZ");
                    calculation += Globals.CalcGHDZ(values[0], values[1], values[2]);


                }
                catch
                {
                    //continue processing;
                }


            }

            return calculation;
        }



		public static List<T> ArrayListToGenericList<T>(ArrayList arrayList)
		{
			List<T> list = new List<T>(arrayList.Count);
			foreach (T instance in arrayList)
			{
				list.Add(instance);
			}
			return list;
		}

		public static List<string> TerminatedStringLinesToList(string stringLines)
		{

			List<string> result = new List<string>();
			using (StringReader reader = new StringReader(stringLines))
			{
				// Loop over the lines in the string.

				string line;
				while ((line = reader.ReadLine()) != null)
				{

					if (line.Length > 0)
						result.Add(line);

				}
			}

			return result;
		}
		public static string ListStringToString(List<string> list)
		{
			StringBuilder sbz = new StringBuilder();
			foreach (string s in list)
			{
				if (s.Length > 0)
					sbz.AppendLine(s);
			}

			return sbz.ToString();
		}

		public static ArrayList ArrayListAddWithDupChecking(ArrayList List, string itemToAdd)
		{
			if (List.Contains(itemToAdd))
			{
				throw new Exception("Duplicate List Item");
			}
			else
			{
				List.Add(itemToAdd);
			}
			return List;
		}

        public static List<string> ListAddWithDupChecking(List<string> Items, string itemToAdd)
        {
            if (Items.Contains(itemToAdd))
            {
                throw new Exception("Duplicate List Item");
            }
            else
            {
                Items.Add(itemToAdd);
            }
            return Items;
        }


		public static void backupFile(string sourceFile, string eventNameToPrepend)
		{
			//caller must wrap in Try/Catch

			FileInfo finfo = new FileInfo(sourceFile);

			if (finfo.Length > 0)
			{
				string fname = finfo.FullName;
				fname = fname.Replace(@"\", "-");
				fname = fname.Replace(":", "");
				string newFileName = Globals.CreateFileName(Globals.DIR_MISFIT_BACKUPS + "\\BACKUP_" + eventNameToPrepend + "_" + fname, finfo.Extension);
				finfo.CopyTo(newFileName);
				finfo = new FileInfo(newFileName);//switch to new file to set the time.
				finfo.CreationTime = DateTime.Now;
				finfo.LastWriteTime = finfo.CreationTime;
			}

		}


        public static void Sleep(int milliseconds)
        {
           //Debug.WriteLine("Sleeping for " + milliseconds.ToString());
            System.Threading.Thread.Sleep(milliseconds);
        }



		public static void simpleMessageBox(string Message)
		{

            
			MsgBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);



		}




		public static int[] ParseOutFactorInfoFromAResultsRow(string inFactorString)
		{
			int[] ParsedValues = new int[] { 0, 0, 0 };
			try
			{
				//Debug.WriteLine("evaluating:" + inFactorString);
				if (inFactorString.Contains(Globals.PHRASE_FACTOR_NOT_FOUND))
				{
					//Debug.WriteLine("OKnotFound!" + inFactorString);
					int idxOfStart = inFactorString.IndexOf(Globals.PHRASE_FACTOR_NOT_FOUND);
					inFactorString = inFactorString.Substring(idxOfStart);
					//Debug.WriteLine("converted to:" + inFactorString);
					string[] splitter = inFactorString.Split(' ');
                   // Debug.WriteLine("Parsed out values " + splitter[3] + "," + splitter[5] + "," + splitter[7]);
					ParsedValues[0] = Convert.ToInt32(splitter[3].Substring(1));
					ParsedValues[1] = Convert.ToInt32(splitter[5].Substring(2));
					ParsedValues[2] = Convert.ToInt32(splitter[7].Substring(2));
				}
                else if (inFactorString.Contains(Globals.PHRASE_FACTOR_FOUND))
                {
                    //Debug.WriteLine("****OKfound!" + inFactorString);
                    int idxOfStart = inFactorString.IndexOf(Globals.PHRASE_FACTOR_FOUND);
                    inFactorString = inFactorString.Substring(idxOfStart);
                    //Debug.WriteLine("converted to:" + inFactorString);
                    string[] splitter = inFactorString.Split(' ');
                  //  Debug.WriteLine("Parsed out values " + splitter[4] + "," + splitter[6] + "," + splitter[8]);
                    ParsedValues[0] = Convert.ToInt32(splitter[4].Substring(1));
                    ParsedValues[1] = Convert.ToInt32(splitter[6].Substring(2));
                    ParsedValues[2] = Convert.ToInt32(splitter[8].Substring(2));

                }
                else
                {
                    //Debug.WriteLine("bogus string -> " + inFactorString);
                }

			}
			catch (Exception E)
			{

				throw new Exception("Error parsing " + inFactorString  +" for calculation of GHZdays\r\n" + E.Message);
			}
			return ParsedValues;
		}






		public static double CalcGHDZ(int exp, int from, int to)
		{
            //double GHZdays = 0;

            //for (int i = from + 1; i <= to; i++)
            //{
            //    GHZdays += (0.00707 * 2.4) * (Math.Pow(2, i - 48)) * 1680 / exp;
            //}
            //return GHZdays;
            double calc=0;

            if(exp> 0 && from > 0 && to > 0)
                calc=28.50624 * (Math.Pow(2, to - 47) - Math.Pow(2, from - 47)) / exp;

           // Debug.WriteLine("CalcGHDZ calculated-> " + calc.ToString());
            
            return calc;
		}


		public static List<string> FileReadAllLinesIntoList(string fileName)
		{

			List<string> FileLines = new List<string>();
			

			if (File.Exists(fileName))
			{
				try
				{
					
                    
					FileLines.AddRange(File.ReadAllLines(fileName));
					
				}
				catch (Exception e)
				{
					throw e;
				}
				
			}
			return FileLines;
		}

		public static void FileAppend_ListToFile(string fileName, List<string> ListToWrite)
		{
			try
			{
				
				File.AppendAllLines(fileName, ListToWrite);
				
			}
			catch (Exception e)
			{
				throw e;
			}
			
		}


        public static void FileReplace_ListToFile(string fileName, List<string> ListToWrite)
        {

           
            try
            {
                
                File.WriteAllLines(fileName, ListToWrite);
                
            }
            catch (Exception e)
            {
                throw e;
            }
           

        }

        public static void SplitFileContentBetweenFiles(string WorkingDirectory,string SourceFile, string SecondFile, int SplitFileAtLineNumber)
        {
            List<string> SourceLines = new List<string>();
            List<string> LinesFile1 = new List<string>();
            List<string> LinesFile2 = new List<string>();
            ArrayList FilesToLockList = new ArrayList();
           
            int GoodRowCounter = 0;
            string File1Name = string.Empty;
            string File2Name = string.Empty;

            try
            {
                File1Name = WorkingDirectory + "\\" + SourceFile;
                File2Name = WorkingDirectory + "\\" + SecondFile;
                FilesToLockList.Add(SourceFile);
                FilesToLockList.Add(SecondFile);
                               SourceLines.AddRange(File.ReadAllLines(File1Name));
                 for (int x = 0; x < SourceLines.Count; x++)
                    {

                        if (SourceLines[x].StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                        {

                            if (GoodRowCounter < SplitFileAtLineNumber)
                                LinesFile1.Add(SourceLines[x]);
                            else
                                LinesFile2.Add(SourceLines[x]);

                            GoodRowCounter++;
                        }
                        else
                        {
                            Debug.WriteLine("Skipping invalid row");
                        }

                    }
                    Debug.WriteLine("SplitFileContentBetweenFiles is writing out files");
                    if (GoodRowCounter > 0)  // don't mess witht the files if there was no valid data moved around.
                    {

                        if (File.Exists(File1Name))
                            backupFile(File1Name, "FILESPLITTER");

                        if (File.Exists(File2Name))
                            backupFile(File2Name, "FILESPLITTER");

                        if (LinesFile1.Count > 0)
                        {
                            File.WriteAllLines(File1Name, LinesFile1);
                        }
                        else
                        {
                            File.Delete(File1Name);
                        }


                        if (LinesFile2.Count > 0)
                        {
                            File.WriteAllLines(File2Name, LinesFile2);
                        }
                        else
                        {
                            File.Delete(File2Name);
                        }
                    }

                   
            }
            catch (Exception E)
            {
                throw E;
            }
                   
            



        }


	}
}
