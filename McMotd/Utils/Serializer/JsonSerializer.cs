using McMotd.API;
using McMotd.Model;

namespace McMotd.Utils.Serializer;

public class JsonSerializer: IMotdSerializer<string> {
    public static JsonSerializer Default { get; } = new JsonSerializer();
    public string Serialize(MotdComponents motdComponents) {
        return System.Text.Json.JsonSerializer.Serialize(motdComponents);
    }
}