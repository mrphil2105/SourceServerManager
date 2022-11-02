namespace SourceServerManager.Infrastructure.Data;

public class Server
{
    public Server(SourceGame game, string hostname, string directoryName, string startupMap, int maxPlayerCount,
        string address, int port)
    {
        Game = game;
        Hostname = hostname;
        DirectoryName = directoryName;
        StartupMap = startupMap;
        MaxPlayerCount = maxPlayerCount;
        Address = address;
        Port = port;
    }

    public int Id { get; set; }

    public SourceGame Game { get; set; }

    public string Hostname { get; set; }

    public string DirectoryName { get; set; }

    public string StartupMap { get; set; }

    public int MaxPlayerCount { get; set; }

    public string Address { get; set; }

    public int Port { get; set; }

    public string? LoginToken { get; set; }

    public DateTimeOffset LastSteamCmdRun { get; set; }

    public DateTimeOffset LastSrcdsRun { get; set; }
}
