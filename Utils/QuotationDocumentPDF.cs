using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPdf
{
   public class QuotationDocumentPDF
    {
        public static MemoryStream CreateDocument(int code)
        {
            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            document.SetPageSize(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            pdfPage page = new pdfPage();
            writer.PageEvent = page;
            document.Open();

            Font H1 = FontFactory.GetFont("Calibri", 10, Font.NORMAL, new BaseColor(System.Drawing.Color.Black));

            #region Title
            document.Add(new Paragraph("\r\n"));
            document.Add(new Paragraph("\r\n"));
            document.Add(new Paragraph("\r\n"));

            Paragraph cTitle = new Paragraph("PROPUESTA TÉCNICO", H1);
            cTitle.Alignment = Element.ALIGN_CENTER;            

            document.Add(cTitle);


            document.Close();

            byte[] byteInfo = memoryStream.ToArray();
            memoryStream.Write(byteInfo, 0, byteInfo.Length);
            memoryStream.Position = 0;
            #endregion

            return memoryStream;
        }

    }
}
