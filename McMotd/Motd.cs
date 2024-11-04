using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Model;
using McMotd.Options;
using McMotd.Utils;

namespace McMotd;

public class Motd {
    public string rawMotd { get; set; }
    
    public MotdOption option { get; set; }
    public Motd(string motd) : this(motd, new MotdOption()) {
    }

    public Motd(string motd, MotdOption option) {
        this.rawMotd = motd;
        this.option = option;
    }
    
    public static implicit operator Motd(string motd) {
        if (motd is null)
            throw new Exception("motd is null");

        return new Motd(motd);
    }

    public string ToString() {
        var a = parseMotd();
        return a.First().Text;
    }
    
    
    
    private List<MotdComponent> parseMotd() {
        if (this.isJson()) {
            var components = JsonSerializer.Deserialize<RawMotd>(this.rawMotd).ToMotdComponents();
            return components;
        }
        else {
            return new SectionSignParser().parse(this);
        }
    }

    private bool isJson() {
        return (rawMotd.StartsWith("{") || rawMotd.EndsWith("}"));
    }
}