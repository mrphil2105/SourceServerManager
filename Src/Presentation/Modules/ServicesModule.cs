using SourceServerManager.Infrastructure.Services;

namespace SourceServerManager.Presentation.Modules;

public class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(ServerService).Assembly)
            .Where(t => t.IsInNamespaceOf<ServerService>() && t.IsClass && !t.IsAbstract)
            .AsImplementedInterfaces();
    }
}
