using iTextSharp.text;
using iTextSharp.text.html;

namespace SigesoftWebUI.Utils
{
    public class TextUtils
    {
        public BaseColor BaseColor { get; set; } = WebColors.GetRGBColor("#04C2C4");

        public Font font12Black { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        public Font font11Black { get; set; } = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        public Font fontBold11Black { get; set; } = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold12Black { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold12White { get; set; } = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
        public Font fontBold11Sky { get; set; } = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, WebColors.GetRGBColor("#04C2C4"));
        public Font fontBold16Black { get; set; } = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        public Font fontBold18Black { get; set; } = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

        public Font fontBold22Black { get; set; } = FontFactory.GetFont("Arial", 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
    }
}