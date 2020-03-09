using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class EmailController : GenericController
    {
        EmailBL _emailBL = new EmailBL();
        private SmtpClient Cliente { get; }
        private EmailSenderOptions Options { get; }
        public EmailController()
        {
            Options = new EmailSenderOptions()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Password = "Aloha2019",
                Email = "luis.delacruz@saluslaboris.com.pe",
                Name = "Luis de la cruz",
                EnableSsl = true,
            };
        }
        public JsonResult SendMail(EmailDto data)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Options.Host);

                string path = Path.Combine(HttpRuntime.AppDomainAppPath, "File");
                string fileName = "PLANTILLA_PROPUESTA_COMERCIAL.docx";
                string filePath = Path.Combine(path, fileName);

                mail.From = new MailAddress(Options.Email, Options.Name, Encoding.UTF8);
                mail.To.Add(data.to);
                mail.Subject = data.subject;
                mail.Body = data.body;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = Options.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Options.Email, Options.Password);

                SmtpServer.EnableSsl = Options.EnableSsl;

                SmtpServer.Send(mail);

                var response = "ok";

                return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}