using System;
using System.Diagnostics;

namespace McMotd.Test.Deserializer;

public class SectionSignDeserializerTests {
    [Fact]
    public void SectionDeserializer() {
        // Arrange
        Motd motd = @"                §aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
        // Act
        var contents = motd.Components;
        var expect = new List<MotdComponent>() {
            new() { Color = "#808080", Text = "                " },
            new() { Color = "#55FF55", Text = "Hypixel Network " },
            new() { Color = "#FF5555", Text = "[1.8-1.20]        " },
            new() {
                Color = "#55FFFF", Text = "DROPPER v1.0 ",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            },
            new() { Color = "#AAAAAA", Text = "- " },
            new() {
                Color = "#FFAA00", Text = "NEW ARCADE LOBBY",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            }
        };
        // Assert
        Assert.Equal(expect, contents);
    }

    [Fact]
    public void SectionDeserializerStartWithSign() {
        Motd motd = @"§aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
        // Act
        var contents = motd.Components;
        var expect = new List<MotdComponent>() {
            new() { Color = "#55FF55", Text = "Hypixel Network " },
            new() { Color = "#FF5555", Text = "[1.8-1.20]        " },
            new() {
                Color = "#55FFFF", Text = "DROPPER v1.0 ",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            },
            new() { Color = "#AAAAAA", Text = "- " },
            new() {
                Color = "#FFAA00", Text = "NEW ARCADE LOBBY",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            }
        };
        // Assert
        Assert.Equal(expect, contents);
    }

    [Fact]
    public void SectionDeserializerStartWithSignAndWithEscapeCharacter() {
        var option = new MotdOption() { Options = new() { MotdParsingOption.NoLineBreak } };

        Motd motd = new Motd(
            $@"§aHypixel Network §c[1.8-1.20]{Environment.NewLine}        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY",
            option);
        // Act
        var contents = motd.Components;
        var expect = new List<MotdComponent>() {
            new() { Color = "#55FF55", Text = "Hypixel Network " },
            new() { Color = "#FF5555", Text = "[1.8-1.20]", LineBreak = true},
            new() { Color = "#808080", Text = "        " },
            new() {
                Color = "#55FFFF", Text = "DROPPER v1.0 ",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            },
            new() { Color = "#AAAAAA", Text = "- " },
            new() {
                Color = "#FFAA00", Text = "NEW ARCADE LOBBY",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            }
        };
        // Assert
        Assert.Equal(expect, contents);
    }

    [Fact]
    public void SectionSignMotdDeserializeWithEscapeCharacter() {
        Motd motd =
            $"                §aHypixel Network §c[1.8-1.20]{Environment.NewLine}        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";

        var contents = motd.Components;

        var expect = new List<MotdComponent>() {
            new() { Color = "#808080", Text = "                " },
            new() { Color = "#55FF55", Text = "Hypixel Network " },
            new() { Color = "#FF5555", Text = "[1.8-1.20]", LineBreak = true },
            new() { Color = "#808080", Text = "        " },
            new() {
                Color = "#55FFFF", Text = "DROPPER v1.0 ",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            },
            new() { Color = "#AAAAAA", Text = "- " },
            new() {
                Color = "#FFAA00", Text = "NEW ARCADE LOBBY",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }
            }
        };

        Assert.Equal(expect,contents);
    }
}