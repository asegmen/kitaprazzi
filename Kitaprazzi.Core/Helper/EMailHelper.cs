using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Core.Helper
{
    public class EMailHelper
    { 
        public static void SendMail(string toMail, string displayName, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toMail);
            mail.From = new MailAddress("admin@kitaprazzi.com.tr", displayName);
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GlobalHelper.SMTPHost;
            smtp.Port = Convert.ToInt16(GlobalHelper.SMTPPort);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(GlobalHelper.MailAdress, GlobalHelper.MailPassword);
            smtp.Send(mail);
        }
    }
}
