namespace SourceServerManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Server> Servers => Set<Server>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Server>()
            .Property(s => s.Game)
            .HasConversion<string>();

        builder.Entity<Server>()
            .Property(s => s.Hostname)
            .HasMaxLength(MaxHostnameLength);

        builder.Entity<Server>()
            .HasIndex(s => s.DirectoryName)
            .IsUnique();

        builder.Entity<Server>()
            .Property(s => s.DirectoryName)
            .HasColumnType("TEXT COLLATE NOCASE");

        builder.Entity<Server>()
            .Property(s => s.DirectoryName)
            .HasMaxLength(MaxFileNameLength);

        builder.Entity<Server>()
            .Property(s => s.StartupMap)
            .HasMaxLength(MaxFileNameLength);

        builder.Entity<Server>()
            .Property(s => s.Address)
            .HasMaxLength(MaxAddressLength);

        builder.Entity<Server>()
            .Property(s => s.LoginToken)
            .HasMaxLength(MaxLoginTokenLength);
    }
}
