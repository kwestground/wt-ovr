namespace Models.Constants;

public enum Gender
{
    [JsonPropertyName("FEMALE")]
    Female,

    [JsonPropertyName("MALE")]
    Male,

    [JsonPropertyName("MIXED")]
    Mixed
}
