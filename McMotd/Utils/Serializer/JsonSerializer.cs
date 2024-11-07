using McMotd.API;
using McMotd.Model;

namespace McMotd.Utils.Serializer;

public class JsonSerializer: IMotdSerializer<string> {
    public string Serialize(MotdComponents motdComponents) {
        return System.Text.Json.JsonSerializer.Serialize(motdComponents.Components);
    }
}