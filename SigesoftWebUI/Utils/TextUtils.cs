using iTextSharp.text;

namespace SigesoftWebUI.Utils
{
    public class TextUtils
    {
        public Font font12Black { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        public Font fontBold12Black { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold16Black { get; set; } = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold18Black { get; set; } = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

        public Font fontBold22Black { get; set; } = FontFactory.GetFont("Arial", 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
    }
}