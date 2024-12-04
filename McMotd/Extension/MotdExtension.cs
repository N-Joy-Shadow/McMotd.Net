using McMotd.Utils.Serializer;

namespace McMotd.Extension;

public static class MotdExtension {
    public static string ToHtml(this Motd motd) {
        return HtmlSerializer.Default.Serialize(motd.Components);
    }

    public static string ToJson(this Motd motd) {
        return JsonSerializer.Default.Serialize(motd.Components);
    }
    
    public static string ToPlainText(this Motd motd) {
        return PlainTextSerializer.Default.Serialize(motd.Components);
    }
}