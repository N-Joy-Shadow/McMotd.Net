using McMotd.Utils.Serializer;

namespace McMotd.Extension;

public static class MotdExtension {
    public static string ToHtml(this Motd motd) {
        return new HtmlSerializer().Serialize(motd.components);
    }

    public static string ToJson(this Motd motd) {
        return new JsonSerializer().Serialize(motd.components);
    }
    
    public static string ToPlainText(this Motd motd) {
        return new PlainTextSerializer().Serialize(motd.components);
    }
}