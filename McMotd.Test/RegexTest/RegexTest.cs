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
        var a = lineBreakPattern.Replace(motd, string.Empty);
    
        Debug.WriteLine(a);
        Assert.Equal("                §aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY",a);
    }
    [Fact]
    public void Regextest2() {
        string motd  = "                §aHypixel Network §c[1.8-1.20]\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
        Regex lineBreakPattern = new Regex(@"(\r)?(\n)");
        var a = lineBreakPattern.Replace(motd, string.Empty);
    
        Debug.WriteLine(a);
        Assert.Equal("                §aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY",a);
    }

    [Fact]
    public void JsonRegexTest1() {
        string motd = "{\"color\" : \"gold\",\"bold\" : true,\"text\" : \"뉴인타운+RPG+반야생\r\n스망호 1.18.2~1.20.2\"}";
        Regex lineBreakPattern = new Regex(@"(\r)?(\n)");
        var a = lineBreakPattern.Replace(motd, string.Empty);
    
        Debug.WriteLine(a);
        Assert.Equal(@"{""color"" : ""gold"",""bold"" : true,""text"" : ""뉴인타운+RPG+반야생스망호 1.18.2~1.20.2""}",a);

    }
}

