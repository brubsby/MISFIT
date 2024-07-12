using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Diagnostics;

namespace MISFIT
{
    class RemoteControl
    {
        
        public static string SendCommand(string server, string command)
        {
            const string NameOfPipe = "MISFIT";
            const string IdentityPhrase = "MISFIT-REMOTE-1.2.5";
            const int connectionTimeout = 5000;
            //string command_to_send=string.Empty;
            string server_response = string.Empty;

            NamedPipeClientStream pipeClient = new NamedPipeClientStream(server, NameOfPipe, PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            StreamWriter sw = new StreamWriter(pipeClient);
            StreamReader sr = new StreamReader(pipeClient);

            try
            {
                pipeClient.Connect(connectionTimeout);
                sw.AutoFlush = true;

                //if (sr.ReadLine().Length < 1)
                //    throw new Exception("Server did not respond with a valid server name confirmation");

                if (sr.ReadLine() != IdentityPhrase)
                    throw new Exception("MISFITServer is not the correct version");

               

                Debug.WriteLine("SENDING: " + command);
                sw.WriteLine(command);
                Debug.WriteLine("RESPONSE:");
                server_response = sr.ReadLine();
                


            }
            catch (Exception E)
            {

                throw E;
            }
            finally
            {
                pipeClient.Close();
            }



            return server_response;
        }
    
    }
}
