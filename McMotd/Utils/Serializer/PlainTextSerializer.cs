using System.Text;
using McMotd.API;
using McMotd.Model;

namespace McMotd.Utils.Serializer;

public class PlainTextSerializer: IMotdSerializer<string> {
    public static PlainTextSerializer Default { get; } = new PlainTextSerializer();
    public string Serialize(MotdComponents motdComponents) {
        StringBuilder sb = new StringBuilder();
        foreach (var component in motdComponents) {
            sb.Append(component.Text);
        }
        return sb.ToString();
    }
}