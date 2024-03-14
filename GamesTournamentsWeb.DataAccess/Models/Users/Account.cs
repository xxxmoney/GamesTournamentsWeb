﻿using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using GamesTournamentsWeb.DataAccess.Models.Users;

namespace GamesTournamentsWeb.DataAccess.Models.Users;

public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Tournament> AdminTournaments { get; set; }
    public ICollection<TournamentPlayer> TournamentPlayers { get; set; }
}
