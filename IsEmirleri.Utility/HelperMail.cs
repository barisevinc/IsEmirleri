using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Utility
{
    static public class HelperMail
    {
        public static async Task<bool> SendMail(string mail, string subject, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage("thisrakyazilim@gmail.com", mail, subject, message);
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("thisrakyazilim@gmail.com", "hmjetfghndyljvxm");
                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
