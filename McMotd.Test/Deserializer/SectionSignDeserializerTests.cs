using System;
using System.Diagnostics;

namespace McMotd.Test.Deserializer
{
    public class SectionSignDeserializerTests
    {
        [Fact]
        public void SectionDeserializer()
        {
            // Arrange
            Motd motd=  @"                §aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
            // Act
            var contents = motd.components.Components;
            var expect = new List<MotdComponent>()
            {
                new() { Color = "#808080", Text = "                " },
                new() { Color = "#55FF55", Text = "Hypixel Network " },
                new() { Color = "#FF5555", Text = "[1.8-1.20]        " },
                new() { Color = "#55FFFF", Text = "DROPPER v1.0 ", TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }},
                new() { Color = "#AAAAAA", Text = "- " },
                new() { Color = "#FFAA00", Text = "NEW ARCADE LOBBY", TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }}
            };
            // Assert
            Assert.Equal(contents,expect);
        }
        [Fact]
        public void SectionDeserializerStartWithSign() {
            Motd motd = @"§aHypixel Network §c[1.8-1.20]        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";
            // Act
            var contents = motd.components.Components;
            var expect = new List<MotdComponent>()
            {
                new() { Color = "#55FF55", Text = "Hypixel Network " },
                new() { Color = "#FF5555", Text = "[1.8-1.20]        " },
                new() { Color = "#55FFFF", Text = "DROPPER v1.0 ", TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }},
                new() { Color = "#AAAAAA", Text = "- " },
                new() { Color = "#FFAA00", Text = "NEW ARCADE LOBBY", TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }}
            };
            // Assert
            Assert.True(contents.SequenceEqual(expect));
        }        
        [Fact]
        public void SectionDeserializerStartWithSignAndWithEscapeCharacter() {
            Motd motd = @"§aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";

            // Act
            var contents = motd.components.Components;
            var expect = new List<MotdComponent>()
            {
                new() { Color = "#55FF55", Text = "Hypixel Network " },
                new() { Color = "#FF5555", Text = "[1.8-1.20]"},
                new() { Color = "#55FFFF", Text = "        DROPPER v1.0 ", TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }},
                new() { Color = "#AAAAAA", Text = "- " },
                new() { Color = "#FFAA00", Text = "NEW ARCADE LOBBY", TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold }}
            };
            // Assert
            Assert.True(contents.SequenceEqual(expect));
        }
    }
}
