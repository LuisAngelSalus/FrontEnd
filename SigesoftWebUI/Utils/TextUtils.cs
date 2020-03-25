using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
namespace SigesoftWebUI.Utils
{
    public class TextUtils
    {
        public Font font08Black { get; set; } = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        public Font font10Black { get; set; } = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        public Font font12Black { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        public Font fontBold12Black { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold16Black { get; set; } = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold18Black { get; set; } = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold22Black { get; set; } = FontFactory.GetFont("Arial", 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
    }


    public class HandlingItextSharp
    {
        public static float[] GetColumns(int countColumns)
        {
            float[] columnWidths = null;

            if (countColumns == 3)
            {
                columnWidths = new float[] { 20f,10f,70f };
            }
            else if (countColumns == 4)
            {
                columnWidths = new float[] { 20f, 10f, 35f,35f };
            }
            else if (countColumns == 5)
            {
                columnWidths = new float[] { 20f, 10f, 23f, 23f, 23f };
            }
            else if (countColumns == 6)
            {
                columnWidths = new float[] { 20f, 10f, 17.5f, 17.5f, 17.5f, 17.5f };
            }
            else if (countColumns == 7)
            {
                columnWidths = new float[] { 20f, 10f, 14f, 14f, 14f, 14f, 14f };
            }
            else if (countColumns == 8)
            {
                columnWidths = new float[] { 20f, 10f, 11.6f, 11.6f, 11.6f, 11.6f, 11.6f, 11.6f };
            }
            else if (countColumns == 9)
            {
                columnWidths = new float[] { 20f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f };
            }
            else if (countColumns == 10)
            {
                columnWidths = new float[] { 20f, 10f, 8.75f, 8.75f, 8.75f, 8.75f, 8.75f, 8.75f, 8.75f, 8.75f };
            }
            else
            {
                columnWidths = new float[] { 100f };
            }

            return columnWidths;
        }

        public static PdfPTable GenerateTableFromCells(List<PdfPCell> cells, float[] columnWidths, string title, Font fontTitle, BaseColor baseColor)
        {
            return GenerateTableFromCells(cells, columnWidths, null, title, fontTitle, null, baseColor);
        }

        public static PdfPTable GenerateTableFromCells(List<PdfPCell> cells, float[] columnWidths, int? borderCell, string title, Font fontTitle, BaseColor baseColor)
        {
            return GenerateTableFromCells(cells, columnWidths, borderCell, title, fontTitle, null, baseColor);
        }

        public static PdfPTable GenerateTableFromCells(List<PdfPCell> cells, float[] columnWidths, int? borderCell, string title, Font fontTitle, string[] columnHeaders, BaseColor baseColor)
        {
            PdfPCell cell = null;

            int numColumns = columnWidths.Length;

            PdfPTable table = new PdfPTable(numColumns);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 100;            
            table.SetWidths(columnWidths);           

            // Agregar Titulo a la tabla
            if (title != null)
            {
                cell = new PdfPCell(new Paragraph(title, fontTitle));                
                cell.Colspan = numColumns;
                cell.BackgroundColor = baseColor;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Establecer Cabecera con nombres personalizados

            if (columnHeaders != null)
            {
                foreach (string ch in columnHeaders)
                {
                    cell = new PdfPCell(new Paragraph(ch, fontTitle));
                    //cell.BackgroundColor = new BaseColor(System.Drawing.Color.Gray);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }
            }

            foreach (PdfPCell ce in cells)
            {
                if (borderCell != null)
                    ce.Border = borderCell.Value;

                table.AddCell(ce);
            }

            return table;
        }
    }
}