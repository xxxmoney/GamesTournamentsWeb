using GamesTournamentsWeb.DataAccess.Models.Games;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using GamesTournamentsWeb.DataAccess.Models.Users;
using Microsoft.EntityFrameworkCore;
using Stream = GamesTournamentsWeb.DataAccess.Models.Tournaments.Stream;

namespace GamesTournamentsWeb.DataAccess.Contexts;

public class WebContext : DbContext
{
    private readonly string connectionString;

    public WebContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Prize> Prizes { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Stream> Streams { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TournamentPlayer> TournamentPlayers { get; set; }
    public DbSet<TournamentPlayerStatus> TournamentPlayerStatuses { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(game =>
        {
            game.HasOne(e => e.Genre)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.GenreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            game.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            game.Property(e => e.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(1000);

        });
        
        modelBuilder.Entity<Genre>(genre =>
        {
            genre.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Tournament>(tournament =>
        {
            tournament.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            tournament.HasOne(e => e.Game)
                .WithMany(e => e.Tournaments)
                .HasForeignKey(e => e.GameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournament.HasOne(e => e.Platform)
                .WithMany(e => e.Tournaments)
                .HasForeignKey(e => e.PlatformId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournament.HasMany(e => e.Regions)
                .WithMany(e => e.Tournaments);

            tournament.Property(e => e.StartDate)
                .IsRequired();

            tournament.Property(e => e.EndDate)
                .IsRequired(false);
            
            tournament.Property(e => e.Infos)
                .IsRequired(true)
                .HasMaxLength(-1);
            
            tournament.Property(e => e.Rules)
                .IsRequired(true)
                .HasMaxLength(-1);
            
            tournament.Property(e => e.Settings)
                .IsRequired(true)
                .HasMaxLength(-1);

            tournament.HasMany(e => e.Prizes)
                .WithOne(e => e.Tournament)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournament.HasMany(e => e.Matches)
                .WithOne(e => e.Tournament)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            tournament.HasMany(e => e.Streams)
                .WithOne(e => e.Tournament)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournament.HasMany(e => e.Players)
                .WithOne(e => e.Tournament)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournament.HasMany(e => e.Admins)
                .WithMany(e => e.AdminTournaments);
        });
        
        modelBuilder.Entity<TournamentPlayer>(tournamentPlayer =>
        {
            tournamentPlayer.HasOne(e => e.Tournament)
                .WithMany(e => e.Players)
                .HasForeignKey(e => e.TournamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournamentPlayer.HasOne(e => e.Account)
                .WithMany(e => e.TournamentPlayers)
                .HasForeignKey(e => e.AccountId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            tournamentPlayer.Property(e => e.GameUsername)
                .IsRequired()
                .HasMaxLength(100);

            tournamentPlayer.HasOne(e => e.Status)
                .WithMany(e => e.TournamentPlayers)
                .HasForeignKey(e => e.StatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<TournamentPlayerStatus>(tournamentPlayerStatus =>
        {
            tournamentPlayerStatus.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<Prize>(prize =>
        {
            prize.Property(e => e.Place)
                .IsRequired();

            prize.Property(e => e.Amount)
                .IsRequired();

            prize.HasOne(e => e.Currency)
                .WithMany(e => e.Prizes)
                .HasForeignKey(e => e.CurrencyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            prize.HasOne(e => e.Tournament)
                .WithMany(e => e.Prizes)
                .HasForeignKey(e => e.TournamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Stream>(stream =>
        {
            stream.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            stream.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(1000);

            stream.HasOne(e => e.Tournament)
                .WithMany(e => e.Streams)
                .HasForeignKey(e => e.TournamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Team>(team =>
        {
            team.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<Match>(match =>
        {
            match.Property(e => e.StartDate)
                .IsRequired();

            match.Property(e => e.EndDate)
                .IsRequired(false);

            match.HasOne(e => e.Tournament)
                .WithMany(e => e.Matches)
                .HasForeignKey(e => e.TournamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.NextMatch)
                .WithOne()
                .HasForeignKey<Match>(m => m.NextMatchId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.PreviousMatch)
                .WithOne()
                .HasForeignKey<Match>(m => m.PreviousMatchId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            
            match.HasOne(e => e.FirstTeam)
                .WithMany(e => e.FirstTeamMatches)
                .HasForeignKey(e => e.FirstTeamId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            
            match.HasOne(e => e.SecondTeam)
                .WithMany(e => e.SecondTeamMatches)
                .HasForeignKey(e => e.SecondTeamId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Platform>(platform =>
        {
            platform.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<Region>(region =>
        {
            region.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<Account>(account =>
        {
            account.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100);

            account.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            account.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);

            account.HasOne(e => e.Role)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            account.Property(e => e.CreatedAt)
                .IsRequired();

            account.Property(e => e.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(1000);
        });
        
        modelBuilder.Entity<Role>(role =>
        {
            role.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<Currency>(currency =>
        {
            currency.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}