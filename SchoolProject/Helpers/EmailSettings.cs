using SchoolProject.Models;
using System.Net;
using System.Net.Mail;

namespace SchoolProject.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.sendgrid.net", 587);
            client.EnableSsl = true; //Encrypted
            client.Credentials = new NetworkCredential("apikey", "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");
            client.Send("alyabo403@gmail.com", email.To, email.Title, email.Body);
        }
    }
}
