using GamesTournamentsWeb.DataAccess.Models.Users;

namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class TournamentComment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public DateTimeOffset CreateDate { get; set; }
}
