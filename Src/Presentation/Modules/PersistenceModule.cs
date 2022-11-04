using Microsoft.EntityFrameworkCore;
using SourceServerManager.Infrastructure.Data;

namespace SourceServerManager.Presentation.Modules;

public class PersistenceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(new DbContextOptionsBuilder<AppDbContext>().UseSqlite("Data Source=App.db")
            .Options);
        builder.RegisterType<AppDbContext>();
    }
}
