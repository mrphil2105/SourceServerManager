using Microsoft.EntityFrameworkCore;
using MvvmElegance;
using SourceServerManager.Infrastructure.Data;
using SourceServerManager.Presentation.Modules;
using SourceServerManager.ViewModels;

namespace SourceServerManager.Presentation;

public class Bootstrapper : AutofacBootstrapper<MainViewModel>
{
    protected override void ConfigureServices(ContainerBuilder builder)
    {
        builder.RegisterAssemblyModules(typeof(ViewModule).Assembly);
    }

    protected override void Launch()
    {
        using var dbContext = GetService<AppDbContext>();
        dbContext.Database.Migrate();

        base.Launch();
    }
}
