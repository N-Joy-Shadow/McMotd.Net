using McMotd.API;
using McMotd.Enum;
using McMotd.Model;

namespace McMotd.Deserializer;

public class MotdJsonDeserializer: IMotdDeserializer {
    public MotdJsonDeserializer(HashSet<MotdParsingOption> options) {
        
    }
    public MotdComponents Deserialize(string RawMotd) {
        throw new NotImplementedException();
    }
}