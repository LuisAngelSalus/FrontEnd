﻿using BE;
using BL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SigesoftWebUI.Controllers.Base;
using SigesoftWebUI.Repositories;
using SigesoftWebUI.Utils.PDF;
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
        private readonly QuotationRepository quotationRepository = new QuotationRepository();
        Generator generator = new Generator();
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
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.GetQuotation(id, validated.Token);

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


                    #region TOKEN
                    var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
                    LoginDto oLoginDto = new LoginDto();
                    oLoginDto.v_UserName = sessione.UserName;
                    oLoginDto.v_Password = sessione.Pass;
                    var validated = _securityBL.ValidateAccess(oLoginDto);
                    if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
                    #endregion

                    var dataQuotation = new QuotationRegisterDto()
                    {
                        InsertUserId = sessione.SystemUserId,
                        ResponsibleSystemUserId = sessione.SystemUserId,
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

                    var responseA = _quotationBL.Save(dataQuotation, validated.Token);
                    var responseB = _quotationBL.MigrateQuotationToProtocols(dataQuotationMigrate, validated.Token);
                    var responseC = _quotationBL.Update(dataQuotationUpdate, validated.Token);

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

                string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Template");
                string filePath = Path.Combine(path, data.secondNameDocument);

                string pdfPathDocument = Server.MapPath(@"~\Documents\") + data.firstNameDocument;

                mail.From = new MailAddress(Options.Email, Options.Name, Encoding.UTF8);
                mail.To.Add(data.to);
                mail.Subject = data.subject;
                mail.Body = "<html><body>" +data.body + "</html></body>";
                mail.IsBodyHtml = true;
                Attachment attachmentA;
                Attachment attachmentB;
                attachmentA = new Attachment(filePath);
                attachmentB = new Attachment(pdfPathDocument);
                mail.Attachments.Add(attachmentA);
                mail.Attachments.Add(attachmentB);

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