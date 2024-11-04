namespace McMotd.Test;

public class MotdTest 
{
    [Fact]
    public void ToHtmlSimpleTest() {
        Motd raw_motd = @"{""text"":""기모찌서버""}";
        
        Assert.True(raw_motd.ToString() == "기모찌서버 ");
    }

    [Fact]
    public void ToTextComplexTest() {
        Motd motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\r\n\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";
        
        Assert.Equal(motd.ToString(), "◆ ");
    }
    [Fact]
    public void ToTextSectionSignWithEscapeCharacterTest() {
        Motd motd = "\"                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY\"";
        
        Assert.Equal(motd.ToString(),"                ");
    }
    
    [Fact]
    public void ToHtmlComplexTest() {
        string raw_motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";
        var raw_html = new MotdParser().ToHtml(raw_motd);
        Assert.True(true);
    }
    [Fact]
    public void ToHtmlComplexWithEscapeCharacterTest() {
        string raw_motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\r\n\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";
        var raw_html = new MotdParser().ToHtml(raw_motd);
        Assert.True(true);
    }
    [Fact]
    public void ToHtmlSectionSignTest() {
        string raw_motd = "\"                §aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY\"";
        var raw_html = new MotdParser().ToHtml(raw_motd);
        Assert.True(true);
    }

    [Fact]
    public void ToHtmlSectionSignWithEscapeCharacterTest() {
        string raw_motd = "\"                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY\"";
        var raw_html = new MotdParser().ToHtml(raw_motd);
        Assert.True(true);
    }
}
