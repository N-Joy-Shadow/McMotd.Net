using System.Text.Json;
using System.Text.Json.Serialization;
using McMotd.API;
using McMotd.Enum;
using McMotd.Extension;
using McMotd.Model;

namespace McMotd.Deserializer;

public class MotdJsonDeserializer: IMotdDeserializer {
    private MotdOption _option;
    public MotdJsonDeserializer(MotdOption option) {
        this._option = option;
    }
    public MotdComponents Deserialize(string RawMotd) {
        throw new NotImplementedException();
    }
}

class MotdCustomJsonDeserializer : JsonConverter<MotdComponents> {
    private MotdOption _option;
    public MotdCustomJsonDeserializer(MotdOption option) {
        this._option = option;
    }
    public override MotdComponents? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType is not JsonTokenType.StartObject || reader.TokenType is not JsonTokenType.StartArray)
            return null;

        var motd = new MotdComponents();

        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.TryGetProperty("extra", out var extra)) {
            foreach (var obj in extra.EnumerateArray()) {
                var component = new MotdComponent();
                foreach (JsonProperty property in obj.EnumerateObject()) {
                    component.ParseJsonObject(property,_option);
                }
                motd.Components.Add(component);
            }
        }
        else {
            var component = new MotdComponent();
            foreach (var property in root.EnumerateObject()) {
                component.ParseJsonObject(property,_option);
            }
            motd.Components.Add(component);
        }
        
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, MotdComponents motd, JsonSerializerOptions options) {
        writer.WriteStartObject(); 
        foreach (var component in motd.Components) {
            
        }
    }
}