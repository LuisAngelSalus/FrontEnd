using BE;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System;
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

        public PdfPTable GetPageNineTeen(Response<QuotationDto> response)
        {
            var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var titleFontBlue = FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLUE);
            var boldTableFont = FontFactory.GetFont("Arial", 8, Font.BOLD);
            var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
            var EmailFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLUE);
            BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

            int profileIndex = 0;

            int countProfile = response.Data.QuotationProfile.Count;
            int totalColumns = countProfile + 2;

            //Create body table
            PdfPTable itemTable = new PdfPTable(totalColumns);

            itemTable.HorizontalAlignment = 0;
            itemTable.WidthPercentage = 100;
            //itemTable.SetWidths(new float[] { 5, 40, 10, 20, 25 });  // then set the column's __relative__ widths
            itemTable.SpacingAfter = 40;
            itemTable.DefaultCell.Border = Rectangle.BOX;
            PdfPCell cell1 = new PdfPCell(new Phrase("", boldTableFont));
            cell1.BackgroundColor = TabelHeaderBackGroundColor;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            itemTable.AddCell(cell1);
            PdfPCell cell2 = new PdfPCell(new Phrase("", boldTableFont));
            cell2.BackgroundColor = TabelHeaderBackGroundColor;
            cell2.HorizontalAlignment = 1;
            itemTable.AddCell(cell2);

            foreach (var item in response.Data.QuotationProfile)
            {
                itemTable.AddCell(new PdfPCell(new Phrase(item.ProfileName, boldTableFont))).HorizontalAlignment = Element.ALIGN_CENTER;
            }

            PdfPCell cell2A = new PdfPCell(new Phrase("", boldTableFont));
            cell2A.BackgroundColor = TabelHeaderBackGroundColor;
            cell2A.HorizontalAlignment = Element.ALIGN_CENTER;
            itemTable.AddCell(cell2A);

            PdfPCell cell2B = new PdfPCell(new Phrase("", boldTableFont));
            cell2B.BackgroundColor = TabelHeaderBackGroundColor;
            cell2B.HorizontalAlignment = 1;
            itemTable.AddCell(cell2B);

            for (profileIndex = 0; profileIndex < response.Data.QuotationProfile.Count; profileIndex++)
            {
                itemTable.AddCell(new PdfPCell(new Phrase(response.Data.QuotationProfile[profileIndex].ServiceTypeName, boldTableFont))).HorizontalAlignment = Element.ALIGN_CENTER;
            }

            for (var componentIndex = 0; componentIndex < response.Data.QuotationProfile[profileIndex - 1].ProfileComponent.Count; componentIndex++)
            {
                itemTable.AddCell(new PdfPCell(new Phrase(response.Data.QuotationProfile[profileIndex - 1].ProfileComponent[componentIndex].CategoryName, boldTableFont))).HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(new PdfPCell(new Phrase(response.Data.QuotationProfile[profileIndex - 1].ProfileComponent[componentIndex].ComponentName, boldTableFont))).HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(new PdfPCell(new Phrase(response.Data.QuotationProfile[profileIndex - 1].ProfileComponent[componentIndex].RecordStatus == RecordStatus.Grabado ? "X" : "", boldTableFont))).HorizontalAlignment = Element.ALIGN_CENTER;
            }

            return itemTable;
        }

        public Paragraph GetPageTwentySix()
        {
            Paragraph elements = new Paragraph("demor");
            return elements;
        }


        public Paragraph GetPageEight(Response<QuotationDto> response, string fullNameUser)
        {
            var data = response.Data;
            Chunk chunkOne = new Chunk("PROPUESTA ECONÓMICA\n", textUtils.fontBold12Black);
            
            Phrase phrase = new Phrase();
            phrase.Add(chunkOne);
            
            Paragraph elements = new Paragraph();
            elements.Add(phrase);
            elements.Alignment = Element.ALIGN_LEFT;


            var examenes = new List<Detail>();            
            var perfiles = data.QuotationProfile;
            foreach (var perfil in perfiles)
            {
                foreach (var item in perfil.ProfileComponent)
                {
                    var oDetail = new Detail();
                    oDetail.ComponentId = item.ComponentId;
                    oDetail.ComponentName = item.ComponentName;
                    oDetail.Price = item.SalePrice.Value;
                    oDetail.AgeConditionalId = item.AgeConditionalId;
                    oDetail.Age= item.Age;
                    oDetail.GenderConditionalId = item.GenderConditionalId;
                    examenes.Add(oDetail);
                }
            }

            examenes = examenes.GroupBy(p => p.ComponentName).Select(p => p.First()).ToList();

            var cells = new List<PdfPCell>();
            //ROW 1
            cells.Add(new PdfPCell(new Phrase("FECHA: " + DateTime.Now.ToString("MM/dd/yyyy"), textUtils.font08Black)) { Colspan=2, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE});
            cells.Add(new PdfPCell(new Phrase("Tipo de Examen Ocupacional", textUtils.font08Black)) {Colspan = data.QuotationProfile.Count , HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });

            //ROW 2
            var typeExams = data.QuotationProfile.GroupBy(g => g.ServiceTypeName).Select(s => new { name = s.Key, count = s.Count() }).ToList();
            cells.Add(new PdfPCell(new Phrase("Ejecutiva: " + fullNameUser, textUtils.font08Black)) { Colspan = 2 });
            foreach (var typeExam in typeExams)
            {
                var colspanValue = typeExam.count;
                    cells.Add(new PdfPCell(new Phrase(typeExam.name, textUtils.font08Black)) { Colspan = colspanValue, HorizontalAlignment = Element.ALIGN_CENTER });
            }

            //ROW 3
            cells.Add(new PdfPCell(new Phrase("Grupos de Vigilancia Médica Similar (GVMS)", textUtils.font08Black)) { Colspan=2});            
            foreach (var profile in data.QuotationProfile)
            {
                cells.Add(new PdfPCell(new Phrase(profile.ProfileName, textUtils.font08Black)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.GRAY });
            }

            //ROW 4
            cells.Add(new PdfPCell(new Phrase("Exámenes Ocupacionales", textUtils.font08Black)));
            cells.Add(new PdfPCell(new Phrase("P.U.", textUtils.font08Black)) { HorizontalAlignment = Element.ALIGN_CENTER });
            foreach (var profile in data.QuotationProfile)
            {                    
                cells.Add(new PdfPCell(new Phrase(profile.ProfileComponent.Count.ToString(), textUtils.font08Black)) { HorizontalAlignment = Element.ALIGN_CENTER });                   
            }

            //ROW 5
            foreach (var item in examenes)
            {
                cells.Add(new PdfPCell(new Phrase(item.ComponentName, textUtils.font08Black)));
                cells.Add(new PdfPCell(new Phrase("S/." + item.Price.ToString(), textUtils.font08Black)));
                foreach (var profile in data.QuotationProfile)
                {
                    var existe = profile.ProfileComponent.Find(p => p.ComponentId == item.ComponentId);
                    if (existe != null)
                    {
                        cells.Add(new PdfPCell(new Phrase("X", textUtils.font08Black)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    }
                    else
                    {
                        cells.Add(new PdfPCell(new Phrase("", textUtils.font08Black)));
                    }
                    
                }
            }

            //ROW 6
            cells.Add(new PdfPCell(new Phrase("Sub total por GVMS", textUtils.font08Black)) { Colspan = 2});            
            foreach (var profile in data.QuotationProfile)
            {
                cells.Add(new PdfPCell(new Phrase("S/." + profile.ProfileComponent.Sum(p => p.SalePrice).ToString(), textUtils.font08Black)) { HorizontalAlignment = Element.ALIGN_CENTER});
            }

            //ROW 7
            cells.Add(new PdfPCell(new Phrase("Total (No incluye IGV)", textUtils.font08Black)) { Colspan = 2 });
            decimal? total = 0;
            foreach (var profile in data.QuotationProfile)
            {
                total += profile.ProfileComponent.Sum(p => p.SalePrice);
            }

            cells.Add(new PdfPCell(new Phrase("S/." + total.ToString(), textUtils.font08Black)) {Colspan= data.QuotationProfile.Count, HorizontalAlignment = Element.ALIGN_CENTER });


            var table = HandlingItextSharp.GenerateTableFromCells(cells, HandlingItextSharp.GetColumns(2 + data.QuotationProfile.Count), "PROTOCOLO EXÁMENES MÉDICOS OCUPACIONALES N°: "+ data.Code, textUtils.font12Black, new BaseColor(252, 252, 252));
            elements.Add(table);


            //TABLA EXAMENES ADICIONALES
            var cellsAdi = new List<PdfPCell>();
            var adicionales = data.AdditionalComponentsQuote;
            foreach (var item in adicionales)
            {
                cellsAdi.Add(new PdfPCell(new Phrase(item.ComponentName, textUtils.font08Black)));
                cellsAdi.Add(new PdfPCell(new Phrase("S/." + item.SalePrice.ToString(), textUtils.font08Black)));
                cellsAdi.Add(new PdfPCell(new Phrase("", textUtils.font08Black)) { Colspan= typeExams.Count  + 3});
            }

            var tableAddic = HandlingItextSharp.GenerateTableFromCells(cellsAdi, HandlingItextSharp.GetColumns(2 + data.QuotationProfile.Count), "EXÁMENES ADICIONALES", textUtils.font12Black, new BaseColor(252, 252, 252));
            elements.Add(tableAddic);

            //TABLA CONDICIONALES
            var cellsCond = new List<PdfPCell>();   
            foreach (var exam in examenes)
            {
                if (exam.GenderConditionalId != -1)
                {
                    cellsCond.Add(new PdfPCell(new Phrase(exam.ComponentName , textUtils.font08Black)));
                }

                if (exam.AgeConditionalId != -1)
                {
                    cellsCond.Add(new PdfPCell(new Phrase(exam.ComponentName, textUtils.font08Black)));
                }

            }

            var tableCondi = HandlingItextSharp.GenerateTableFromCells(cellsCond, new float[] { 100f }, "CONDICIONALES", textUtils.font12Black, new BaseColor(252, 252, 252));
            elements.Add(tableCondi);



            return elements;
        }

    }

    public class Detail
    {
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal Price { get; set; }
        public int? AgeConditionalId { get; set; }
        public int? Age { get; set; }
        public int? GenderConditionalId { get; set; }

    }
}