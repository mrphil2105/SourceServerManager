namespace SourceServerManager.Infrastructure.UnitTests.ServerServiceTests;

public class DeleteAsyncTests
{
    [Theory]
    [InfrastructureData]
    public async Task DeleteAsync_DeletesServer_GivenValidId([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();

        var result = await serverService.DeleteAsync(server.Id);

        result.Success.Should()
            .BeTrue();
    }

    [Theory]
    [InfrastructureData]
    public async Task DeleteAsync_ReturnsError_GivenInvalidId([Frozen] AppDbContext dbContext, Server server,
        ServerService serverService)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();

        var result = await serverService.DeleteAsync(server.Id + 1);

        result.Success.Should()
            .BeFalse();
        result.Message.Should()
            .Be("The specified server could not be found.");
    }
}
