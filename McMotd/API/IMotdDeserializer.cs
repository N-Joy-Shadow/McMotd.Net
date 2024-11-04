using McMotd.Model;

namespace McMotd.API;

public interface IMotdDeserializer {
    MotdComponents Deserialize(string RawMotd);
}