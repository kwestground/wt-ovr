using SmoothStrike.Domain.Constants;

namespace SmoothStrike.Domain;

public class MatchSchedule : Identifiable<int>
{
    public ScheduleStatus Status { get; set; }

    public string ScheduledStart { get; set; }

    public string EstimatedStart { get; set; }

    public string ActualStart { get; set; }

    public override string ToString()
    {
        return $"MatchSchedule{{Status={Status}, ScheduledStart='{ScheduledStart}', EstimatedStart='{EstimatedStart}', ActualStart='{ActualStart}'}}";
    }
}
