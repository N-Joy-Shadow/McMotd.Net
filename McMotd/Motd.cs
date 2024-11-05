using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Deserializer;
using McMotd.Model;
using McMotd.Enum;
using McMotd.Utils;

namespace McMotd;

public class Motd {
    public string RawMotd { get; }
    public MotdOption Option { get; set; }
    private MotdComponents components { get; set; }
    
    public Motd(string motd) {
        this.RawMotd = motd;
        this.ParseMotd();
    }
    public static implicit operator Motd(string motd) {
        return new (motd);
    }
    #region Override Function Section
    public override string ToString() {
        return this.RawMotd;
    }
    #endregion
    #region Private Function Section

    private void ParseMotd() {
        //hmm.. using singleton not bad?
        //temp code
        components = new MotdDeserializer(Option).Deserialize(this.RawMotd);
    }
    #endregion
}