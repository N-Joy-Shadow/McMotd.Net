using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using McMotd.Extension;
using McMotd.Model;

namespace McMotd.Utils.Converter;

public class MotdJsonConverter : JsonConverter<MotdComponents> {
    private MotdOption _option;
    private MotdComponents motd { get; set; }

    public MotdJsonConverter(MotdOption option) {
        this._option = option;
    }

    public override MotdComponents? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.StartArray)
            return null;

        motd = new MotdComponents();

        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        //text 먼저 읽거나 index에 삽입해야함
        if (root.TryGetProperty("extra", out var extra)) {
            ParsingExtra(extra);
        }
        else {
            var component = new MotdComponent();
            foreach (var property in root.EnumerateObject()) {
                component.ParseJsonObject(property, _option);
            }
            motd.Add(component);
        }
        return motd;
    }
    private Queue<JsonElement> extraQueue = new Queue<JsonElement>();
    private void ParsingExtra(JsonElement element) {
        
        foreach (var obj in element.EnumerateArray()) {
            var component = new MotdComponent();
            if (obj.ValueKind == JsonValueKind.Object) {
                foreach (var property in obj.EnumerateObject()) {
                    //공백일 때 라인브레이크 추가 해야함
                    if (property.NameEquals("extra")) 
                        extraQueue.Enqueue(property.Value);
                    else 
                        component.ParseJsonObject(property, _option);
                }
            }
            else if (obj.ValueKind == JsonValueKind.String) {
                var text = obj.GetString(); //"text": ""의 값을 일단 가져옴 <- 이떄 라인 브레이크 해야함 ㅇㅇ 근데 막 하면 안됨
                if(text is not null)
                    if (text == "")
                        component.LineBreak = true;
            }

            if (!string.IsNullOrEmpty(component.Text)) {
                motd.Add(component);
            }
            if (extraQueue.TryDequeue(out var extra)) {
                ParsingExtra(extra);
            }
        }

    }

    public override void Write(Utf8JsonWriter writer, MotdComponents motd, JsonSerializerOptions options) {
        writer.WriteStartObject();
        foreach (var component in motd) {
        }
    }
}