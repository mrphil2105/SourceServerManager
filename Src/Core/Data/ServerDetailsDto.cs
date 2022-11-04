namespace SourceServerManager.Core.Data;

public record ServerDetailsDto(int Id, SourceGame Game, string Hostname, string DirectoryName, string StartupMap,
    int MaxPlayerCount, string Address, int Port, string? LoginToken, DateTimeOffset LastSteamCmdRun,
    DateTimeOffset LastSrcdsRun);
