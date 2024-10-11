using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Utility
{
    public static class HelperProjectMail
    {
        public static async Task<bool> SendProjectAssignedMailAsync(string mail, string projeTitle)
        {
            try
            {
                string subject = "Size yeni bir proje ataması yapıldı!";
                string message = $"Merhaba Değerli Çalışanımız,<br><br>Size yeni bir proje ataması yapıldı: <b>{projeTitle}</b>.<br>Ayrıntıları görmek için lütfen sisteme bakın.<br><br>İyi çalışmalar.";

                MailMessage mailMessage = new MailMessage("testyazilim6868@gmail.com", mail, subject, message);
                mailMessage.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("testyazilim6868@gmail.com", "dzjv xsya fbpy svpv");

                    await smtpClient.SendMailAsync(mailMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
