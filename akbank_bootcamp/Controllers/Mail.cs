using System.Net;
using System.Net.Mail;

namespace akbank_bootcamp.Controllers
{
    public class Mail
    {
        public void sendMail()
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;

                string kime = "nurhayatktnn8@gmail.com";
                string konu = "cc";
                string icerik = "vvvvvv";

                sc.Credentials = new NetworkCredential("nurhayatktnn8@gmail.com", "Ak53*c3a");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("posta@gmail.com", "Patika.dev");
                mail.To.Add(kime);
          
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.UseDefaultCredentials = true;
                sc.Send(mail);
            }
            catch (Exception exc)
            {

            }
        }
    }
}
