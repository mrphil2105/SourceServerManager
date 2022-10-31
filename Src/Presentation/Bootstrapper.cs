using MvvmElegance;
using SourceServerManager.Presentation.Modules;
using SourceServerManager.ViewModels;

namespace SourceServerManager.Presentation;

public class Bootstrapper : AutofacBootstrapper<MainViewModel>
{
    protected override void ConfigureServices(ContainerBuilder builder)
    {
        builder.RegisterAssemblyModules(typeof(ViewModule).Assembly);
    }
}
