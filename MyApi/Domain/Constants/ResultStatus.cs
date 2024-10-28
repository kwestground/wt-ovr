namespace SmoothStrike.Domain.Constants;

public enum ResultStatus
{
    [JsonPropertyName("LIVE")]
    Live,

    [JsonPropertyName("INTERMEDIATE")]
    Intermediate,

    [JsonPropertyName("UNCONFIRMED")]
    Unconfirmed,

    [JsonPropertyName("UNOFFICIAL")]
    Unofficial,

    [JsonPropertyName("OFFICIAL")]
    Official,

    [JsonPropertyName("PROTESTED")]
    Protested
}
