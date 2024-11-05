using McMotd.Model;

namespace McMotd.API;

public interface IMotdSerializer<T> {
    T Serialize(MotdComponents motdComponents);
}