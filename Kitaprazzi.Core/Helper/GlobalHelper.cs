using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Core.Helper
{
    public static class GlobalHelper
    {
        public static string SMTPPort => ConfigurationManager.AppSettings["SMTPPort"];
        public static string SMTPHost => ConfigurationManager.AppSettings["SMTPHost"];
        public static string MailPassword => ConfigurationManager.AppSettings["MailPassword"];
        public static string MailAdress => ConfigurationManager.AppSettings["MailAdress"];

    }
}
