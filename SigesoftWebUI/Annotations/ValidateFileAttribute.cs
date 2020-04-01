using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigesoftWebUI.Annotations
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent = 8192 * 8192; //1 MB
            string[] sAllowedExt = new string[] { ".jpg", ".gif", ".png", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".xlsm", ".wmv", ".MP4", ".MKV", ".AVI", ".MOV" };
            var file = value as HttpPostedFileBase;
            if (file == null)
                return false;
            else if (!sAllowedExt.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your File of type: " + string.Join(", ", sAllowedExt);
                return false;
            }
            else if (file.ContentLength > maxContent)
            {
                ErrorMessage = "Your File is too large, maximum allowed size is : " + (maxContent / 8192).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}