using System.Diagnostics;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Utils;
using Microsoft.Extensions.Options;

namespace McMotd.Test.RegexTest;

public class RegexTest {
    
    [Fact]
    public void Regextest() {
        string motd  = "                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
        Regex lineBreakPattern = new Regex(@"(\r)?(\n)");
        var a = lineBreakPattern.Matches(motd);
    
        Debug.WriteLine(a);
        Assert.Equal(true,true);
    }
}

