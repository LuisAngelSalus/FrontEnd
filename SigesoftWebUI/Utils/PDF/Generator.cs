using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Utils;

namespace SigesoftWebUI.Utils.PDF
{
    public class Generator
    {
        private readonly TextUtils textUtils = new TextUtils();
        public PdfPTable GetPageOne(Response<QuotationDto> response)
        {
            Phrase phraseOne = new Phrase("PROPUESTA TÉCNICO" + Environment.NewLine + "ECONÓMICA N° " + response.Data.Code + Environment.NewLine + Environment.NewLine, textUtils.fontBold16Black);
            Phrase phraseTwo = new Phrase("EXÁMENES DE SALUD" + Environment.NewLine + "OCUPACIONAL" + Environment.NewLine + Environment.NewLine, textUtils.fontBold22Black);
            Phrase phraseThree = new Phrase("CLIENTE:" + Environment.NewLine + response.Data.CompanyName + Environment.NewLine + Environment.NewLine, textUtils.fontBold18Black);
            Phrase phraseFour = new Phrase("EJECUTIVO/A COMERCIAL:" + Environment.NewLine + Environment.NewLine + "Ejecutiva de prueba" + Environment.NewLine + Environment.NewLine, textUtils.fontBold18Black);
            Phrase phraseFive = new Phrase("Cel.: XXXXXXXXXXXX" + Environment.NewLine + "Of.: (511) 640-7309   Ext. XXXX" + Environment.NewLine + "Correo: demo@demo.com", textUtils.fontBold16Black);


            PdfPTable pdfPTable = new PdfPTable(1);
            pdfPTable.WidthPercentage = 55;

            Paragraph paragraphOne = new Paragraph(phraseOne);
            PdfPCell pdfPCellOne = new PdfPCell(paragraphOne);
            pdfPCellOne.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfPCellOne.Border = 0;

            Paragraph paragraphTwo = new Paragraph(phraseTwo);
            PdfPCell pdfPCellTwo = new PdfPCell(paragraphTwo);
            pdfPCellTwo.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfPCellTwo.Border = 0;

            Paragraph paragraphThree = new Paragraph(phraseThree);
            PdfPCell pdfPCellThree = new PdfPCell(paragraphThree);
            pdfPCellThree.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfPCellThree.Border = 0;

            Paragraph paragraphFour = new Paragraph(phraseFour);
            PdfPCell pdfPCellFour = new PdfPCell(paragraphFour);
            pdfPCellFour.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfPCellFour.Border = 0;

            Paragraph paragraphFive = new Paragraph(phraseFive);
            PdfPCell pdfPCellFive = new PdfPCell(paragraphFive);
            pdfPCellFive.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfPCellFive.Border = 0;

            pdfPTable.AddCell(pdfPCellOne);

            pdfPTable.AddCell(pdfPCellTwo);

            pdfPTable.AddCell(pdfPCellThree);

            pdfPTable.AddCell(pdfPCellFour);

            pdfPTable.AddCell(pdfPCellFive);

            pdfPTable.HorizontalAlignment = Element.ALIGN_RIGHT;

            return pdfPTable;
        }

        public Paragraph GetPageTwo(Response<QuotationDto> response)
        {
            Chunk chunkOne = new Chunk("Señores:\n", textUtils.fontBold12Black);
            Chunk chunkTwo = new Chunk(response.Data.CompanyName + "\n\n\n", textUtils.font12Black);
            Chunk chunkThree = new Chunk("Presente.-\n\n", textUtils.font12Black);
            Chunk chunkFour = new Chunk("De nuestra mayor consideración:\n\n", textUtils.font12Black);
            Chunk chunkFive = new Chunk("Por medio de la presente, reciban un cordial saludo a nombre de SALUS LABORIS S.A.C. Somos una empresa que brinda servicios integrales de Salud Ocupacional y Respuesta a Emergencias con más de", textUtils.font12Black);
            Chunk chunkSix = new Chunk(" 12 años ", textUtils.fontBold12Black);
            Chunk chunkSeven = new Chunk("de experiencia en el mercado.\n\n", textUtils.font12Black);
            Chunk chunkEight = new Chunk("En esta oportunidad les hacemos llegar nuestra", textUtils.font12Black);
            Chunk chunkNine = new Chunk(" propuesta técnico económica ", textUtils.fontBold12Black);
            Chunk chunkTen = new Chunk("por el servicio de ", textUtils.font12Black);
            Chunk chunkEleven = new Chunk("Exámenes de Salud Ocupacional ", textUtils.fontBold12Black);
            Chunk chunkTwelve = new Chunk("en nuestro Centro de Salud Ocupacional de Surco – Lima, la cual ha sido elaborada en base a su requerimiento.\n\n", textUtils.font12Black);
            Chunk chunkThirteen = new Chunk("Desde la Gerencia General, nos comprometemos a brindar todo el soporte necesario para que el servicio que les podamos brindar satisfaga ampliamente sus expectativas.\n\n", textUtils.font12Black);
            Chunk chunkFourtenn = new Chunk("Sin otro particular nos despedimos quedando a su disposición.\n\n", textUtils.font12Black);
            Chunk chunkFifteen = new Chunk("Atentamente,\n\n\n\n", textUtils.font12Black);
            Chunk chunkSixteen = new Chunk("Horacio Reeves\n", textUtils.fontBold12Black);
            Chunk chunkSeventeen = new Chunk("Gerente General\n", textUtils.font12Black);
            Chunk chunkEighteen = new Chunk("SALUS LABORIS S.A.C.", textUtils.fontBold12Black);

            Phrase phrase = new Phrase();
            phrase.Add(chunkOne);
            phrase.Add(chunkTwo);
            phrase.Add(chunkThree);
            phrase.Add(chunkFour);
            phrase.Add(chunkFive);
            phrase.Add(chunkSix);
            phrase.Add(chunkSeven);
            phrase.Add(chunkEight);
            phrase.Add(chunkNine);
            phrase.Add(chunkTen);
            phrase.Add(chunkEleven);
            phrase.Add(chunkTwelve);
            phrase.Add(chunkThirteen);
            phrase.Add(chunkFourtenn);
            phrase.Add(chunkFifteen);
            phrase.Add(chunkSixteen);
            phrase.Add(chunkSeventeen);
            phrase.Add(chunkEighteen);

            Paragraph elements = new Paragraph();
            elements.Add(phrase);
            elements.Alignment = Element.ALIGN_JUSTIFIED;

            return elements;
        }

        public Paragraph GetPageThree()
        {
            //Chunk chunkOne = new Chunk("CONTENIDO:\n", textUtils.fontBold12Black,);
            //chunkOne.

            //Chunk chunkTwo = new Chunk(response.Data.CompanyName + "\n\n\n", textUtils.font12Black);
            //Chunk chunkThree = new Chunk("Presente.-\n\n", textUtils.font12Black);
            //Chunk chunkFour = new Chunk("De nuestra mayor consideración:\n\n", textUtils.font12Black);
            //Chunk chunkFive = new Chunk("Por medio de la presente, reciban un cordial saludo a nombre de SALUS LABORIS S.A.C. Somos una empresa que brinda servicios integrales de Salud Ocupacional y Respuesta a Emergencias con más de", textUtils.font12Black);
            //Chunk chunkSix = new Chunk(" 12 años ", textUtils.fontBold12Black);
            //Chunk chunkSeven = new Chunk("de experiencia en el mercado.\n\n", textUtils.font12Black);
            //Chunk chunkEight = new Chunk("En esta oportunidad les hacemos llegar nuestra", textUtils.font12Black);
            //Chunk chunkNine = new Chunk(" propuesta técnico económica ", textUtils.fontBold12Black);
            //Chunk chunkTen = new Chunk("por el servicio de ", textUtils.font12Black);
            //Chunk chunkEleven = new Chunk("Exámenes de Salud Ocupacional ", textUtils.fontBold12Black);
            //Chunk chunkTwelve = new Chunk("en nuestro Centro de Salud Ocupacional de Surco – Lima, la cual ha sido elaborada en base a su requerimiento.\n\n", textUtils.font12Black);
            //Chunk chunkThirteen = new Chunk("Desde la Gerencia General, nos comprometemos a brindar todo el soporte necesario para que el servicio que les podamos brindar satisfaga ampliamente sus expectativas.\n\n", textUtils.font12Black);
            //Chunk chunkFourtenn = new Chunk("Sin otro particular nos despedimos quedando a su disposición.\n\n", textUtils.font12Black);
            //Chunk chunkFifteen = new Chunk("Atentamente,\n\n\n\n", textUtils.font12Black);
            //Chunk chunkSixteen = new Chunk("Horacio Reeves\n", textUtils.fontBold12Black);
            //Chunk chunkSeventeen = new Chunk("Gerente General\n", textUtils.font12Black);
            //Chunk chunkEighteen = new Chunk("SALUS LABORIS S.A.C.", textUtils.fontBold12Black);

            //Phrase phrase = new Phrase();
            //phrase.Add(chunkOne);
            //phrase.Add(chunkTwo);
            //phrase.Add(chunkThree);
            //phrase.Add(chunkFour);
            //phrase.Add(chunkFive);
            //phrase.Add(chunkSix);
            //phrase.Add(chunkSeven);
            //phrase.Add(chunkEight);
            //phrase.Add(chunkNine);
            //phrase.Add(chunkTen);
            //phrase.Add(chunkEleven);
            //phrase.Add(chunkTwelve);
            //phrase.Add(chunkThirteen);
            //phrase.Add(chunkFourtenn);
            //phrase.Add(chunkFifteen);
            //phrase.Add(chunkSixteen);
            //phrase.Add(chunkSeventeen);
            //phrase.Add(chunkEighteen);

            Paragraph elements = new Paragraph();
            //elements.Add(phrase);
            //elements.Alignment = Element.ALIGN_JUSTIFIED;

            return elements;
        }

        public Paragraph GetPageTwentySix()
        {
            Paragraph elements = new Paragraph("demor");
            return elements;
        }
    }
}