using System.Diagnostics;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Options;
using McMotd.Utils;

namespace McMotd;

public class SectionSignParser {
    private string LineBreakSign = "§z";
    public List<MotdComponent> parse(Motd motd) {
        optionSetup(motd.option);

        var formattedMotd = optionPreTask(motd.rawMotd, motd.option);
        List<MotdComponent> contents = new();

        if (!motd.option.Stripped) {
            var firstGroup = McRegex.leadingWhitespacePattern.Match(formattedMotd).Groups;
            if (firstGroup.Count > 0) 
                contents.Add(new () { Text = firstGroup[0].Value});
        }
        
        
        var matches = McRegex.pattern.Matches(formattedMotd);

        
        
        foreach (Match item in matches) {
            var content = new MotdComponent();
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

        return contents;
    }

    private void optionSetup(MotdOption option) {
        LineBreakSign = option.LineBreak ? "§z" : string.Empty;
    }

    private string optionPreTask(string motd, MotdOption option ) {
        string motdQuotaionRemoved =  McRegex.QuotationPattern.Replace(motd, string.Empty);
        string motdStripped = option.Stripped ? motdQuotaionRemoved.Trim() : motdQuotaionRemoved;
        return  McRegex.lineBreakPattern.Replace(motdStripped,LineBreakSign);
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
