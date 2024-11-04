using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Deserializer;
using McMotd.Enum;
using McMotd.Model;
using McMotd.Utils;

namespace McMotd;

public class MotdParser {
    public string ToHtml(string RawMotd) {
        var contents = this.deserialize(RawMotd);
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<div class=""mcmotd-container"">");
        foreach (var content in contents) {
            sb.Append("<span");
            sb.Append($" style=\"color:{content.Color};");
            sb.Append(HtmlStyle(content.TextFormatting));
            sb.Append("\">");
            if (content.LineBreak) sb.Append("<br/>");
            sb.Append(content.Text.Replace(" ", "&nbsp;"));
            sb.Append("</span>");
        }
        sb.Append("</div>");
        return sb.ToString();
    }

    private string HtmlStyle(HashSet<MotdTextFormat> TextFormats) {
        StringBuilder sb = new StringBuilder();
        foreach (var TextFormat in TextFormats) {
            sb.Append(" ");
            switch (TextFormat) {
                case MotdTextFormat.Bold:
                    sb.Append("font-weight : bolder;");
                    break;
                case MotdTextFormat.Italic:
                    sb.Append("font-style : italic;");
                    break;
                case MotdTextFormat.Underline:
                    sb.Append("text-decoration : underline;");
                    break;
                case MotdTextFormat.Striktethrough:
                    sb.Append("text-decoration : line-through;");
                    break;
                default:
                    break;
            }

        }

        return sb.ToString();
    }
    public List<MotdContent> deserialize(string RawMotd) {
        RawMotd = new StringUtilsBuilder()
            .setString(RawMotd)
            .QuotePlace()
            .EscapeCharacterReplace()
            .ToJsonObjectString()
            .build();


        var option = new JsonSerializerOptions();

        var motdOption = new HashSet<MotdParsingOption>();
        motdOption.Add(MotdParsingOption.Trim);
        motdOption.Add(MotdParsingOption.NoLineBreak);

        option.Converters.Add(new MotdDeserializer(motdOption));
        return JsonSerializer.Deserialize<MotdContents>(RawMotd, option).Contents;
    }

    
    private string LineBreakSign = "§z";
    public MotdComponents parse(string motd, HashSet<MotdParsingOption> option) {
        optionSetup(option);
        
        motd  = McRegex.stripPattern.Replace(motd,LineBreakSign);
        var matches = McRegex.pattern.Matches(motd);

        List<MotdComponent> contents = new();

        foreach (Match item in matches) {
            var content = new MotdComponent();
            if (!item.Value.StartsWith("§")) {
                content.Text = item.Value;
                contents.Add(content);
                continue;
            }

            //Full value
            content.Text = item.Groups[5].Value;
            
            //first section sign
            var sectionCode = item.Groups[2].Value;
            //second section sign
            var secondSectionCode = item.Groups[4].Value;
            codeParser(sectionCode, ref content);
            
            if(!string.IsNullOrEmpty(secondSectionCode))
                codeParser(secondSectionCode, ref content);
            
            contents.Add(content);
        }

        return new MotdComponents();
    }

    public void optionSetup(HashSet<MotdParsingOption> option) {
        LineBreakSign = option.Contains(MotdParsingOption.NoLineBreak) ? "§z" : string.Empty;
    }
    
    
    
    private void codeParser(string code,ref MotdComponent motd)
    {
        try {
            switch (code) {
                case "k":
                case "l":
                case "m":
                case "n":
                case "o":
                case "r":
                case "x":
                    motd.TextFormatting.Add(MotdData.TextFormatDict[code]);
                    break;
                case "z":
                    motd.LineBreak = true;
                    break;
                default:
                    motd.Color = MotdData.ColorDict[code];
                    break;
            }
        }
        catch(Exception E) {
            Debug.WriteLine(E);
        }
    }
}
