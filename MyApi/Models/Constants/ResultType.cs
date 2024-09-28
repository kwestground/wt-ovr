namespace Models.Constants;

public enum ResultType
{
    [JsonPropertyName("WIN")]
    Win,

    [JsonPropertyName("LOSS")]
    Loss,

    [JsonPropertyName("TIE")]
    Tie
}
