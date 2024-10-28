using SmoothStrike.Domain.Constants;

namespace SmoothStrike.Domain.Resources;

[Resource(PublicName = "match-results")]
public class MatchResult : Identifiable<string>
{

    [Attr]
    public ResultStatus Status { get; set; }

    [Attr]
    public int? Round { get; set; }

    [Attr]
    public int? Position { get; set; }

    [Attr]
    public MatchInternalResult Result { get; set; }

    [Attr]
    public MatchScore Score { get; set; }

    [Attr]
    public MatchScore Penalties { get; set; }

    [Attr]
    public string Description { get; set; }

    [Attr]
    public string Timestamp { get; set; }

    [HasOne]
    public Match Match { get; set; }

    [HasOne]
    public Competitor HomeCompetitor { get; set; }

    [HasOne]
    public Competitor AwayCompetitor { get; set; }

    public override string ToString()
    {
        return $"MatchResult{{Id='{Id}', Status={Status}, Round={Round}, Result={Result}, Score={Score}, Penalties={Penalties}, Description='{Description}', Timestamp='{Timestamp}'}}";
    }
}
