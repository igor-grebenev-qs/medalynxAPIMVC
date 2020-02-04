using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

/// <summary>
/// https://docs.microsoft.com/ru-ru/dotnet/api/system.net.mail.smtpclient?view=netframework-4.8
/// </summary>
namespace medalynxAPIMVC.Notifications
{
    public class AsynchronousMail
    {
        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string) e.UserState;
           
            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }

            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }

        public static void SendMain(string SMTPhost, string addrTo, string subjectUFT8, string bodyUTF8)
        {
            SmtpClient client = new SmtpClient(SMTPhost);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("username", "password");
            
            // Create a mailing address that includes a UTF8 character in the display name.
            MailAddress from = new MailAddress("igor.grebenev@quantumsoft.ru", "Medalynx", System.Text.Encoding.UTF8);

            MailAddress to = new MailAddress(addrTo);
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = bodyUTF8;
            message.BodyEncoding =  System.Text.Encoding.UTF8;
            message.Subject = subjectUFT8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback method to identify this send operation.
            // Now userToken is a string constant.
            string userState = "medalynx message";
            client.SendAsync(message, userState);

            string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
            }
            // Clean up.
            message.Dispose();
        }
    }
}