using McMotd.Extension;

namespace McMotd.Test;

public class MotdTest 
{
    [Fact]
    public void ToHtmlSimpleTest() {
        Motd raw_motd = @"{""text"":""기모찌서버""}";
        
        Assert.Equal("기모찌서버",raw_motd.ToString());
    }

    [Fact]
    public void ToTextComplexTest() {
        Motd motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\r\n\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";
        
        Assert.Equal( "◆ 스티브 갤러리 놀이터 ◆건축/쉼터", motd.ToString());
    }
    [Fact]
    public void ToHtmlComplexTest() {
        Motd motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";
        var html = motd.ToHtml();
        Assert.True(true);
    }
    [Fact]
    public void ToHtmlComplexWithEscapeCharacterTest() {
        Motd motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\r\n\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";
        var html = motd.ToHtml();
        Assert.True(true);
    }
    [Fact]
    public void ToHtmlSectionSignTest() {
        Motd motd = "\"                §aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY\"";
        var html = motd.ToHtml();
        Assert.True(true);
    }

    [Fact]
    public void ToHtmlSectionSignWithEscapeCharacterTest() {
        Motd motd = "\"                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY\"";
        var html = motd.ToHtml();
        Assert.True(true);
    }
}
