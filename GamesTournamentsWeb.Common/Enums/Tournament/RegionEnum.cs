using System.ComponentModel;

namespace GamesTournamentsWeb.Common.Enums.Tournament;

public enum RegionEnum
{
    [Description("europe")]
    Europe = 1,
    [Description("north_america")]
    NorthAmerica = 2,
    [Description("south_america")]
    SouthAmerica = 3,
    [Description("asia")]
    Asia = 4,
}
