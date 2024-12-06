using McMotd.Utils;

namespace McMotd.Extension;

internal static class MotdStringExtension {
    internal static string ReplaceEscapeChracter(this String str, string replace) {
        McRegex.LineBreakPattern.Replace(str, replace);
        return str;
    }
}