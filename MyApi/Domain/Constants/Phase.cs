namespace SmoothStrike.Domain.Constants;

public enum Phase
{
    [JsonPropertyName("R256")]
    R256,

    [JsonPropertyName("R128")]
    R128,

    [JsonPropertyName("R64")]
    R64,

    [JsonPropertyName("R32")]
    R32,

    [JsonPropertyName("R16")]
    R16,

    [JsonPropertyName("QF")]
    QF,

    [JsonPropertyName("SF")]
    SF,

    [JsonPropertyName("F")]
    F,

    [JsonPropertyName("BRZ")]
    BRZ
}
