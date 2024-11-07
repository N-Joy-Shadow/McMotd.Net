using System.Text.Json;
using System.Text.Json.Serialization;
using McMotd.Extension;
using McMotd.Model;

namespace McMotd.Utils.Converter;


public class MotdJsonConverter : JsonConverter<MotdComponents> {
    private MotdOption _option;
    public MotdJsonConverter(MotdOption option) {
        this._option = option;
    }
    public override MotdComponents? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.StartArray)
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

        return motd;
    }

    public override void Write(Utf8JsonWriter writer, MotdComponents motd, JsonSerializerOptions options) {
        writer.WriteStartObject(); 
        foreach (var component in motd.Components) {
            
        }
    }
}