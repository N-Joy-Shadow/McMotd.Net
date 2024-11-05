using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using McMotd.Data;
using McMotd.Model;
using McMotd.Enum;
using McMotd.Utils;
using McMotd.Utils.Serializer;
using McMotd.Utils.Deserializer;

namespace McMotd;

public class Motd {
    private MotdComponents _components;
    public string RawMotd { get; }
    public MotdOption Option { get; set; }
    //wanna set private 
    public MotdComponents components { get; set; }
    
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