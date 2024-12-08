using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.API;
using McMotd.Enum;
using McMotd.Extension;
using McMotd.Model;
using McMotd.Utils.Converter;

namespace McMotd.Utils.Deserializer;

public class MotdJsonDeserializer: IMotdDeserializer {
    private const string SIGN = "§";

    private MotdOption _option;
    public MotdJsonDeserializer(MotdOption option) {
        this._option = option;
    }
    public MotdComponents Deserialize(string RawMotd) { 
        var options = new JsonSerializerOptions {
            Converters = { new MotdJsonConverter(_option) }
        };

        var nRawMotd = McRegex.LineBreakPattern.Replace(RawMotd,
            _option.Options.Contains(MotdParsingOption.NoLineBreak) ? string.Empty : "§z");
        
        var motds =  JsonSerializer.Deserialize<MotdComponents>(nRawMotd,options);

        return motds;
    }
}
