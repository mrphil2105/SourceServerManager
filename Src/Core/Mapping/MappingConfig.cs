using Mapster;

namespace SourceServerManager.Core.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.Default.MapToConstructor(true);
    }
}
