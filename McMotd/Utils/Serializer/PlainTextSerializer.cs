using System.Text;
using McMotd.API;
using McMotd.Model;

namespace McMotd.Utils.Serializer;

public class PlainTextSerializer: IMotdSerializer<string> {
    public string Serialize(MotdComponents motdComponents) {
        StringBuilder sb = new StringBuilder();
        foreach (var component in motdComponents.Components) {
            sb.Append(component.Text);
        }
        return sb.ToString();
    }
}