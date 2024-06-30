using McMotdParser.Data.Mc;
using McMotdParser.Enum;

namespace McMotdParser;

public class MotdComponent {
    public string Text { get; set; } = "#808080";
    public McColor Color { get; set; }
    public HashSet<TextFormatEnum> Format { get; set; }
}