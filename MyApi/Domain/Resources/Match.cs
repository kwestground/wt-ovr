using SmoothStrike.Domain.Constants;

namespace SmoothStrike.Domain.Resources;

[Resource(PublicName = "matches")]
public class Match : Identifiable<string>
{
    [Attr]
    public string Status { get; set; } // available

    [Attr]
    public int? Mat { get; set; }

    [Attr]
    public string Number { get; set; }

    [Attr]
    public Phase Phase { get; set; }

    [Attr]
    public MatchSchedule Schedule { get; set; }

    [Attr]
    public MatchInternalResult Result { get; set; }

    [Attr]
    public MatchScore Score { get; set; }

    [Attr]
    public MatchScore Penalties { get; set; }

    [Attr]
    public int? Round { get; set; }

    [Attr]
    public string RoundTime { get; set; }

    [HasOne]
    public Competitor HomeCompetitor { get; set; }

    public string HomeCompetitorId { get; set; }

    [HasOne]
    public Competitor AwayCompetitor { get; set; }

    public string AwayCompetitorId { get; set; }

    [HasOne]
    public Session Session { get; set; }

    [HasOne]
    public Event Event { get; set; }

    [HasOne]
    public MatchRefereeAssignment RefereeAssignment { get; set; }

    public string RefereeAssignmentId { get; set; }

    [HasMany]
    public HashSet<MatchResult> Results { get; set; }

    [HasOne]
    public MatchConfiguration MatchConfiguration { get; set; }

    public string MatchConfigurationId { get; set; }
    public string EventId { get; set; }

    public override string ToString()
    {
        return $"Match{{Id='{Id}', Status='{Status}', Mat={Mat}, Number='{Number}', Phase={(Phase != null ? Phase.ToString() : "null")}, Schedule={(Schedule != null ? Schedule.ToString() : "null")}, Result={(Result != null ? Result.ToString() : "null")}, Score={(Score != null ? Score.ToString() : "null")}, Penalties={(Penalties != null ? Penalties.ToString() : "null")}, Round={Round}, RoundTime='{RoundTime}', HomeCompetitor={(HomeCompetitor != null ? HomeCompetitor.ToString() : "null")}, AwayCompetitor={(AwayCompetitor != null ? AwayCompetitor.ToString() : "null")}, Session={(Session != null ? Session.ToString() : "null")}, Event={(Event != null ? Event.ToString() : "null")}, RefereeAssignment={(RefereeAssignment != null ? RefereeAssignment.ToString() : "null")}, Results={Results}, MatchConfiguration={(MatchConfiguration != null ? MatchConfiguration.ToString() : "null")}}}";
    }
}


