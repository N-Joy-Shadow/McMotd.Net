using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Options;
using McMotd.Utils;

namespace McMotd;

public class Motd {
    private string rawMotd;
    private MotdOption option;
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

    public string ToJson() {
        return "";
    }
    public string ToString() {
        return "";
    }
    
    private void parseMotd() {
        if (this.isJson()) {
        }
        else {
            Regex regex = McRegex.pattern;
            var matches = regex.Matches(rawMotd);
        }
    }

    private bool isJson() {
        return (rawMotd.StartsWith("{") || rawMotd.EndsWith("}"));
    }
}