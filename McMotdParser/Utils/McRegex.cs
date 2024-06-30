using System.Text.RegularExpressions;

namespace McMotdParser.Utils;

public class McRegex {
    public static Regex pattern = new Regex("§(0|1|2|3|4|5|6|7|8|9|a|b|c|d|e|f|k|l|m|n|o|r)([^§]*)");
    public static Regex stripPattern = new Regex("\\\\+r\\\\+n");
}