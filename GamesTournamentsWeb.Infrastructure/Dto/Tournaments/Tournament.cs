using GamesTournamentsWeb.Infrastructure.Dto.Games;
using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public int TeamSize { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public Platform Platform { get; set; }
    public ICollection<Region> Regions { get; set; } = new List<Region>();
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public string Info { get; set; }
    public string Rules { get; set; }
    public ICollection<Prize> Prizes { get; set; } = new List<Prize>();
    public ICollection<Match> Matches { get; set; } = new List<Match>();
    public ICollection<Stream> Streams { get; set; } = new List<Stream>();
    public int MinimumPlayers { get; set; }   
    public int MaximumPlayers { get; set; }   
    public bool AnyoneCanJoin { get; set; }   
    public ICollection<TournamentPlayer> Players { get; set; } = new List<TournamentPlayer>();
    public ICollection<Account> Admins { get; set; }  = new List<Account>();
}

