namespace SourceServerManager.Infrastructure.UnitTests.ServerServiceTests;

public class UpdateAsyncTests
{
    [Theory]
    [InfrastructureData]
    public async Task UpdateAsync_UpdatesServer_GivenDetails([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService, ServerUpdateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();
        dto = dto with { Id = server.Id };

        var result = await serverService.UpdateAsync(dto);

        result.Success.Should()
            .BeTrue();
    }

    [Theory]
    [InfrastructureData]
    public async Task UpdateAsync_UpdatesToMatchingServer_GivenDetails([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService, ServerUpdateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();
        dto = dto with { Id = server.Id };

        await serverService.UpdateAsync(dto);

        var updatedServer = await dbContext.Servers.FindAsync(dto.Id);
        updatedServer.Should()
            .BeEquivalentTo(dto);
    }

    [Theory]
    [InfrastructureData]
    public async Task UpdateAsync_ReturnsError_GivenInvalidId([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService, ServerUpdateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();
        dto = dto with { Id = server.Id + 1 };

        var result = await serverService.UpdateAsync(dto);

        result.Success.Should()
            .BeFalse();
        result.Message.Should()
            .Be("The specified server could not be found.");
    }

    [Theory]
    [InfrastructureData]
    public async Task UpdateAsync_ReturnsError_GivenDuplicateDirectoryName([Frozen] AppDbContext dbContext,
        Server firstServer, Server secondServer, ServerService serverService, ServerUpdateDto dto)
    {
        dbContext.Servers.AddRange(firstServer, secondServer);
        await dbContext.SaveChangesAsync();
        dto = dto with { Id = secondServer.Id, DirectoryName = firstServer.DirectoryName };

        var result = await serverService.UpdateAsync(dto);

        result.Success.Should()
            .BeFalse();
        result.Message.Should()
            .Be("The specified directory name already exists for another server.");
    }
}
