using Microsoft.EntityFrameworkCore;
using SmoothStrike.Domain;
using SmoothStrike.Domain.Constants;
using SmoothStrike.Domain.Resources;

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

        modelBuilder.Entity<Competitor>()
            .HasOne(e => e.Participant);

        modelBuilder.Entity<Competitor>()
            .Navigation(e => e.Participant)
            .AutoInclude();

        Seed(modelBuilder);
    }

    private void Seed(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Competitor>().HasData(new Competitor
        {
            Id = "SWE-1001",
            CompetitorType = "A",
            ScoreboardName = "K. Westgrund (SB)",
            TvName = "K. WEST (TV)",
            PrintName  = "Kenny Westermark (PRINT)",
            PrintInitialName = "KW",
            Country = "SWE"
        }, new Competitor
        {
            Id = "SWE-1002",
            CompetitorType = "A",
            ScoreboardName = "A. Boström (SB)",
            TvName = "A. BOST (TV)",
            PrintName  = "Andreas Boström (PRINT)",
            PrintInitialName = "AB",
            Country = "SWE"
        });

        modelBuilder.Entity<Timing>().HasData(new Timing
        {
            Id = 1,
            Round = "2:00",
            Rest = "1:00",
            Injury = "1:00"
        });

        modelBuilder.Entity<Thresholds>().HasData(new Thresholds
        {
            Id = 1,
            Body = 10,
            Head = 0
        });

        modelBuilder.Entity<MatchConfiguration>().HasData(new MatchConfiguration
        {
            Id = "M1",
            Rules = Rules.BestOf3,
            Rounds = 3,
            TimingId = 1,
            MaxDifference = 12
        });
        
        modelBuilder.Entity<Event>().HasData(new Event
        {
            Id = "E1",
            Discipline = "Taekwondo Kyorugi",
            Division = "Seniors",
            Gender = Gender.Male,
            Name = "Male -80 kg",
            WeightCategory = "M -80 kg",
            Role = Role.Athlete
        });


        modelBuilder.Entity<Match>().HasData(new Match
        {
            Id = "1",
            Mat = 1,
            Number = "1-1",
            Phase = Phase.F,
            HomeCompetitorId = "SWE-1001",
            AwayCompetitorId = "SWE-1002",
            MatchConfigurationId = "M1",
            EventId = "E1"
        });
    }
}