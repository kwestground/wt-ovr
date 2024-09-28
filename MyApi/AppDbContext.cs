using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public DbSet<Competitor> Competitors => Set<Competitor>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<Match> Matchs => Set<Match>();

    public DbSet<MatchAction> MatchActions => Set<MatchAction>();

    public DbSet<MatchConfiguration> MatchConfigurations => Set<MatchConfiguration>();

    public DbSet<MatchRefereeAssignment> MatchRefereeAssignments => Set<MatchRefereeAssignment>();

    public DbSet<MatchResult> MatchResults => Set<MatchResult>();
    
    public DbSet<MedalWinner> MedalWinners => Set<MedalWinner>();

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<Participant> Participants => Set<Participant>();

    public DbSet<Session> Sessions => Set<Session>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeCompetitor)
            .WithMany()
            .HasForeignKey(m => m.HomeCompetitorId);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayCompetitor)
            .WithMany()
            .HasForeignKey(m => m.AwayCompetitorId);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Session)
            .WithMany(s => s.Matches);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Event)
            .WithMany(e => e.Matches);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.RefereeAssignment)
            .WithOne(r => r.Match)
            .HasForeignKey<Match>(r => r.RefereeAssignmentId);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.MatchConfiguration)
            .WithMany();

        modelBuilder.Entity<MatchResult>()
            .HasOne(mr => mr.Match)
            .WithMany(m => m.Results);

        modelBuilder.Entity<MatchResult>()
            .HasOne(mr => mr.HomeCompetitor)
            .WithMany();

        modelBuilder.Entity<MatchResult>()
            .HasOne(mr => mr.AwayCompetitor)
            .WithMany();

        modelBuilder.Entity<MatchRefereeAssignment>()
            .HasOne(mra => mra.Match)
            .WithOne(m => m.RefereeAssignment);

        modelBuilder.Entity<Session>()
            .HasMany(s => s.Matches)
            .WithOne(m => m.Session);

        modelBuilder.Entity<Event>()
            .HasMany(e => e.Matches)
            .WithOne(m => m.Event);

        modelBuilder.Entity<MatchConfiguration>()
            .Navigation(e => e.Timing)
            .AutoInclude();
            
        modelBuilder.Entity<MatchConfiguration>()
            .Navigation(e => e.GoldenPoint)
            .AutoInclude();
            
        modelBuilder.Entity<MatchConfiguration>()
            .Navigation(e => e.Thresholds)
            .AutoInclude();

        modelBuilder.Entity<MatchConfiguration>()
            .Navigation(e => e.VideoReplayQuota)
            .AutoInclude();
    }
}