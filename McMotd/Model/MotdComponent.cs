using System.Text.Json;
using System.Text.Json.Serialization;
using McMotd.Data;
using McMotd.Enum;
using McMotd.Utils.Converter;
using McMotd.Utils.Deserializer;

namespace McMotd.Model;

public class MotdComponents {
    public List<MotdComponent> Components { get; set; } = new();
    
    #region Override Function
    public override bool Equals(object? obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }
        MotdComponents other = (MotdComponents)obj;   
        return this.Components.SequenceEqual(other.Components);
    }
    #endregion
}

public class MotdComponent {
    public string Color { get; set; } = "#808080";
    public string Text { get; set; }
    public HashSet<MotdTextFormat> TextFormatting { get; set; } = new();
    public bool LineBreak { get; set; } = false;


    
    #region Override Function
    public override bool Equals(object? obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }
        MotdComponent other = (MotdComponent)obj;
        return this.Color == other.Color && this.Text == other.Text && this.TextFormatting.SetEquals(other.TextFormatting) && this.LineBreak == other.LineBreak;
    }
    #endregion
}
