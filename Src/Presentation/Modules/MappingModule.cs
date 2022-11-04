using Mapster;
using MapsterMapper;
using SourceServerManager.Core.Mapping;

namespace SourceServerManager.Presentation.Modules;

public class MappingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register<IMapper>(_ =>
            {
                var config = new TypeAdapterConfig();
                config.Scan(typeof(MappingConfig).Assembly);

                return new Mapper(config);
            })
            .SingleInstance();
    }
}
