using SourceServerManager.Core.Data;

namespace SourceServerManager.Core.Services;

public interface IServerService
{
    Task<ServerDetailsDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ServerDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Result<int>> CreateAsync(ServerCreateDto dto, CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(ServerUpdateDto dto, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
