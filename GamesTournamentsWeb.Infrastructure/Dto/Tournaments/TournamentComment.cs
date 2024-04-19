namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class TournamentComment
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int AccountId { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreateDate { get; set; }
}
