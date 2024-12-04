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
    private MotdDeserializer Deseializer;
    public string RawMotd { get; }
    
    public MotdComponents Components { get; private set; }
    
    public Motd(string motd): this(motd,new MotdOption()) {
    }
    
    public Motd(string motd, MotdOption option) {
        this.RawMotd = motd;
        this.Deseializer = new MotdDeserializer(option);
        this.Components = this.Deseializer.Deserialize(this.RawMotd);
    }
    public static implicit operator Motd(string motd) {
        return new (motd);
    }
    
    #region Override Function Section
    public override string ToString() {
        StringBuilder sb = new();
        foreach (var component in Components) {
            sb.Append(component.Text);
        }

        return sb.ToString();

    }
    #endregion
}