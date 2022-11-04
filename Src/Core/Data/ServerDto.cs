namespace SourceServerManager.Core.Data;

public record ServerDto(int Id, SourceGame Game, string Hostname, string DirectoryName, string StartupMap,
    int MaxPlayerCount, string Address, int Port, string? LoginToken);
