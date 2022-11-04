using Microsoft.EntityFrameworkCore.Design;

namespace SourceServerManager.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlite("Data Source=App.db");

        return new AppDbContext(builder.Options);
    }
}
