using System.Text.Json;
using McMotd.Data;
using McMotd.Enum;

namespace McMotd.Model;

public class MotdComponents {
    public List<MotdComponent> Components { get; set; } = new();
}
public class MotdComponent {
    public string Color { get; set; } = "#808080";
    public string Text { get; set; }
    public HashSet<MotdTextFormat> TextFormatting { get; set; } = new ();
    public bool LineBreak { get; set; } = false;



    //TODO: 나중에 Extension으로 빼기
    
}
