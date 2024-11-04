using System.Text.Json.Serialization;

namespace McMotd.Model;

public class JsonMotd {
    [JsonPropertyName("extra")]
    public List<JsonMotdExtra>? Extra { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public class JsonMotdExtra {
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("bold")]
    public bool? Bold { get; set; }

    [JsonPropertyName("italic")]
    public bool? Italic { get; set; }
}