using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace MISFIT
{
    class Productivity
    {

        private double _LatestFile = 0;
        private double _last1day = 0;
        private double _last7days = 0;
        private double _last30days = 0;
        private double _last7dayAverage = 0;
        private double _last30dayAverage=0;
        private double _CurrentWorkToDo = 0;
        private string _pathToProductivityFiles=string.Empty;
        private string _fileMask = string.Empty;
        private int _CountFilesSearched = 0;

        public Productivity(string PathToProductivityFiles, string fileMask)
        {
            _pathToProductivityFiles = PathToProductivityFiles;
            _fileMask = fileMask;
        }

        public double CurrentWorkToDo
        {
            set
            {
                _CurrentWorkToDo = value;
            }
            get
            {

                return _CurrentWorkToDo;
            }
        }
        
        public double GetLastUploadValue
        {

            get
            {
                return _LatestFile;
            }

        }



        public double GetLast1DayValue
        {

            get
            {
                return _last1day;
            }

        }

        public double GetLast7DayValue
        {

            get
            {
                return _last7days;
            }

        }

        public double GetLast7DayAverage
        {

            get
            {
                return _last7dayAverage;
            }

        }


        public double GetLast30DayValue
        {

            get
            {
                return _last30days;
            }

        }


        public double GetLast30DayAverage
        {

            get
            {
                return _last30dayAverage;
            }

        }

        public string GetReportVerbose
        {
           
            get
            {
                StringBuilder sbz = new StringBuilder(4);
                sbz.AppendLine("Latest=" + _LatestFile.ToString("N2"));
                sbz.AppendLine("Last 1 day=" + _last1day.ToString("N2"));
                sbz.AppendLine("Last 7 days=" + _last7days.ToString("N2"));
                sbz.AppendLine("Last 7 day average=" + _last7dayAverage.ToString("N2"));
                sbz.AppendLine("Last 30 days=" + _last30days.ToString("N2"));
                sbz.AppendLine("Last 30 day average=" + _last30dayAverage.ToString("N2"));
                sbz.AppendLine("Count of files searched=" + _CountFilesSearched.ToString());
                
                return sbz.ToString();

            }

        }


        public string GetReportBriefTotals
        {

            get
            {
                StringBuilder sbz = new StringBuilder(4);
                sbz.Append("1d=" +_last1day.ToString("N0") + "|");
                sbz.Append("7d=" + _last7days.ToString("N0") + "|");
                sbz.Append("30d=" +_last30days.ToString("N0"));
                return sbz.ToString();

            }

        }


        public string GetReportBriefAverages
        {

            get
            {
                StringBuilder sbz = new StringBuilder(4);
                sbz.Append("1d=" + _last1day.ToString("N0") + "|");
                sbz.Append("7da=" + _last7dayAverage.ToString("N0") + "|");
                sbz.Append("30da=" + _last30dayAverage.ToString("N0"));
                // sbz.Append("30=" +_last30days.ToString("N0"));
                return sbz.ToString();

            }

        }



        public void FetchProductivityFromDisk()
        {
            Debug.WriteLine("************************ Fetching Productivity from disk.  *************************************");
            try
            {
                Dictionary<string, DateTime> FilesToProcess = new Dictionary<string, DateTime>();

                _last1day = 0;
                _last30days = 0;
                _last7days = 0;

                List<string>LastestFile = GetLatestFile(_pathToProductivityFiles, _fileMask);
                _LatestFile = CalcFiles(LastestFile);
                
                FilesToProcess = GetFileListByAge(_pathToProductivityFiles, DateTime.Now.AddDays(-30), _fileMask);  //fetch a max of 30 days worth of files

                foreach (KeyValuePair<string, DateTime> kvp in FilesToProcess)
                {
                    //Console.Write("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    double calc = Globals.CalcGhzDaysFromResultsFile(kvp.Key);

                    TimeSpan t = DateTime.Now-kvp.Value;
                   // int DaysOld=Convert.ToInt32(t.TotalDays);


                   // Debug.WriteLine(kvp.Value + " <-DAYS OLD -> " + t.TotalDays);

                    //Debug.WriteLine(kvp.Value + " <-DAYS OLD -> " + (int)t.TotalDays);


                    int DaysOld = (int)t.TotalDays;

                    if (DaysOld == 0)
                        _last1day += calc;

                    if (DaysOld >= 0 && DaysOld < 7)
                        _last7days += calc;

                     _last30days += calc;  //include everything.
                        
                }


                _last7dayAverage = _last7days / 7;
                _last30dayAverage = _last30days / 30;
                _CountFilesSearched = FilesToProcess.Count;

            }
            catch (Exception E)
            {

                throw new Exception("Exception in FetchProductivityFromDisk " + E.Message);
            }

        }


      









       


        private List<string> GetLatestFile(string PathToProductivityFiles, string fileMask)
        {
            List<string> FileNames = new List<string>();
            DirectoryInfo d = new DirectoryInfo(PathToProductivityFiles);
            FileSystemInfo[] fsi = d.GetFileSystemInfos(fileMask);
            FileInfo LatestFile = null;

            foreach (FileSystemInfo file in fsi)
            {
                if (LatestFile == null)
                {
                    LatestFile = new FileInfo(file.FullName);
                }
                else if (file.LastWriteTime > LatestFile.LastWriteTime)
                {
                    
                    LatestFile = new FileInfo(file.FullName);
                }
                else
                {
                    //Debug.WriteLine(file.Name + " is not the latest");
                }

            }

            if(LatestFile != null)
                FileNames.Add(PathToProductivityFiles +"\\" + LatestFile.Name);

            
            return FileNames;
        }



        private Dictionary<string,DateTime> GetFileListByAge(string PathToProductivityFiles, DateTime AsOfDateTime, string fileMask)
        {
            Dictionary<string, DateTime> FileNames = new Dictionary<string, DateTime>();
            DirectoryInfo d = new DirectoryInfo(PathToProductivityFiles);
            FileSystemInfo[] fsi = d.GetFileSystemInfos(fileMask);

            foreach (FileSystemInfo file in fsi)
            {
                if (file.LastWriteTime >= AsOfDateTime)
                {
                    //Debug.WriteLine("as of -> " + file.Name + " " + file.LastWriteTime.ToString());
                    FileNames.Add(file.FullName,file.LastWriteTime);

                }

            }

            return FileNames;
        }



        private double CalcFiles(List<string> FilesToCalc)
        {

            double TotalCalc = 0;

            foreach (string file in FilesToCalc)
            {
                double calc = Globals.CalcGhzDaysFromResultsFile(file);
                TotalCalc += calc;
               // Debug.WriteLine("CalcFiles for file " + file + "-> " + calc + " total so far is " + TotalCalc);
            }

            return TotalCalc;

        }
       
        

    
    }
}
