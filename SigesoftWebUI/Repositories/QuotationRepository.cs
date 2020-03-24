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
                            PdfPTable table = new PdfPTable(3);
                            table.WidthPercentage = 85;

                            PdfPCell header = new PdfPCell(new Phrase("CONTENIDO", textUtils.fontBold16Black));
                            header.Colspan = 3;
                            header.HorizontalAlignment = Element.ALIGN_CENTER;
                            header.Border = 0;
                            table.AddCell(header);

                            //PdfPCell cell = new PdfPCell(new Phrase("CONTENIDO"));

                            //cell.Colspan = 3;

                            //cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                            //table.AddCell(cell);

                            //table.AddCell("");

                            //table.AddCell("");

                            //table.AddCell("");

                            //table.AddCell("A");

                            //table.AddCell("PRESENTACIÓN DE LA EMPRESA");

                            //table.AddCell("4");

                            //cell.Border = 0;

                            document.Add(table);
                            document.NewPage();
                        }

                        if (i == 4)
                        {
                            Phrase phraseOne = new Phrase("A. PRESENTACIÓN DE LA EMPRESA", textUtils.fontBold12White);

                            PdfPTable pdfPTable = new PdfPTable(1);
                            pdfPTable.WidthPercentage = 100;

                            Paragraph paragraphOne = new Paragraph(phraseOne);
                            PdfPCell pdfPCellOne = new PdfPCell(paragraphOne);
                            pdfPCellOne.HorizontalAlignment = Element.ALIGN_MIDDLE;
                            pdfPCellOne.BackgroundColor = textUtils.BaseColor;
                            pdfPCellOne.Border = PdfPCell.NO_BORDER;

                            pdfPTable.AddCell(pdfPCellOne);

                            Chunk chunkOne = new Chunk("\n1. QUIENES SOMOS\n\n", textUtils.fontBold11Sky);
                            Chunk chunkTwo = new Chunk("Somos una empresa especializada en servicios Salud Ocupacional y Respuesta a Emergencias, con más de 12 años en el mercado. Contamos con divisiones de negocio especializadas propias que cubren todas las especialidades de salud ocupacional.\n\n\n\n", textUtils.font11Black);
                            Chunk chunkThree = new Chunk("Divisiones de negocio:\n\n\n\n", textUtils.fontBold11Black);

                            Phrase phrase = new Phrase();
                            phrase.Add(chunkOne);
                            phrase.Add(chunkTwo);
                            phrase.Add(chunkThree);

                            Paragraph elements = new Paragraph();
                            elements.Add(phrase);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/presentacion_a.png"));
                            image.ScaleToFit(350f, 250f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(pdfPTable);
                            document.Add(elements);
                            document.Add(image);
                            document.NewPage();
                        }

                        if (i == 5)
                        {
                            Chunk chunkOne = new Chunk("2.NUESTRO EQUIPO DE TRABAJO\n\n", textUtils.fontBold11Sky);
                            Chunk chunkTwo = new Chunk("Salus Laboris cuenta con un gran equipo multidisciplinario que pertenece a nuestro staff, el cual nos permite generar sinergia y asistencia cruzada permanente, que nos da un valor agregado en los servicios que brindamos.\n\n\n", textUtils.font11Black);
                            Chunk chunkThree = new Chunk("El nivel profesional de nuestro equipo se complementa con formación técnica específica como:\n\n\n", textUtils.font11Black);

                            Phrase phraseA = new Phrase();
                            phraseA.Add(chunkOne);
                            phraseA.Add(chunkTwo);

                            Phrase phraseB = new Phrase();
                            phraseB.Add(chunkThree);

                            Paragraph elementsA = new Paragraph();
                            elementsA.Add(phraseA);
                            elementsA.Alignment = Element.ALIGN_JUSTIFIED;

                            Paragraph elementsB = new Paragraph();
                            elementsB.Add(phraseB);
                            elementsB.Alignment = Element.ALIGN_JUSTIFIED;

                            Image imageA = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/equipo_trabajo.png"));
                            imageA.ScaleToFit(350f, 250f);
                            imageA.Alignment = Image.ALIGN_CENTER;
                            imageA.PaddingTop = 20f;

                            Image imageB = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/equipo_trabajo_b.png"));
                            imageB.ScaleToFit(350f, 250f);
                            imageB.Alignment = Image.ALIGN_CENTER;
                            imageB.PaddingTop = 20f;

                            document.Add(elementsA);
                            document.Add(imageA);
                            document.Add(elementsB);
                            document.Add(imageB);
                            document.NewPage();
                        }

                        if (i == 6)
                        {
                            Chunk chunkOne = new Chunk("3.NUESTRA EXPERIENCIA\n\n", textUtils.fontBold11Sky);

                            Phrase phrase = new Phrase();
                            phrase.Add(chunkOne);

                            Paragraph elements = new Paragraph();
                            elements.Add(phrase);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/experiencia.png"));
                            image.ScaleToFit(450f, 350f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(elements);
                            document.Add(image);
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
                            Paragraph elements = new Paragraph("Anexo 1. Acreditación como establecimiento de Salud I-3, MINSA.", textUtils.fontBold12Black);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/acreditacion_minsa.png"));
                            image.ScaleToFit(450f, 550f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(elements);
                            document.Add(image);

                            document.NewPage();
                        }

                        if (i == 22)
                        {
                            Paragraph elements = new Paragraph("Anexo 2. Acreditación DIGESA como Centro de Salud Ocupacional.", textUtils.fontBold12Black);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/acreditacion_digesa.png"));
                            image.ScaleToFit(450f, 550f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(elements);
                            document.Add(image);

                            document.NewPage();
                        }

                        if (i == 23)
                        {
                            Paragraph elements = new Paragraph("Extensión Acreditación DIGESA 2019", textUtils.fontBold12Black);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/acreditacion.png"));
                            image.ScaleToFit(450f, 550f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(elements);
                            document.Add(image);

                            document.NewPage();
                        }

                        if (i == 24)
                        {
                            Paragraph elements = new Paragraph("Anexo 3. Licencia de operación IPEN para rayos X", textUtils.fontBold12Black);
                            elements.Alignment = Element.ALIGN_JUSTIFIED;

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/licencia_a.png"));
                            image.ScaleToFit(450f, 550f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;

                            document.Add(elements);
                            document.Add(image);

                            document.NewPage();
                        }

                        if (i == 25)
                        {

                            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/licencia.png"));
                            image.ScaleToFit(450f, 550f);
                            image.Alignment = Image.ALIGN_CENTER;
                            image.PaddingTop = 20f;


                            document.Add(image);

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