namespace SourceServerManager.Core.Data;

public record ServerCreateDto(SourceGame Game, string Hostname, string DirectoryName, string StartupMap,
    int MaxPlayerCount, string Address, int Port, string? LoginToken);
