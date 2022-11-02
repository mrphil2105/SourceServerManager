using System.Reflection;
using SourceServerManager.ViewModels;
using Module = Autofac.Module;

namespace SourceServerManager.Presentation.Modules;

public class ViewModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(MainViewModel).Assembly)
            .Where(t => t.Name.EndsWith("ViewModel"))
            .AsImplementedInterfaces()
            .AsSelf();
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("View"));
    }
}
