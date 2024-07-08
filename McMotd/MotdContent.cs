using McMotd.Deserializer;
using McMotd.Enum;
using System.Text.Json.Serialization;

namespace McMotd;
public class MotdContent
{
    public string Color { get; set; } = "#808080";
    public string Text { get; set; }
    public HashSet<TextFormatEnum> TextFormatting { get; set; } = new ();
    public bool LineBreak { get; set; } = false;
    
}


public class MotdContents
{
    [JsonConverter(typeof(MotdDeserializer))]
    public List<MotdContent> Contents { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (!(obj.GetType() == typeof(MotdContents))) return false;

        var targets = (MotdContents)obj;

        for (int i = 0; i < Contents.Count; i++)
        {
            var content = Contents[i];
            var target = targets.Contents[i];
            if (!content.Equals(target)) return false;
        }

        return true;
    }
}