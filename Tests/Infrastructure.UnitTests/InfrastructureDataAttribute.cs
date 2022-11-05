using AutoFixture;
using EntityFrameworkCore.AutoFixture.Sqlite;
using Mapster;
using MapsterMapper;
using SourceServerManager.Core.Mapping;

namespace SourceServerManager.Infrastructure.UnitTests;

public class InfrastructureDataAttribute : AutoDataAttribute
{
    public InfrastructureDataAttribute() : base(CreateFixture)
    {
    }

    private static IFixture CreateFixture()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new IdPropertyOmitter());
        fixture.Customize(new SqliteCustomization());

        fixture.Register<IMapper>(() =>
        {
            var config = new TypeAdapterConfig();
            config.Scan(typeof(MappingConfig).Assembly);

            return new Mapper(config);
        });

        return fixture;
    }
}
