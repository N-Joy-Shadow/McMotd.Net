using System.Text;
using McMotd.API;
using McMotd.Enum;
using McMotd.Model;

namespace McMotd.Utils.Serializer;

public class HtmlSerializer: IMotdSerializer<string> {
    public static HtmlSerializer Default { get; } = new HtmlSerializer();
    public string Serialize(MotdComponents motdComponents) {
        var sb = new StringBuilder();
        
        sb.Append(@"<div class=""mcmotd-container"">");
        foreach (var component in motdComponents) {
            sb.Append("<span");
            sb.Append($" style=\"color:{component.Color};");
            sb.Append(HtmlStyle(component.TextFormatting));
            sb.Append("\">");
            sb.Append(component.Text.Replace(" ", "&nbsp;"));
            sb.Append("</span>");     
            if (component.LineBreak)
                sb.Append("<br/>");
        }
        sb.Append("</div>");

        
        return sb.ToString();
    }
    
    private string HtmlStyle(HashSet<MotdTextFormat> TextFormats) {
        StringBuilder sb = new StringBuilder();
        foreach (var TextFormat in TextFormats) {
            sb.Append(" ");
            switch (TextFormat) {
                case MotdTextFormat.Bold:
                    sb.Append("font-weight : bolder;");
                    break;
                case MotdTextFormat.Italic:
                    sb.Append("font-style : italic;");
                    break;
                case MotdTextFormat.Underline:
                    sb.Append("text-decoration : underline;");
                    break;
                case MotdTextFormat.Striktethrough:
                    sb.Append("text-decoration : line-through;");
                    break;
                default:
                    break;
            }

        }

        return sb.ToString();
    }
}