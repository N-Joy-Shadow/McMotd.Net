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
    private readonly string SIGN = "§";

    private MotdOption _option;

    public SectionSignDeserializer(MotdOption option) {
        this._option = option;
    }
    
    //TODO : replace new simple variable name
    public MotdComponents Deserialize(string rawMotd) {
        //not bad code..
        if(_option.Options.Contains(MotdParsingOption.NoLineBreak)) 
            rawMotd = McRegex.lineBreakPattern.Replace(rawMotd.Replace(Environment.NewLine,string.Empty),string.Empty);
        else
            rawMotd = McRegex.lineBreakPattern.Replace(rawMotd.Replace(Environment.NewLine,$"{SIGN}z"),$"{SIGN}z");


        //전 처리 끝
        MotdComponents motd = new();

        if (!rawMotd.StartsWith(SIGN))
            motd.Components.Add(new() {
                Text = rawMotd.Split(SIGN)[0]
            });
        
        
        var matches = McRegex.pattern.Matches(rawMotd);
        foreach (Match match in matches) {
            MotdComponent component = new();
            //Full value
            component.Text = match.Groups[5].Value;

            //first section sign
            var sectionSign = match.Groups[2].Value;
            component.ParseSectionSign(sectionSign);
            //second section sign
            var secondSectionSign = match.Groups[4].Value;
            component.ParseSectionSign(secondSectionSign);

            motd.Components.Add(component);
        }

        return motd;
    }

    private void PreOptionTask() {
        
    }
}
