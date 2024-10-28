namespace SmoothStrike.Domain.Constants;

public enum Role
{
    [JsonPropertyName("ATHLETE")]
    Athlete,

    [JsonPropertyName("REFEREE")]
    Referee,

    [JsonPropertyName("COACH")]
    Coach
}
