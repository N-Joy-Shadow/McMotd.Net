using System.Text.Json;
using System.Text.Json.Serialization;
using McMotd.API;
using McMotd.Enum;
using McMotd.Extension;
using McMotd.Model;
using McMotd.Utils.Converter;

namespace McMotd.Utils.Deserializer;

public class MotdJsonDeserializer: IMotdDeserializer {
    private MotdOption _option;
    public MotdJsonDeserializer(MotdOption option) {
        this._option = option;
    }
    public MotdComponents Deserialize(string RawMotd) { 
        var options = new JsonSerializerOptions {
            Converters = { new MotdJsonConverter(_option) }
        };

        if (_option.Options.Contains(MotdParsingOption.NoLineBreak))
            RawMotd = RawMotd.Replace(Environment.NewLine, string.Empty);
        else 
            RawMotd = RawMotd.Replace(Environment.NewLine, "§z");
        
        
        var motd =  JsonSerializer.Deserialize<MotdComponents>(RawMotd,options);
        return motd;
    }
}
