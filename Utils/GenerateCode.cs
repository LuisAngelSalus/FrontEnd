using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class GenerateCode
    {
        public string Code(string prefix, string codeUser, int correlative)
        {
            return string.Format("{0}-{1}{2}", prefix, codeUser, correlative.ToString("000000000"));
        }
    }
}
