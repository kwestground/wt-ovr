namespace SmoothStrike.EventListner;

public class MatchEvent
{
    public string MatchNumber { get; set; }
    public string MatchCategoryName { get; set; }
    public string MatchCategoryGender { get; set; }
    public string MatchSubCategoryName { get; set; }

    public int RoundNumber { get; set; }
    public string RoundNumberStr { get; set; }

    public long TkStrikeSystemTimestamp { get; set; }
    public string TkStrikeSystemTimestampStr { get; set; }

    public long RoundTimestamp { get; set; }
    public string RoundTimestampStr { get; set; }

    /// <summary>
    /// MATCH_FINISHED
    /// </summary>
    public string EventType { get; set; }
    public bool EventAddPoints { get; set; }
    public bool EventRemovePoints { get; set; }

    public int BluePoints { get; set; }
    public int BluePenalties { get; set; }
    public int BlueRoundWins { get; set; }

    public int RedPoints { get; set; }
    public int RedPenalties { get; set; }
    public int RedRoundWins { get; set; }

    public int Hitlevel { get; set; }

    /// <summary>
    /// BLUE, RED
    /// </summary>
    public string MatchWinner { get; set; }
    /// <summary>
    /// WDR
    /// </summary>
    public string MatchFinalDecision { get; set; }
}


public class NewMatch
{
    public int Mat { get; set; }
    public string MatchNumber { get; set; }
    public string Phase { get; set; }
    public Category Category { get; set; }
    public Athlete BlueAthlete { get; set; }
    public int BlueAthleteVideoQuota { get; set; }
    public Athlete RedAthlete { get; set; }
    public int RedAthleteVideoQuota { get; set; }
    public RoundsConfig RoundsConfig { get; set; }
    public int DifferencialScore { get; set; }
    public int MaxAllowedGamJeoms { get; set; }
    public string MatchVictoryCriteria { get; set; }
    public bool WtCompetitionDataProtocol { get; set; }
    public bool ParaTkdMatch { get; set; }
}

public class Category
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string SubCategory { get; set; }
    public int BodyLevel { get; set; }
    public int HeadLevel { get; set; }
}

public class Athlete
{
    public string ScoreboardName { get; set; }
    public string FlagAbbreviation { get; set; }
    public int Rank { get; set; }
    public int Seed { get; set; }
}

public class RoundsConfig
{
    public int Rounds { get; set; }
    public int RoundTimeMinutes { get; set; }
    public int RoundTimeSeconds { get; set; }
    public int KyeShiTimeMinutes { get; set; }
    public int KyeShiTimeSeconds { get; set; }
    public int RestTimeMinutes { get; set; }
    public int RestTimeSeconds { get; set; }
    public bool GoldenPointEnabled { get; set; }
    public int GoldenPointTimeMinutes { get; set; }
    public int GoldenPointTimeSeconds { get; set; }
}


public class MatchResult
{
    public string MatchNumber { get; set; }
    public string CategoryName { get; set; }
    public string CategoryGender { get; set; }
    public string SubCategoryName { get; set; }
    public string PhaseName { get; set; }
    public long MatchStartTime { get; set; }
    public long MatchEndTime { get; set; }
    public bool GoldenPointTieBreakerHaveTieBreaker { get; set; }
    public string MatchVictoryCriteria { get; set; }
    public bool ParaTkdMatch { get; set; }
    public string MatchWinnerColor { get; set; }
    public MatchWinner MatchWinner { get; set; }
    public string MatchFinalDecision { get; set; }
    public int RoundFinish { get; set; }
    public int BluePoints { get; set; }
    public int BlueRoundWins { get; set; }
    public int BluePenalties { get; set; }
    public int BlueVideoQuota { get; set; }
    public int RedPoints { get; set; }
    public int RedRoundWins { get; set; }
    public int RedPenalties { get; set; }
    public int RedVideoQuota { get; set; }
}

public class MatchWinner
{
    public string ScoreboardName { get; set; }
    public string FlagAbbreviation { get; set; }
    public int Rank { get; set; }
    public int Seed { get; set; }
}