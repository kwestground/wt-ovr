namespace SmoothStrike.Domain.Resources;

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

    public string ParticipantId { get; set; }

    public override string ToString()
    {
        return $"Competitor{{Id='{Id}', CompetitorType='{CompetitorType}', PrintName='{PrintName}', PrintInitialName='{PrintInitialName}', " +
               $"TvName='{TvName}', TvInitialName='{TvInitialName}', ScoreboardName='{ScoreboardName}', Rank={Rank}, Seed={Seed}, Country='{Country}', " +
               $"Matches={Matches}, Organization={Organization}, Event={Event}, Participant={Participant}}}";
    }
}
