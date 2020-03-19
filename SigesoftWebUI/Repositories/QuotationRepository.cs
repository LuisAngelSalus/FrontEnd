using BE;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using SigesoftWebUI.Utils;
using SigesoftWebUI.Utils.PDF;
using System;

using System.IO;
using System.Text;
using System.Web;
using Utils;

namespace SigesoftWebUI.Repositories
{
    public class QuotationRepository
    {
        private readonly RestClient restClient = new RestClient();


        public MemoryStream GetPDF(Response<QuotationDto> response)
        {
            MemoryStream memoryStream = new MemoryStream();
            Generator generator = new Generator();
            TextUtils textUtils = new TextUtils();

            using (Document document = new Document(PageSize.A4, 40, 40, 140, 40))
            {
                try
                {
                    PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
                    pdfWriter.CloseStream = false;
                    pdfWriter.PageEvent = new ITextEvents();

                    document.Open();

                    for (int i = 1; i <= 29; i++)
                    {
                        if (i == 1)
                        {
                            var pdfPTable = generator.GetPageOne(response);
                            document.Add(pdfPTable);
                            document.NewPage();
                        }

                        if (i == 2)
                        {
                            var elements = generator.GetPageTwo(response);
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 3)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 4)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 5)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 6)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 7)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 8)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 9)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 10)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 11)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 12)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 13)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 14)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 15)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 16)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 17)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 18)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.SetPageSize(PageSize.A4.Rotate());
                            document.NewPage();                            
                        }

                        if (i == 19)
                        {                        
                            var pdfPTable = generator.GetPageNineTeen(response);
                            document.Add(pdfPTable);
                            document.SetPageSize(PageSize.A4);
                            document.NewPage();
                        }

                        if (i == 20)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 21)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 22)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 23)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 24)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 25)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 26)
                        {
                            Paragraph elements = new Paragraph("Anexo 4. Registro como proveedor de Antamina", textUtils.fontBold12Black);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/certificado_registro.png"));
                            image.ScaleToFit(450f, 550f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(elements);
                            document.Add(image);

                            document.NewPage();
                        }

                        if (i == 27)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 28)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }

                        if (i == 29)
                        {
                            var elements = generator.GetPageTwentySix();
                            document.Add(elements);
                            document.NewPage();
                        }
                    }

                    document.Close();

                    byte[] byteInfo = memoryStream.ToArray();
                    memoryStream.Write(byteInfo, 0, byteInfo.Length);
                    memoryStream.Position = 0;

                }
                catch (Exception ex)
                {
                    ErrorUtilities.AddLog(ex);
                }
            }

            return memoryStream;
        }

        public Response<QuotationDto> GetQuotation(int quotationId, SessionModel sessionModel)
        {
            Response<QuotationDto> response = null;
            var urlClient = string.Format("Quotation/{0}", quotationId);
            var responseClient = restClient.GetAsync<Response<QuotationDto>>(urlClient, sessionModel);

            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }

            return response;
        }
    }
}