using System.Text.Json;
using McMotd.API;
using McMotd.Enum;
using McMotd.Model;

namespace McMotd.Utils.Deserializer;

public class PlainTextDeserializer: IMotdDeserializer {
    private MotdOption _option;
    public PlainTextDeserializer(MotdOption option) {
        this._option = option;
    }
    public MotdComponents Deserialize(string RawMotd) {
        var motd = new MotdComponents();
        motd.Components.Add(new() {
            Text = RawMotd,
            Color = "#808080",
            TextFormatting = new(),
            LineBreak = false
        });
        return motd;
    }
    
}

