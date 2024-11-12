using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Model;
using McMotd.Enum;
using McMotd.Utils;
using McMotd.Utils.Serializer;
using McMotd.Utils.Deserializer;

namespace McMotd;

public class Motd {
    private MotdDeserializer Derializer;
    public string RawMotd { get; }
    public MotdComponents components { get; set; }
    
    public Motd(string motd): this(motd,new MotdOption()) {
    }
    
    public Motd(string motd, MotdOption option) {
        this.RawMotd = motd;
        this.Derializer = new MotdDeserializer(option);
        this.components = this.Derializer.Deserialize(this.RawMotd);
    }
    public static implicit operator Motd(string motd) {
        return new (motd);
    }
    #region Override Function Section
    public override string ToString() {
        StringBuilder sb = new();
        foreach (var component in components.Components) {
            sb.Append(component.Text);
        }

        return sb.ToString();

    }
    #endregion
}