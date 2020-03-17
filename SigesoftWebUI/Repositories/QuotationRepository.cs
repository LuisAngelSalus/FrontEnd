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
                            document.NewPage();
                        }

                        if (i == 4)
                        {
                            document.NewPage();
                        }

                        if (i == 5)
                        {
                            document.NewPage();
                        }

                        if (i == 6)
                        {
                            document.NewPage();
                        }

                        if (i == 7)
                        {
                            document.NewPage();
                        }

                        if (i == 8)
                        {
                            document.NewPage();
                        }

                        if (i == 9)
                        {
                            document.NewPage();
                        }

                        if (i == 10)
                        {
                            document.NewPage();
                        }

                        if (i == 11)
                        {
                            document.NewPage();
                        }

                        if (i == 12)
                        {
                            document.NewPage();
                        }

                        if (i == 13)
                        {
                            document.NewPage();
                        }

                        if (i == 14)
                        {
                            document.NewPage();
                        }

                        if (i == 15)
                        {
                            document.NewPage();
                        }

                        if (i == 16)
                        {
                            document.NewPage();
                        }

                        if (i == 17)
                        {
                            document.NewPage();
                        }

                        if (i == 18)
                        {
                            document.NewPage();
                        }

                        if (i == 19)
                        {
                            //document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

                            var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                            var titleFontBlue = FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLUE);
                            var boldTableFont = FontFactory.GetFont("Arial", 8, Font.BOLD);
                            var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
                            var EmailFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLUE);
                            BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");


                            //Create body table
                            PdfPTable itemTable = new PdfPTable(5);

                            itemTable.HorizontalAlignment = 0;
                            itemTable.WidthPercentage = 100;
                            itemTable.SetWidths(new float[] { 5, 40, 10, 20, 25 });  // then set the column's __relative__ widths
                            itemTable.SpacingAfter = 40;
                            itemTable.DefaultCell.Border = Rectangle.BOX;
                            PdfPCell cell1 = new PdfPCell(new Phrase("NO", boldTableFont));
                            cell1.BackgroundColor = TabelHeaderBackGroundColor;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            itemTable.AddCell(cell1);
                            PdfPCell cell2 = new PdfPCell(new Phrase("DESCRIPTION", boldTableFont));
                            cell2.BackgroundColor = TabelHeaderBackGroundColor;
                            cell2.HorizontalAlignment = 1;
                            itemTable.AddCell(cell2);
                            PdfPCell cell3 = new PdfPCell(new Phrase("QUANTITY", boldTableFont));
                            cell3.BackgroundColor = TabelHeaderBackGroundColor;
                            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                            itemTable.AddCell(cell3);
                            PdfPCell cell4 = new PdfPCell(new Phrase("UNIT AMOUNT", boldTableFont));
                            cell4.BackgroundColor = TabelHeaderBackGroundColor;
                            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                            itemTable.AddCell(cell4);
                            PdfPCell cell5 = new PdfPCell(new Phrase("TOTAL", boldTableFont));
                            cell5.BackgroundColor = TabelHeaderBackGroundColor;
                            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                            itemTable.AddCell(cell5);
                            //foreach (DataRow row in dt.Rows)
                            {
                                PdfPCell numberCell = new PdfPCell(new Phrase("1", bodyFont));
                                numberCell.HorizontalAlignment = 1;
                                numberCell.PaddingLeft = 10f;
                                numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                itemTable.AddCell(numberCell);

                                var _phrase = new Phrase();
                                _phrase.Add(new Chunk("New Signup Subscription Plan\n", EmailFont));
                                _phrase.Add(new Chunk("Subscription Plan description will add here.", bodyFont));
                                PdfPCell descCell = new PdfPCell(_phrase);
                                descCell.HorizontalAlignment = 0;
                                descCell.PaddingLeft = 10f;
                                descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                itemTable.AddCell(descCell);

                                PdfPCell qtyCell = new PdfPCell(new Phrase("1", bodyFont));
                                qtyCell.HorizontalAlignment = 1;
                                qtyCell.PaddingLeft = 10f;
                                qtyCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                itemTable.AddCell(qtyCell);

                                PdfPCell amountCell = new PdfPCell(new Phrase("$100", bodyFont));
                                amountCell.HorizontalAlignment = 1;
                                amountCell.PaddingLeft = 10f;
                                amountCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                itemTable.AddCell(amountCell);

                                PdfPCell totalamtCell = new PdfPCell(new Phrase("$100", bodyFont));
                                totalamtCell.HorizontalAlignment = 1;
                                totalamtCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                itemTable.AddCell(totalamtCell);

                            }
                            // Table footer
                            PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
                            totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
                            itemTable.AddCell(totalAmtCell1);
                            PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(""));
                            totalAmtCell2.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                            itemTable.AddCell(totalAmtCell2);
                            PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(""));
                            totalAmtCell3.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                            itemTable.AddCell(totalAmtCell3);
                            PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Total Amount", boldTableFont));
                            totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                            totalAmtStrCell.HorizontalAlignment = 1;
                            itemTable.AddCell(totalAmtStrCell);
                            PdfPCell totalAmtCell = new PdfPCell(new Phrase("$100", boldTableFont));
                            totalAmtCell.HorizontalAlignment = 1;
                            itemTable.AddCell(totalAmtCell);

                            PdfPCell cell = new PdfPCell(new Phrase("***NOTICE: A finance charge of 1.5% will be made on unpaid balances after 30 days. ***", bodyFont));
                            cell.Colspan = 5;
                            cell.HorizontalAlignment = 1;
                            itemTable.AddCell(cell);
                            document.Add(itemTable);

                            document.NewPage();
                        }

                        if (i == 20)
                        {
                            document.NewPage();
                        }

                        if (i == 21)
                        {
                            document.NewPage();
                        }

                        if (i == 22)
                        {
                            document.NewPage();
                        }

                        if (i == 23)
                        {
                            document.NewPage();
                        }

                        if (i == 24)
                        {
                            document.NewPage();
                        }

                        if (i == 25)
                        {
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
                            document.NewPage();
                        }

                        if (i == 28)
                        {
                            document.NewPage();
                        }

                        if (i == 29)
                        {
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