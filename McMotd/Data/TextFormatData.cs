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
        public static Dictionary<string,MotdTextFormat> TextFormatDict = new () {
            {"k" ,  MotdTextFormat.Obfuscated },
            {"l" ,  MotdTextFormat.Bold },
            {"m" ,MotdTextFormat.Striktethrough },
            {"n" ,  MotdTextFormat.Underline },
            {"o" ,  MotdTextFormat.Italic },
            {"r" ,  MotdTextFormat.Reset },
            {"x" , MotdTextFormat.Noraml}
        };
    }
}
