using McMotd.Utils;

namespace McMotd {
    public static class MotdParserRazorExtension
    {
        public static List<MotdContent> ToRazor(this MotdParser parser,string RawMotd)
        {
            return parser.deserialize(RawMotd);
        }
    }


}