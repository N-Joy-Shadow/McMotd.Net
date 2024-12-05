using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Diagnostics;

namespace McMotd.Test.Deserializer;

public class JsonDeserializerTests {
    [Fact]
    public void VerySimpleJsonMotdDeserialize() {
        Motd motd = @"{""text"":""기모찌서버""}";

        var contents = motd.Components;
        var expect = new List<MotdComponent>() {
            new() { Color = "#808080", Text = "기모찌서버" }
        };

        Assert.True(contents.SequenceEqual(expect));
    }

    [Fact]
    public void ComplexJsonMotdDeserialize() {
        //string motd = @"{""extra"":[{""Color"":""aqua"",""text"":""◆ ""},{""bold"":true,""italic"":true,""Color"":""#00ffff"",""text"":""스""},{""bold"":true,""italic"":true,""Color"":""#19e5ff"",""text"":""티""},{""bold"":true,""italic"":true,""Color"":""#33ccff"",""text"":""브""},{""bold"":true,""italic"":true,""Color"":""#4cb2ff"",""text"":""""},{""bold"":true,""italic"":true,""Color"":""#6699ff"",""text"":""갤""},{""bold"":true,""italic"":true,""Color"":""#7f7fff"",""text"":""러""},{""bold"":true,""italic"":true,""Color"":""#9966ff"",""text"":""리""},{""bold"":true,""italic"":true,""Color"":""#b24cff"",""text"":""""},{""bold"":true,""italic"":true,""Color"":""#cc32ff"",""text"":""놀""},{""bold"":true,""italic"":true,""Color"":""#e519ff"",""text"":""이""},{""bold"":true,""italic"":true,""Color"":""#ff00ff"",""text"":""터""},{""Color"":""light_purple"",""text"":"" ◆\r\n""},{""Color"":""gray"",""text"":""건축\/쉼터""}],""text"":""""}";
        Motd motd =
            "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\"\"}";

        var contents = motd.Components;

        var expect = new List<MotdComponent>() {
            new() { Color = "#55FFFF", Text = "◆ " },
            new() {
                Color = "#00ffff", Text = "스",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#19e5ff", Text = "티",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#33ccff", Text = "브",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#4cb2ff", Text = " ",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#6699ff", Text = "갤",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#7f7fff", Text = "러",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#9966ff", Text = "리",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#b24cff", Text = " ",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#cc32ff", Text = "놀",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#e519ff", Text = "이",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() {
                Color = "#ff00ff", Text = "터",
                TextFormatting = new HashSet<MotdTextFormat> { MotdTextFormat.Bold, MotdTextFormat.Italic }
            },
            new() { Color = "#FF55FF", Text = " ◆" },
            new() { Color = "#AAAAAA", Text = "건축/쉼터" },
        };

        Assert.True(contents.SequenceEqual(expect));
    }

    

    [Fact]
    public void SimpleJsonMotdDeserialize() {
        //TODO: 예측 케이스 추가
        Motd motd = @"{""color"" : ""gold"",""bold"" : true,""text"" : ""뉴인타운+RPG+반야생 스망호 1.18.2~1.20.2""}";

        var contents = motd.Components;

        var expect = new List<MotdComponent>() {
            new() {
                Color = "#FFAA00", Text = "뉴인타운+RPG+반야생 스망호 1.18.2~1.20.2",
                TextFormatting = new HashSet<MotdTextFormat>() { MotdTextFormat.Bold }
            }
        };
        
        Assert.True(contents.SequenceEqual(expect));

    }

    [Fact]
    public void CompleExtraNoEscapeButExistLineBreakJsonMotdDeserialize() {
        Motd motd =
            @"{""extra"":[{""extra"":[{""color"":""#4482B7"",""extra"":[{""bold"":true,""extra"":[{""color"":""#4482B7"",""text"":""M""},{""color"":""#4787BD"",""text"":""I""},{""color"":""#4A8CC3"",""text"":""N""},{""color"":""#4D90C8"",""text"":""E""},{""color"":""#5095CE"",""text"":""""},{""color"":""#549AD4"",""text"":""P""},{""color"":""#579FDA"",""text"":""L""},{""color"":""#5AA4E0"",""text"":""A""},{""color"":""#5DA8E5"",""text"":""N""},{""color"":""#60ADEB"",""text"":""E""},{""color"":""#63B2F1"",""text"":""T""}],""text"":""""},{""color"":""#63B2F1"",""text"":"" ₪""}],""text"":""₪ ""}],""text"":""""},"""",{""extra"":[{""color"":""#63F1D5"",""text"":""당""},{""color"":""#67F2D6"",""text"":""신""},{""color"":""#6BF2D8"",""text"":""의""},{""color"":""#6FF3D9"",""text"":""""},{""color"":""#74F4DB"",""text"":""모""},{""color"":""#78F4DC"",""text"":""험""},{""color"":""#7CF5DD"",""text"":""을""},{""color"":""#80F6DF"",""text"":""""},{""color"":""#84F7E0"",""text"":""시""},{""color"":""#88F7E1"",""text"":""작""},{""color"":""#8DF8E3"",""text"":""하""},{""color"":""#91F9E4"",""text"":""세""},{""color"":""#95F9E6"",""text"":""요""},{""color"":""#99FAE7"",""text"":""!""}],""text"":""""}],""text"":""""}";
        
        var contents = motd.Components;
        var expect = new List<MotdComponent>() {
            new() { Color = "#63B2F1", Text = "  ₪", },
            new() { Color = "#4482B7", Text = "M" },
            new() { Color = "#4787BD", Text = "I" },
            new() { Color = "#4A8CC3", Text = "N" },
            new() { Color = "#4D90C8", Text = "E" },
            new() { Color = "#5095CE", Text = "" },
            new() { Color = "#549AD4", Text = "P" },
            new() { Color = "#579FDA", Text = "L" },
            new() { Color = "#5AA4E0", Text = "A" },
            new() { Color = "#5DA8E5", Text = "N" },
            new() { Color = "#60ADEB", Text = "E" },
            new() { Color = "#63B2F1", Text = "T" },
            new() { Color = "#4482B7", Text = "₪ " },
            new() { LineBreak =true},
            new() { Color = "#63F1D5", Text = "당" },
            new() { Color = "#67F2D6", Text = "신" },
            new() { Color = "#6BF2D8", Text = "의" },
            new() { Color = "#6FF3D9", Text = " " },
            new() { Color = "#74F4DB", Text = "모" },
            new() { Color = "#78F4DC", Text = "험" },
            new() { Color = "#7CF5DD", Text = "을" },
            new() { Color = "#80F6DF", Text = " " },
            new() { Color = "#84F7E0", Text = "시" },
            new() { Color = "#88F7E1", Text = "작" },
            new() { Color = "#8DF8E3", Text = "하" },
            new() { Color = "#91F9E4", Text = "세" },
            new() { Color = "#95F9E6", Text = "요" },
            new() { Color = "#99FAE7", Text = "!" },
            
        };
        Assert.True(contents.SequenceEqual(expect));

    }
}