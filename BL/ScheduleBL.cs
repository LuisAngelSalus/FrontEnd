using BE;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BL
{
    public class ScheduleBL
    {
        Global _global = new Global();

        public List<ScheduleExcelImportDto> Read (byte[] bytes, string token)
        {           
            MemoryStream stream = new MemoryStream(bytes);
            var list = new List<ScheduleExcelImportDto>();
            IWorkbook book = new XSSFWorkbook(stream);
            ISheet Sheet = book.GetSheet(book.GetSheetName(0));
            int index = 3;            

            bool finArchivo = false;
            while (!finArchivo)
            {
                try
                {
                    index++;
                    IRow Row = Sheet.GetRow(index);
                    if (Row != null)
                    {
                        var row = new ScheduleExcelImportDto();
                        row.DateSchedule = Row.GetCell(1) != null ? Row.GetCell(1).ToString() : "";
                        row.DocumentTypeName = Row.GetCell(2) != null ? Row.GetCell(2).ToString() : "";
                        row.DocumentNumber = Row.GetCell(3) != null ? Row.GetCell(3).ToString() : "";
                        row.FirstName= Row.GetCell(4) != null ? Row.GetCell(4).ToString() : "";
                        row.FirstLastName = Row.GetCell(5) != null ? Row.GetCell(5).ToString() : "";
                        row.SecondLastName = Row.GetCell(6) != null ? Row.GetCell(6).ToString() : "";
                        row.Gender = Row.GetCell(7) != null ? Row.GetCell(7).ToString() : "";
                        row.CurrentOccupation = Row.GetCell(8) != null ? Row.GetCell(8).ToString() : "";
                        row.MobileNumber = Row.GetCell(12) != null ? Row.GetCell(12).ToString() : "";
                        row.Email = Row.GetCell(13) != null ? Row.GetCell(13).ToString() : "";
                        list.Add(row);
                    }
                    else
                    {
                        finArchivo = true;
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            
            return list;
        }

    }
}
