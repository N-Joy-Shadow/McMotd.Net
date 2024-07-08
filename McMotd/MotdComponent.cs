using McMotd.Data.Mc;
using McMotd.Enum;

namespace McMotd;

public class MotdComponent {
    public string Color { get; set; } = "#808080";
    public string Text { get; set; }
    public HashSet<TextFormatEnum> TextFormatting { get; set; } = new ();
    public bool LineBreak { get; set; } = false;
}