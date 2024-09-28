namespace Models.Constants;

public enum Role
{
    [JsonPropertyName("ATHLETE")]
    Athlete,

    [JsonPropertyName("REFEREE")]
    Referee,

    [JsonPropertyName("COACH")]
    Coach
}
