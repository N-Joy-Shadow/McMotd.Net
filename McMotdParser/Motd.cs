using System.Text.RegularExpressions;
using McMotdParser.Options;
using McMotdParser.Utils;

namespace McMotdParser;

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

    private void parseMotd() {
        if (this.isJson()) {
            
        }
        else {
            Regex regex = McRegex.pattern;
            var matches = regex.Matches(rawMotd);
            
            
        }
    }

    private void PreInit() {
        
    }

    private bool isJson() {
        return (rawMotd.StartsWith("{") || rawMotd.EndsWith("}"));
    }
}