namespace Models.Constants;

public enum Action
{
    [JsonPropertyName("MATCH_LOADED")]
    MatchLoaded,

    [JsonPropertyName("MATCH_START")]
    MatchStart,

    [JsonPropertyName("ROUND_START")]
    RoundStart,

    [JsonPropertyName("MATCH_TIME")]
    MatchTime,

    [JsonPropertyName("MATCH_TIMEOUT")]
    MatchTimeout,

    [JsonPropertyName("MATCH_RESUME")]
    MatchResume,

    [JsonPropertyName("ROUND_END")]
    RoundEnd,

    [JsonPropertyName("MATCH_END")]
    MatchEnd,

    [JsonPropertyName("SCORE_HOME_PUNCH")]
    ScoreHomePunch,

    [JsonPropertyName("SCORE_HOME_KICK")]
    ScoreHomeKick,

    [JsonPropertyName("SCORE_HOME_TKICK")]
    ScoreHomeTKick,

    [JsonPropertyName("SCORE_HOME_HEAD")]
    ScoreHomeHead,

    [JsonPropertyName("SCORE_HOME_THEAD")]
    ScoreHomeTHead,

    [JsonPropertyName("PENALTY_HOME")]
    PenaltyHome,

    [JsonPropertyName("SCORE_AWAY_PUNCH")]
    ScoreAwayPunch,

    [JsonPropertyName("SCORE_AWAY_KICK")]
    ScoreAwayKick,

    [JsonPropertyName("SCORE_AWAY_TKICK")]
    ScoreAwayTKick,

    [JsonPropertyName("SCORE_AWAY_HEAD")]
    ScoreAwayHead,

    [JsonPropertyName("SCORE_AWAY_THEAD")]
    ScoreAwayTHead,

    [JsonPropertyName("PENALTY_AWAY")]
    PenaltyAway,

    [JsonPropertyName("INVALIDATE_SCORE")]
    InvalidateScore,

    [JsonPropertyName("ADJUST_SCORE")]
    AdjustScore,

    [JsonPropertyName("ADJUST_PENALTY")]
    AdjustPenalty,

    [JsonPropertyName("VR_HOME_REQUEST")]
    VrHomeRequest,

    [JsonPropertyName("VR_HOME_ACCEPTED")]
    VrHomeAccepted,

    [JsonPropertyName("VR_HOME_REJECTED")]
    VrHomeRejected,

    [JsonPropertyName("VR_AWAY_REQUEST")]
    VrAwayRequest,

    [JsonPropertyName("VR_AWAY_ACCEPTED")]
    VrAwayAccepted,

    [JsonPropertyName("VR_AWAY_REJECTED")]
    VrAwayRejected
}
