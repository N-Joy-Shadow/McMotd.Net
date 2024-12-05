using McMotd.Model;

namespace McMotd.API;

public interface IMotdDeserializer {
    /// <summary>
    /// Deserialize the raw Motd text
    /// </summary>
    /// <param name="RawMotd">Text로 적용된 Motd</param>
    /// <returns></returns>
    MotdComponents Deserialize(string RawMotd);
}