using System.Text.Json;
using McMotd.Data;
using McMotd.Enum;
using McMotd.Model;

namespace McMotd.Extension;

public static class MotdComponentParsingExtension {
    public static void ParseSectionSign(this MotdComponent component, string? sectionSign) {
        if (sectionSign is null)
            return;
        
        switch (sectionSign) {
            case "k":
            case "l":
            case "m":
            case "n":
            case "o":
            case "r":
            case "x":
                component.TextFormatting.Add(MotdData.TextFormatDict[sectionSign]);
                break;
            case "z":
                component.LineBreak = true;
                break;
            default:
                component.Color = MotdData.ColorDict[sectionSign];
                break;
        }
    }
    private static bool nextLineBreak = false;
    public static void ParseJsonObject(this MotdComponent component, JsonProperty property,MotdOption option) {
        var value = property.Value;
        switch (property.Name) {
            case "color":
                string color = value.GetString() ?? "white";
                component.Color = color.StartsWith("#") ? color : MotdData.ColorDict[color];
                break;
            case "bold": 
                if (value.GetBoolean()) component.TextFormatting.Add(MotdTextFormat.Bold); 
                break;
            case "italic": 
                if (value.GetBoolean()) component.TextFormatting.Add(MotdTextFormat.Italic); 
                break; 
            case "text": 
                var text = value.GetString();
                if (nextLineBreak) 
                { 
                    component.LineBreak = true; 
                    nextLineBreak = false;
                } 
                if (text.Contains("§z")) 
                { 
                    text = text.Replace("§z", "").Replace("§x",""); 
                    nextLineBreak = true;
                } 
                component.Text = string.IsNullOrEmpty(text) ? " " : text;
                break;
        }
    }
    
}