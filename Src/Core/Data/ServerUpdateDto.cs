namespace SourceServerManager.Core.Data;

public record ServerUpdateDto(int Id, string Hostname, string DirectoryName, string StartupMap, int MaxPlayerCount,
    string Address, int Port, string? LoginToken, DateTimeOffset LastSteamCmdRun, DateTimeOffset LastSrcdsRun);
