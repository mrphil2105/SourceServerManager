namespace SourceServerManager.Infrastructure.UnitTests.ServerServiceTests;

public class CreateAsyncTests
{
    [Theory]
    [InfrastructureData]
    public async Task CreateAsync_CreatesServer_GivenDetails(ServerService serverService, ServerCreateDto dto)
    {
        var result = await serverService.CreateAsync(dto);

        result.Success.Should()
            .BeTrue();
        result.Data.Should()
            .Be(1);
    }

    [Theory]
    [InfrastructureData]
    public async Task CreateAsync_CreatesMatchingServer_GivenDetails([Frozen] AppDbContext dbContext,
        ServerService serverService, ServerCreateDto dto)
    {
        var result = await serverService.CreateAsync(dto);

        var server = await dbContext.Servers.FindAsync(result.Data);
        server.Should()
            .BeEquivalentTo(dto);
    }

    [Theory]
    [InfrastructureData]
    public async Task CreateAsync_ReturnsError_GivenDuplicateDirectoryName([Frozen] AppDbContext dbContext,
        Server server, ServerService serverService, ServerCreateDto dto)
    {
        dbContext.Servers.Add(server);
        await dbContext.SaveChangesAsync();
        dto = dto with { DirectoryName = server.DirectoryName };

        var result = await serverService.CreateAsync(dto);

        result.Success.Should()
            .BeFalse();
        result.Message.Should()
            .Be("The specified directory name already exists for another server.");
    }
}
