using System.ComponentModel;

namespace SourceServerManager.Core;

public enum SourceGame
{
    [Description("Team Fortress 2")]
    Tf2,
    [Description("Counter-Strike: Global Offensive")]
    Csgo,
    [Description("Counter-Strike: Source")]
    Css,
    [Description("Left 4 Dead 2")]
    L4d2
}
