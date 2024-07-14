using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MISFIT
{
   static class Gimps
    {


        public const string ERROR_LOGIN_FAILED = "Login to GIMPS failed!";
        //public const string URI_GIMPSWORK = "http://www.mersenne.org/manual_assignment/";
        public const string ERROR_NO_ASSIGNMENTS_PARSED = "HTML payload was unusable. See web log for details";


        private static bool LoginGimps(string userid, string password, WebIO myWebIO)
        {
            string response = myWebIO.LoginGIMPS(userid, password);
            Globals.LogWebIO("GIMPSLOGINFETCH", response, Globals.FILE_EXT_HTML);

            if (response.ToUpper().Contains(userid.ToUpper() + " SUMMARY"))
            {
                return true;
            }
            else
            {
                //you can get a page without any indication of an actual login failure so if login test failed it is an exception.
                throw new Exception(Gimps.ERROR_LOGIN_FAILED);
            }

        }

        
        public static List<string> FetchWork(int number, string userid, string password)
        {
            string response = string.Empty;
            List<string> AssignmentList = new List<string>();
            WebIO myWebIO = new WebIO();
            Gimps.LoginGimps(userid, password, myWebIO);
            response = myWebIO.GetWorkGIMPS(number, null, WebIO.GIMPSWorkPreference.WhatMakesSense, null, null, WebIO.GIMPSWorkPreference2.WhatMakesSense, null);
            Debug.WriteLine(response);
            Globals.LogWebIO("GIMPSASSIGNMENTSFETCH", response, Globals.FILE_EXT_TXT);

                if (response.Length > 0)
                {
                    response = ParseFactorsFromHTML(response);
                    Globals.LogWebIO("GIMPSASSIGNMENTSPARSED", response, Globals.FILE_EXT_TXT);
                    AssignmentList = Globals.TerminatedStringLinesToList(response);
                }


                if (AssignmentList.Count == 0)
                    throw new Exception("GIMPS fetch produced NO work: reason unknown!");

            return AssignmentList;

        }


        private static string ParseFactorsFromHTML(string html)
        {
            const string BeginBlockMarker = "<!--BEGIN_ASSIGNMENTS_BLOCK-->";
            const string EndBlockMarker = "<!--END_ASSIGNMENTS_BLOCK-->";
            //const string UserValidationPhrase = "PROCESSING_VALIDATION:ASSIGNED TO ";

            if (html.Contains(BeginBlockMarker) && html.Contains(EndBlockMarker) && html.Contains(Globals.PHRASE_WORKTODO_EXPONENT_ROW) /*&& html.Contains(UserValidationPhrase)*/)
            {
                int startIndex = html.IndexOf(BeginBlockMarker) + BeginBlockMarker.Length;
                int endIndex = html.IndexOf(EndBlockMarker);
                html = html.Substring(startIndex, endIndex - startIndex);
                html = html.Trim();
                html = html.Replace("\n", "\r\n"); //remove the unix style terminator and add a windows CRLF terminator
                Debug.WriteLine("new factors html " + html);
            }
            else
            {
                throw new Exception(ERROR_NO_ASSIGNMENTS_PARSED);

            }

            return html;

        }














        
           
      
    }
}
