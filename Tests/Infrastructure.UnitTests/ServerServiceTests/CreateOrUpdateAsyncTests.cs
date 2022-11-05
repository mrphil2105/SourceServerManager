using SourceServerManager.Core.Services;

namespace SourceServerManager.Infrastructure.UnitTests.ServerServiceTests;

public class CreateOrUpdateAsyncTests
{
    [Theory]
    [InfrastructureData]
    public async Task CreateOrUpdateAsync_CreatesMatchingServer_GivenZeroIdAndDetails([Frozen] AppDbContext dbContext,
        ServerService serverService, ServerCreateDto dto)
    {
        var result = await serverService.CreateOrUpdateAsync(0, dto);

        var server = await dbContext.Servers.FindAsync(result.Data);
        server.Should()
            .BeEquivalentTo(dto);
    }

    [Theory]
    [InfrastructureData]
    public async Task CreateOrUpdateAsync_UpdatesToMatchingServer_GivenValidIdAndDetails(
        [Frozen] AppDbContext dbContext, Server server, ServerService serverService, ServerCreateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();

        await serverService.CreateOrUpdateAsync(server.Id, dto);

        var updatedServer = await dbContext.Servers.FindAsync(server.Id);
        updatedServer.Should()
            .BeEquivalentTo(dto, o => o.Excluding(d => d.Game));
    }

    [Theory]
    [InfrastructureData]
    public async Task CreateOrUpdateAsync_CreatesServer_GivenInvalidIdAndDetails([Frozen] AppDbContext dbContext,
        Server server, ServerService serverService, ServerCreateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();
        var id = server.Id + 1;

        var result = await serverService.CreateOrUpdateAsync(id, dto);

        result.Success.Should()
            .BeTrue();
        result.Data.Should()
            .Be(id);
    }

    [Theory]
    [InfrastructureData]
    public async Task CreateOrUpdateAsync_CreatesMatchingServer_GivenInvalidIdAndDetails(
        [Frozen] AppDbContext dbContext, Server server, ServerService serverService, ServerCreateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();
        var id = server.Id + 1;

        await serverService.CreateOrUpdateAsync(id, dto);

        var newServer = await dbContext.Servers.FindAsync(id);
        newServer.Should()
            .BeEquivalentTo(dto);
    }
}
