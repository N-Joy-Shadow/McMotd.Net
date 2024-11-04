using System.Diagnostics;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Options;
using McMotd.Utils;
using Microsoft.Extensions.Options;

namespace McMotd.Test.RegexTest;

public class RegexTest {
    
    [Fact]
    public void Regextest() {
        string motd  = "                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
        
        
        var a = new MotdParser().parse(motd,option);

        foreach (var b in a.Components) {
            Debug.WriteLine(b.Text);
        }
        
        Assert.Equal(true,true);
    }
}

