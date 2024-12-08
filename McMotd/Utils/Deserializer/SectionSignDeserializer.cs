using McMotd.Data;
using McMotd.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using McMotd.API;
using McMotd.Model;
using McMotd.Utils;
using McMotd.Extension;
namespace McMotd.Utils.Deserializer;

public class SectionSignDeserializer : IMotdDeserializer {
    private const string SIGN = "§";
    private const string LineBreakSIGN = "§z";
    
    private static readonly string[] LineBreaks = new[] { "\\r\\n", "\\n", "\\r" };

    private MotdOption _option;

    public SectionSignDeserializer(MotdOption option) {
        this._option = option;
    }
    
    //TODO : replace new simple variable name
    public MotdComponents Deserialize(string RawMotd) {
        if(RawMotd.StartsWith("\"") && RawMotd.EndsWith("\""))
            RawMotd = RawMotd[1..^1];
        


        //전 처리 끝
        MotdComponents motd = new();

        if (!RawMotd.StartsWith(SIGN))
            motd.Add(new() {
                Text = RawMotd.Split(SIGN)[0]
            });
        
        
        var matches = McRegex.Pattern.Matches(RawMotd);
        foreach (Match match in matches) { 
            MotdComponent component = new();
            //Full value
            var text = match.Groups[5].Value;
            string afterText = null;
            
            //이부분 나중에 보완
            if (LineBreaks.Any(text.Contains)) { 
                var splitedText = text.Split(LineBreaks, StringSplitOptions.None);
                text = splitedText.FirstOrDefault() ?? string.Empty; // 첫 번째 요소 또는 빈 문자열
                afterText = (splitedText.Length > 1 ? splitedText[1] : string.Empty)
                    .Replace(LineBreakSIGN, string.Empty);
                component.LineBreak = !_option.Options.Contains(MotdParsingOption.NoLineBreak);
            }
            component.Text = text;

            
            
            //first section sign
            var sectionSign = match.Groups[2].Value;
            component.ParseSectionSign(sectionSign);
            //second section sign
            var secondSectionSign = match.Groups[4].Value;
            component.ParseSectionSign(secondSectionSign);

            motd.Add(component);
            
            if(!string.IsNullOrEmpty(afterText))
                motd.Add(new MotdComponent() {
                    Text = afterText
                });
        }

        return motd;
    }

    private void PreOptionTask() {
        
    }
}
