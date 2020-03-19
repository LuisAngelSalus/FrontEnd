using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils;

namespace SigesoftWebUI.Controllers
{
    public class EmailController : GenericController
    {
        EmailBL _emailBL = new EmailBL();
        private SmtpClient Cliente { get; }
        private EmailSenderOptions Options { get; }
        QuotationBL _quotationBL = new QuotationBL();
        SecurityBL _securityBL = new SecurityBL();
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

        public ActionResult Index(int id)
        {
           

            var response = _quotationBL.GetQuotation(id, SessionUsuario.Token);

            var data = new EmailDto()
            {
                quotationStatusId = Convert.ToInt32(StateQuotation.Aceptada),
                quotationId = id,
                to = response.Data.Email
            };


            return View(data);
        }

        [HttpPost]
        public ActionResult Index(EmailDto data, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {

                using (MailMessage mail = new MailMessage(Options.Email, data.to))
                {
                    if (!string.IsNullOrEmpty(data.cc))
                    {
                        mail.CC.Add(data.cc);
                    }
                    mail.Subject = data.subject;
                    mail.Body = data.body;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = Options.Host;
                    smtp.EnableSsl = Options.EnableSsl;
                    NetworkCredential networkCredential = new NetworkCredential(Options.Email, Options.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = Options.Port;
                    smtp.Send(mail);


                    var dataQuotation = new QuotationRegisterDto()
                    {
                        InsertUserId = SessionUsuario.SystemUserId,
                        ResponsibleSystemUserId = SessionUsuario.SystemUserId,
                        QuotationId = data.quotationId,
                        StatusQuotationId = StateQuotation.Aceptada
                    };

                    var dataQuotationMigrate = new QuotationMigrateDto()
                    {
                        QuotationId = data.quotationId
                    };

                    var dataQuotationUpdate = new QuotationUpdateDto()
                    {
                        QuotationId = data.quotationId,
                        StatusQuotationId = Convert.ToInt32(StateQuotation.Aceptada)
                    };

                    var responseA= _quotationBL.Save(dataQuotation, SessionUsuario.Token);
                    var responseB= _quotationBL.MigrateQuotationToProtocols(dataQuotationMigrate, SessionUsuario.Token);
                    var responseC = _quotationBL.Update(dataQuotationUpdate, SessionUsuario.Token);

                    return RedirectToAction("Index", "Quotation");

                }
            }
            else
            {
                return View();
            }
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