using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace MISFIT
{
    public static class Emailer
    {

        public static bool SendMail(string FromAddress, string ToAddress, string Subject, string Body, string Server, int Port, bool ForceAuthentication,string SMTPUserID, string SMTPUserPassword, bool useTLS)
        {
            bool result = false;

            MailMessage Message = new MailMessage(FromAddress.Trim(), ToAddress.Trim(), Subject.Trim(), Body.Trim()+"\r\n\r\n\r\nSent by " + Globals.VERSION_MISFIT_STRING + " from computer " + Environment.MachineName + " at " + DateTime.Now.ToString());

            SmtpClient client = new SmtpClient(Server, Port);
            if (ForceAuthentication)
            {
                client.EnableSsl = useTLS;

                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(SMTPUserID, SMTPUserPassword);
            }
            Debug.WriteLine("Sending the actual email now");
            client.Send(Message);
            Debug.WriteLine("Send Complete");
            return result;    
        }
    
    
    }
}
