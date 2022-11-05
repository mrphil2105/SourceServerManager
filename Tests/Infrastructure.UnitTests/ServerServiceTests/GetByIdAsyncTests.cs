namespace SourceServerManager.Infrastructure.UnitTests.ServerServiceTests;

public class GetByIdAsyncTests
{
    [Theory]
    [InfrastructureData]
    public async Task GetByIdAsync_ReturnsMatchingServer_GivenValidId([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();

        var dto = await serverService.GetByIdAsync(server.Id);

        dto.Should()
            .BeEquivalentTo(server);
    }

    [Theory]
    [InfrastructureData]
    public async Task GetByIdAsync_ReturnsNull_GivenInvalidId([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();

        var dto = await serverService.GetByIdAsync(server.Id + 1);

        dto.Should()
            .BeNull();
    }
}
