using McMotd.API;
using McMotd.Enum;
using McMotd.Model;

namespace McMotd.Deserializer;

public class PlainTextDeserializer: IMotdDeserializer {
    public PlainTextDeserializer(HashSet<MotdParsingOption> options) {
        
    }
    public MotdComponents Deserialize(string RawMotd) {
        throw new NotImplementedException();
    }
    
}