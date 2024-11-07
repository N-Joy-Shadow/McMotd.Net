namespace McMotd.Test.Deserializer;

public class PlainTextDeserializer {
    [Fact]
    public void PlainTextTest() {
        Motd motd = "Minecraft Server";
        Assert.Equal("Minecraft Server",motd.ToString());
    }

    [Fact]
    public void PlainTextEsacpeTest() {
        Motd motd = "Minecraft\nServer";
        Assert.Equal(motd.RawMotd, motd.ToString());
    }
}