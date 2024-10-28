namespace SmoothStrike.Domain.Resources;
// Type: match-actions
[Resource(PublicName = "actions")]
public class MatchAction : Identifiable<string>
{
    [Attr]
    public Constants.Action Action { get; set; }

    [Attr]
    public int? Hitlevel { get; set; }

    [Attr]
    public int? Round { get; set; }

    [Attr]
    public string RoundTime { get; set; }

    [Attr]
    public int? Position { get; set; }

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
        return $"MatchAction{{Id='{Id}', Action={Action}, Round={Round}, Hitlevel={Hitlevel}, RoundTime='{RoundTime}', Position={Position}, Score={Score}, Penalties={Penalties}, Description='{Description}', Timestamp='{Timestamp}'}}";
    }
}
