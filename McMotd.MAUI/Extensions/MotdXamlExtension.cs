using McMotd.MAUI.View;
using McMotd.Utils;

namespace McMotd.MAUI.Extensions;

public static class MotdXamlExtension
{
    public static ContentView ToXaml(this Motd motd,string RawMotd) {
        return new McMotdView(motd.components);
    }
        
}