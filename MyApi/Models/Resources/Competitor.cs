namespace Models;

[Resource(PublicName = "competitors")]
public class Competitor : Identifiable<string>
{
    public override string Id { get; set; }

    [Attr]
    public string CompetitorType { get; set; }

    [Attr]
    public string PrintName { get; set; }

    [Attr]
    public string PrintInitialName { get; set; }

    [Attr]
    public string TvName { get; set; }

    [Attr]
    public string TvInitialName { get; set; }

    [Attr]
    public string ScoreboardName { get; set; }

    [Attr]
    public int? Rank { get; set; }

    [Attr]
    public int? Seed { get; set; }

    [Attr]
    public string Country { get; set; }

    [HasMany]
    public HashSet<Match> Matches { get; set; }

    [HasOne]
    public Organization Organization { get; set; }

    [HasOne]
    public Event Event { get; set; }

    [HasOne]
    public Participant Participant { get; set; }

    // Default constructor
    public Competitor() { }

    // Parameterized constructor
    public Competitor(string id, string competitorType, string printName, string printInitialName, string tvName,
                      string tvInitialName, string scoreboardName, int? rank, int? seed, string country,
                      HashSet<Match> matches, Organization organization, Event eventEntity, Participant participant)
    {
        Id = id;
        CompetitorType = competitorType;
        PrintName = printName;
        PrintInitialName = printInitialName;
        TvName = tvName;
        TvInitialName = tvInitialName;
        ScoreboardName = scoreboardName;
        Rank = rank;
        Seed = seed;
        Country = country;
        Matches = matches;
        Organization = organization;
        Event = eventEntity;
        Participant = participant;
    }

    public override string ToString()
    {
        return $"Competitor{{Id='{Id}', CompetitorType='{CompetitorType}', PrintName='{PrintName}', PrintInitialName='{PrintInitialName}', " +
               $"TvName='{TvName}', TvInitialName='{TvInitialName}', ScoreboardName='{ScoreboardName}', Rank={Rank}, Seed={Seed}, Country='{Country}', " +
               $"Matches={Matches}, Organization={Organization}, Event={Event}, Participant={Participant}}}";
    }
}
