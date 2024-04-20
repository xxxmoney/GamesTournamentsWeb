namespace GamesTournamentsWeb.Infrastructure.Dto.Users;

public class AccountInfo
{
    public int MatchesPlayed { get; set; }
    public decimal WinRateRatio { get; set; }
    public int WinCount { get; set; }
    public int LossCount { get; set; }
}