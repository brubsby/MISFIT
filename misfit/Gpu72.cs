using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISFIT
{
    static class Gpu72
    {

                    
        

        public enum GPU72WorkOptionsLLTF
        {
            WhatMakesSense = 0,
            LowestTFLevel = 1,
            HighestTFLevel = 2,
            LowestExponent = 3,
            OldestExponent = 4,
            LetGPU72Decide=9
        }


        public enum GPU72WorkOptionsDCTF
        {
            WhatMakesSense = 0,
            LowestTFLevel = 1,
            HighestTFLevel = 2,
            LowestExponent = 3,
            OldestExponent = 4,
            NoP1Done = 5,
            LetGPU72Decide = 9
        }

        public enum GPU72WorkTypes
        {
            LLTF,
            DCTF
        }

        public const int EXPONENT_MIN = 0;
        public const int EXPONENT_MAX = 100000000;
        public const int DEFAULT_PLEDGE = 71;
        public const string URI_GPU72LLTF = "https://www.gpu72.com/account/getassignments/lltf/";
        public const string URI_GPU72DCTF = "https://www.gpu72.com/account/getassignments/dctf/";

        public const string PHRASE_NO_ASSIGNMENTS_AVAILABLE = "No assignments available which match your criteria";//do not change!
        public const string PHRASE_TOO_MUCH_WORK = "Too much work!";
        public const string ERROR_BAD_PAYLOAD = "HTML payload is unusable for finding Factor rows. See HTML fetch log for more information.";
        public const string ERROR_NO_ASSIGNMENTS_PARSED = "HTML payload seemed OK, but turned out to be unusable. See HTML fetch log for more information.";
        public const string PHRASE_HEALTHY_PAYLOAD = "There is no need to report them here -- the system will automatically detect when the work has been completed";

        public static List<string> FetchWork(int workType, int number, int low, int high, int pledge, int option, string userid,string password,int GhDz)
        {
            string response = string.Empty;
            string url = string.Empty;
            List<string> AssignmentList = new List<string>();

            switch(workType)
            {
                case (int)GPU72WorkTypes.LLTF:
                    url = URI_GPU72LLTF;
                    break;
                case (int)GPU72WorkTypes.DCTF:
                    url = URI_GPU72DCTF;
                    break;

            }

            WebIO webIO = new WebIO();
            response = webIO.GetWorkGPUto72(url,number, low, high, pledge, option, userid, password,GhDz);
            Globals.LogWebIO("GPU72FETCH", response, Globals.FILE_EXT_HTML);
            if (response.Length > 0)
            {

                response = ParseFactorsFromHTML(response);
                Globals.LogWebIO("GPU72ASSIGNMENTS", response, Globals.FILE_EXT_TXT);
                AssignmentList = Globals.TerminatedStringLinesToList(response);
            }
            


            if(AssignmentList.Count==0)
                throw new Exception("GPU72 fetch produced NO work: reason unknown!");

            return AssignmentList;

        }

        private static string ParseFactorsFromHTML(string html)
        {
            const string MarkerBeginText = "Factor=N/A,";  //factors will be inside this block
            const string MarkerEndText = "</pre>";
            int MarkerBeginIndex = -100;
            int MarkerEndIndex = -100;
            StringBuilder Factors = new StringBuilder();

            if (html.Contains(Gpu72.PHRASE_NO_ASSIGNMENTS_AVAILABLE))
                throw new Exception(Gpu72.PHRASE_NO_ASSIGNMENTS_AVAILABLE);

            if (html.Contains(Gpu72.PHRASE_TOO_MUCH_WORK))
                throw new Exception(Gpu72.PHRASE_TOO_MUCH_WORK);
         

            if (!html.Contains(Gpu72.PHRASE_HEALTHY_PAYLOAD))
                throw new Exception(ERROR_BAD_PAYLOAD);

                try
                {
                    MarkerBeginIndex = html.IndexOf(MarkerBeginText);
                    MarkerEndIndex = html.IndexOf(MarkerEndText, MarkerBeginIndex);
                    Factors.Append(html.Substring(MarkerBeginIndex, MarkerEndIndex - MarkerBeginIndex));
                    Factors.Replace("\n", "\r\n");  //remove the unix style terminator and add a windows CRLF terminator

                }
                catch
                {
                    throw new Exception(ERROR_NO_ASSIGNMENTS_PARSED);
                }


                if (!Factors.ToString().StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW)) //quality check
                    throw new Exception(ERROR_NO_ASSIGNMENTS_PARSED);  //failsafe exceptioon

            return Factors.ToString();
        }
        
    
    
    
    }
}
