using System.Text.Json;
using McMotd.Data;
using McMotd.Enum;
using McMotd.Model;
using McMotd.Utils;

namespace McMotd.Extension;

public static class MotdComponentParsingExtension {
    public static void ParseSectionSign(this MotdComponent component, string? sectionSign) {
        if (string.IsNullOrEmpty(sectionSign))
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
            default:
                component.Color = MotdData.ColorDict[sectionSign];
                break;
        }
    }

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
                component.Text = string.IsNullOrEmpty(text) ? "" : text;
                break;
        }
    }
    
}