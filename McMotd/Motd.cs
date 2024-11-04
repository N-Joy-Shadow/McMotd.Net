using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Model;
using McMotd.Enum;
using McMotd.Utils;

namespace McMotd;

public class Motd {
    public string RawMotd { get; }
    public HashSet<MotdParsingOption> Options { get; set; }
    private MotdComponents components { get; set; }
    
    public Motd(string motd) {
        this.RawMotd = motd;
    }
    public static implicit operator Motd(string motd) {
        return new (motd);
    }
    #region Override Function Section
    public override string ToString() {
        return this.RawMotd;
    }
    #endregion
    //여기 부분을 딴 코드로 이동
    #region Private Section
    private MotdComponents ParseMotd() {
        if (this.IsJson()) {
            var aa = JsonSerializer.Deserialize<List<Model.MotdComponent>>(this.RawMotd);
            return new MotdComponents() {
                Components = aa
            };
        }
        else {
            if (this.ContainSectionSign()) {
                //뭔가 별론데
                return new SectionSignParser().parse(this);
            }
            else {
                return new MotdComponents() {
                    Components = new List<MotdComponent>(new Model.MotdComponent[] {
                        new Model.MotdComponent() {
                            Text = this.RawMotd
                        }
                    })
                };
            }
        }
    }
    private bool ContainSectionSign() {
        return this.RawMotd.Contains("§");
    }
    private bool IsJson()
    {
        string input = this.RawMotd;
        input = input.Trim();
        return (input.StartsWith("{") && input.EndsWith("}")) || 
               (input.StartsWith("[") && input.EndsWith("]"));
    }
    #endregion
}