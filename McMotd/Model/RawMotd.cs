using System.Text.Json.Serialization;
using McMotd.Enum;

namespace McMotd.Model;
public class Extra
{
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("bold")]
    public bool? Bold { get; set; }

    [JsonPropertyName("italic")]
    public bool? Italic { get; set; }
    
    public MotdComponent ToMotdComponent() {
        var motdComponent = new MotdComponent {
            Color = this.Color,
            Text = this.Text
        };
        
        if (this.Bold.HasValue && this.Bold.Value) {
            motdComponent.TextFormatting.Add(MotdTextFormat.Bold);
        }
        if (this.Italic.HasValue && this.Italic.Value) {
            motdComponent.TextFormatting.Add(MotdTextFormat.Italic);
        }

        return motdComponent;
    }
    
}

public class RawMotd {
    [JsonPropertyName("extra")]
    public List<Extra>? Extra { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
    
    public List<MotdComponent> ToMotdComponents() {
        if(this.Extra is null || this.Extra.Count == 0)
            return new List<MotdComponent> { new MotdComponent { Text = this.Text } };
        return this.Extra.Select(x => x.ToMotdComponent()).ToList();
    }
}

