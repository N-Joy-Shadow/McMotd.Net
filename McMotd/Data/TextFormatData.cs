using McMotd.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMotd.Data
{
    public partial class MotdData
    {
        public static Dictionary<string,TextFormatEnum> TextFormatDict = new Dictionary<string, TextFormatEnum>() {
            {"k" ,  TextFormatEnum.Obfuscated },
            {"l" ,  TextFormatEnum.Bold },
            {"m" ,TextFormatEnum.Striktethrough },
            {"n" ,  TextFormatEnum.Underline },
            {"o" ,  TextFormatEnum.Italic },
            {"r" ,  TextFormatEnum.Reset },
            {"x" , TextFormatEnum.Noraml}
        };
    }
}
