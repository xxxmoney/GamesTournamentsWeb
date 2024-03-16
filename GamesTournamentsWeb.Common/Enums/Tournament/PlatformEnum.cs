using System.ComponentModel;

namespace GamesTournamentsWeb.Common.Enums.Tournament;

public enum PlatformEnum
{
    [Description("pc")]
    Pc = 1,
    [Description("playstation")]
    Playstation = 2,
    [Description("xbox")]
    Xbox = 3,
}