using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MISFIT
{
  public class WebIO
    {
        private string _userName;
		private string _password;
		
		private CookieContainer _cookieJar;

        public enum GIMPSWorkPreference
        {
            WhatMakesSense = 1,
            TFForDoubleChecks = 2,
            TFForFTC = 3,
            TFFor100M = 4
        }

        public enum GIMPSWorkPreference2
        {
            WhatMakesSense = 1,
            LowestBitLevels = 2,
            HighestBitLevels = 3,
            LowestExponents = 4,
            HighestExponents = 5
        }



        private void SetBasicAuthHeader(HttpWebRequest req, string userid, string password)
        {
            //used when calling GPU72
            string authInfo = userid + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " + authInfo;
        }

        public string GetWorkGPUto72(string url, int number, int low, int high, int pledge, int option, string userid, string password,int GhDz)
        {
            string postData;
             _cookieJar = new CookieContainer();
            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(url);
            web.CookieContainer = _cookieJar;
            web.Method = WebRequestMethods.Http.Post;
            web.ContentType = "application/x-www-form-urlencoded";
            web.Accept = "text/html, application/xhtml+xml, */*";
            web.UserAgent = Globals.GetUserAgentString();
            web.Headers.Add("Accept-Language: en-US");
       
            SetBasicAuthHeader(web,userid,password);

            postData = string.Format("Number={0}&Low={1}&High={2}&Pledge={3}&Option={4}&GHzDays={5}",
                number, low, high, pledge, option,GhDz);

            web.ContentLength = postData.Length;

            using (Stream requestStream = web.GetRequestStream())
            {
                StreamWriter reqWriter = new StreamWriter(requestStream);
                reqWriter.Write(postData.ToString());
                reqWriter.Flush();
            }

            // Read the response
            using (StreamReader responseStream = new StreamReader(web.GetResponse().GetResponseStream()))
            {
                return responseStream.ReadToEnd();
            }
        }

		private string PerformGetWithCookies(string url)
		{
            Debug.WriteLine("Connecting to " + url);
            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(url);
            web.UserAgent = Globals.GetUserAgentString();

            // By using the "private _cookieJar", the cookies are saved inbetween web requests, thereby saving our session.
            web.CookieContainer = _cookieJar;

			WebResponse response = web.GetResponse();

			using (StreamReader sr = new StreamReader(response.GetResponseStream()))
			{
                return sr.ReadToEnd();
			}
		}



        public static string PerformGetWithNOCookies(string url)
        {

            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(url);
            web.UserAgent = Globals.GetUserAgentString();

            // By using the "private _cookieJar", the cookies are saved inbetween web requests, thereby saving our session.
            WebResponse response = web.GetResponse();

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }



		public string LoginGIMPS(string userName, string password)
		{
			_userName = userName;
			_password = password;

            string url = "https://www.mersenne.org/account/?user_login=" + _userName + "&user_password=" + _password;
            string postData;
            _cookieJar = new CookieContainer();

            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(url);
            web.CookieContainer = _cookieJar;
            web.Method = WebRequestMethods.Http.Post;
            web.ContentType = "application/x-www-form-urlencoded";
            web.Accept = "text/html, application/xhtml+xml, */*";
            web.UserAgent = Globals.GetUserAgentString();
            web.Headers.Add("Accept-Language: en-US");
            
            postData = string.Format("user_login={0}&user_password={1}", userName, password);

            web.ContentLength = postData.Length;

            using (Stream requestStream = web.GetRequestStream())
            {
                StreamWriter reqWriter = new StreamWriter(requestStream);
                reqWriter.Write(postData.ToString());
                reqWriter.Flush();
            }

            // Read the response
            using (StreamReader responseStream = new StreamReader(web.GetResponse().GetResponseStream()))
            {
                return responseStream.ReadToEnd();
            }
        }





        public string GetWorkGIMPS(int? assignments, int? assignmentsGHZ, GIMPSWorkPreference workPref, int? expStart, int? expEnd, GIMPSWorkPreference2 workPref2, int? factorTo)
        {
            string url = "https://www.mersenne.org/manual_gpu_assignment/?" +
                  "&num_to_get=" + assignments +
                  "&ghz_to_get=" + assignmentsGHZ +
                  "&pref=" + (int)workPref +
                  "&exp_lo=" + expStart +
                  "&exp_hi=" + expEnd +
                  "&pref2=" + (int)workPref2 +
                  "&factor_to=" + factorTo +
                  "&B1=1";

            Debug.WriteLine(url);


            return PerformGetWithCookies(url);
        }



        public static string UploadResultsFileToGIMPS(string fullFilename, string userID)
        {
            //in 2014 we'll call  //www.mersenne.org/manual_result/misfit.php?uid=swl551

            FileInfo fi = new FileInfo(fullFilename);

            StringBuilder postData = new StringBuilder();

            //string url = "https://www.mersenne.org/manual_result/misfit.php?uid=" + userID +"&user_password="+password;
            string url = "https://www.mersenne.org/manual_result/misfit.php?uid=" + userID;
            Debug.WriteLine(url);

            string boundary = "------------------------" + DateTime.Now.Ticks;
            string newLine = Environment.NewLine;

            string propFormat = "--" + boundary + newLine +
                   "Content-Disposition: form-data; name=\"{0}\"" + newLine + newLine +
                    "{1}" + newLine;

            string fileHeaderFormat = "--" + boundary + newLine +
                        "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + newLine;

            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(url);
            // web.CookieContainer = _cookieJar;
            web.Method = WebRequestMethods.Http.Post;
            web.ContentType = "multipart/form-data; boundary=" + boundary;
            web.Accept = "text/html, application/xhtml+xml, */*";
            web.UserAgent = Globals.GetUserAgentString();


            postData.Append(string.Format(propFormat, "MAX_FILE_SIZE%22", "1000000"));
            postData.Append(string.Format(fileHeaderFormat, "file", fi.Name));
            postData.Append("Content-Type: text/plain" + newLine + newLine);
            postData.Append(File.ReadAllText(fullFilename) + newLine);
            postData.Append(string.Format(propFormat, "B2", "Upload"));
            postData.Append("--" + boundary + "--" + newLine);

            web.ContentLength = postData.Length;

            using (Stream requestStream = web.GetRequestStream())
            {
                StreamWriter reqWriter = new StreamWriter(requestStream);
                reqWriter.Write(postData.ToString());
                reqWriter.Flush();
            }

            // Read the response
            using (StreamReader responseStream = new StreamReader(web.GetResponse().GetResponseStream()))
            {
                return responseStream.ReadToEnd().ToUpper();
            }
        }


		
    }
}
