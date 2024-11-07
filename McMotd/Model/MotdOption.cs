using McMotd.Enum;

namespace McMotd.Model;

//이름 보류
public class MotdOption {
    public HashSet<MotdParsingOption> Options { get; set; } = new();
    public HashSet<MotdHtmlOption>? HtmlOptions { get; set; } = new();
}
