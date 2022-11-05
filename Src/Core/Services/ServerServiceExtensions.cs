using SourceServerManager.Core.Data;

namespace SourceServerManager.Core.Services;

public static class ServerServiceExtensions
{
    public static async Task<Result<int>> CreateOrUpdateAsync(this IServerService serverService, int id,
        ServerCreateDto dto, CancellationToken cancellationToken = default)
    {
        if (id == 0)
        {
            return await serverService.CreateAsync(dto, cancellationToken);
        }

        var detailsDto = await serverService.GetByIdAsync(id, cancellationToken);

        if (detailsDto == null)
        {
            return await serverService.CreateAsync(dto, cancellationToken);
        }

        var updateDto = new ServerUpdateDto(id, dto.Hostname, dto.DirectoryName, dto.StartupMap, dto.MaxPlayerCount,
            dto.Address, dto.Port, dto.LoginToken, detailsDto.LastSteamCmdRun, detailsDto.LastSrcdsRun);
        var result = await serverService.UpdateAsync(updateDto, cancellationToken);

        return Result<int>.FromResult(result, id);
    }
}
