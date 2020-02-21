using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using EASendMail;
using MedalynxAPI;
using MedalynxAPI.Models;

/// <summary>
/// https://metanit.com/sharp/aspnet5/21.1.php
/// https://www.emailarchitect.net/easendmail/sdk/?ct=object_oauth
/// Created accounts:
/// medalynx@gmail.com / m1llions attached to igor.grebenev
/// 
/// {"installed":{"client_id":"182965434126-nto1llumients8gmv9p5rv519le8omkv.apps.googleusercontent.com","project_id":"medalynx-267210","auth_uri":"https://accounts.google.com/o/oauth2/auth","token_uri":"https://oauth2.googleapis.com/token","auth_provider_x509_cert_url":"https://www.googleapis.com/oauth2/v1/certs","client_secret":"iTd4oIAPSP5namuCrStwNq_p","redirect_uris":["urn:ietf:wg:oauth:2.0:oob","http://localhost"]}}
/// 
/// medalynx@yandex.ru / m1llions
/// 
/// Mailchimp medalynx / M1llions@ attached to medalynx@gmail.com
/// </summary>
namespace medalynxAPI.Notifications
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    "unknown",
                    "unknown",
                    "Mailing Service",
                    "SendEmailAsync called for: " + email
                )
            );


            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Medalynx", "medalynx@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
             
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("medalynx@yandex.ru", "m1llions");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        private static async Task<string> GetAccessToken(){
            string clientId = "182965434126-nto1llumients8gmv9p5rv519le8omkv.apps.googleusercontent.com";
            string clientSecret = "iTd4oIAPSP5namuCrStwNq_p";
            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                new[] { "email", "profile", "" },
                "user",
                CancellationToken.None
                );

            GoogleJsonWebSignature.Payload jwtPayload = GoogleJsonWebSignature.ValidateAsync(credential.Token.IdToken).Result;
            //string username = jwtPayload.Email;
            //string credential.Token.AccessToken;
            return credential.Token.AccessToken;
        }

        private static void SendMailWithXOAUTH2(string email, string subject, string textBody, string accessToken)
        {
            try
            {
                string userEmail = "medalynx@gmail.com";
                // string userPassword = "m1llions";

                SmtpServer oServer = new SmtpServer("smtp.gmail.com", 587); // 465 can be used too
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                oServer.AuthType = SmtpAuthType.XOAUTH2;
                oServer.User = userEmail;
                // use access token as password
                oServer.Password = accessToken;

                SmtpMail oMail = new SmtpMail("TryIt");
                // Your gmail email address
                oMail.From = userEmail;
                oMail.To = email;

                oMail.Subject = subject;
                oMail.TextBody = textBody;

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);
            }
            catch (Exception ep)
            {
                Console.WriteLine("Exception: {0}", ep.Message);
            }
        }

        public static async Task SendEmailOauth2Async(string email, string subject, string textBody) {
            string accessToken = await GetAccessToken();
            SendMailWithXOAUTH2(email, subject, textBody, accessToken);
        }
    }
}