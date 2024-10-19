using Models.Constants;

namespace Models;

[Resource(PublicName = "match-configurations")]
public class MatchConfiguration : Identifiable<string>
{
    [Attr]
    public Rules Rules { get; set; }

    [Attr]
    public int? Rounds { get; set; }

    [Attr]
    public Timing Timing { get; set; }

    public int TimingId { get; set; }

    [Attr]
    public Thresholds Thresholds { get; set; }

    [Attr]
    public MatchScore VideoReplayQuota { get; set; }

    [Attr]
    public GoldenPoint GoldenPoint { get; set; }

    [Attr]
    public int? MaxDifference { get; set; }

    [Attr]
    public int? MaxPenalties { get; set; }

    public override string ToString()
    {
        return $"MatchConfiguration{{Id='{Id}', Rounds={(Rounds != null ? Rounds.ToString() : "null")}, Timing={(Timing != null ? Timing.ToString() : "null")}, Thresholds={(Thresholds != null ? Thresholds.ToString() : "null")}, VideoReplayQuota={(VideoReplayQuota != null ? VideoReplayQuota.ToString() : "null")}, GoldenPoint={(GoldenPoint != null ? GoldenPoint.ToString() : "null")}, MaxDifference={MaxDifference}, MaxPenalties={MaxPenalties}}}";
    }
}
