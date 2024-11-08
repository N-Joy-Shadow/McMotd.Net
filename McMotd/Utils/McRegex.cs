using System.Text.RegularExpressions;

namespace McMotd.Utils;

public class McRegex {
    //public static Regex pattern = new Regex("(§(0|1|2|3|4|5|6|7|8|9|a|b|c|d|e|f|k|l|m|n|o|r|z))(§(0|1|2|3|4|5|6|7|8|9|a|b|c|d|e|f|k|l|m|n|o|r|z))?([^§]*)");
    public static Regex pattern = new Regex("(§([0-9a-fk-orz]))(§([0-9a-fk-orz]))?([^§]*)");
    public static Regex lineBreakPattern =  new Regex(@"(\\r)?(\\n)");
    public static Regex stripPattern = new Regex(@"(\s)+§");
    public static Regex QuotationPattern = new Regex("\"");
    public static Regex leadingWhitespacePattern = new Regex(@"(^\s*(?=§))");
}