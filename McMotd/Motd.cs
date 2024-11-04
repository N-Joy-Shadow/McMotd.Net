using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Model;
using McMotd.Options;
using McMotd.Utils;

namespace McMotd;

public class Motd {
    public string motd { get; set; }
    public MotdOption option { get; set; }
    public MotdComponents components { get; set; }
    
    public Motd(string motd) : this(motd, new MotdOption()) { }
    public Motd(string motd, MotdOption option) {
        this.motd = motd;
        this.option = option;
    }
    
    public static implicit operator Motd(string motd) {
        if (motd is null)
            throw new Exception("motd is null");
        return new (motd);
    }
    
    private List<MotdComponent> parseMotd() {
        if (this.IsJson()) {
            var components = JsonSerializer.Deserialize<RawMotd>(this.rawMotd).ToMotdComponents();
            return components;
        }
        else {
            if(this.ContainSectionSign())
                return new SectionSignParser().parse(this);
            else {
                return new List<MotdComponent> { new MotdComponent { Text = this.motd } };
            }
        }
    }
    #region Private Section
    private MotdComponents ParseMotd() {
        if (this.IsJson()) {
            var aa =  JsonSerializer.Deserialize<Queue<Model.MotdComponent>>(this.motd);
            return new MotdComponents() {
                Components = aa
            };
        }
        else {
            if (this.ContainSectionSign()) {
                return "";
            }
            else {
                return "";
            }
        }
    }
    
    
    private bool ContainSectionSign() {
        return this.motd.Contains("§");
    }
    private bool IsJson()
    {
        string input = this.motd;
        input = input.Trim();
        return (input.StartsWith("{") && input.EndsWith("}")) || 
               (input.StartsWith("[") && input.EndsWith("]"));
    }
    #endregion
}