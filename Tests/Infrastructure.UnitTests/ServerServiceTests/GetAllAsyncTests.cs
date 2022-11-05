namespace SourceServerManager.Infrastructure.UnitTests.ServerServiceTests;

public class GetAllAsyncTests
{
    [Theory]
    [InfrastructureData]
    public async Task GetAllAsync_ReturnsAllServers_WithServers([Frozen] AppDbContext dbContext, List<Server> servers,
        ServerService serverService)
    {
        dbContext.Servers.AddRange(servers);
        await dbContext.SaveChangesAsync();

        var dtos = await serverService.GetAllAsync();

        dtos.Should()
            .BeEquivalentTo(servers, o => o.Excluding(s => s.LastSteamCmdRun)
                .Excluding(s => s.LastSrcdsRun));
    }

    [Theory]
    [InfrastructureData]
    public async Task GetAllAsync_ReturnsEmptyCollection_WithNoServers(ServerService serverService)
    {
        var dtos = await serverService.GetAllAsync();

        dtos.Should()
            .BeEmpty();
    }
}
