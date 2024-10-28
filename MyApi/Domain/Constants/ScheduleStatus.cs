namespace SmoothStrike.Domain.Constants;

public enum ScheduleStatus
{
    [JsonPropertyName("UNSCHEDULED")]
    Unscheduled,

    [JsonPropertyName("SCHEDULED")]
    Scheduled,

    [JsonPropertyName("GETTING_READY")]
    GettingReady,

    [JsonPropertyName("RUNNING")]
    Running,

    [JsonPropertyName("FINISHED")]
    Finished,

    [JsonPropertyName("DELAYED")]
    Delayed,

    [JsonPropertyName("CANCELLED")]
    Cancelled,

    [JsonPropertyName("POSTPONED")]
    Postponed,

    [JsonPropertyName("RESCHEDULED")]
    Rescheduled,

    [JsonPropertyName("INTERRUPTED")]
    Interrupted
}
