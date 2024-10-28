using SmoothStrike.Domain.Constants;

namespace SmoothStrike.Domain.Resources;

[Resource(PublicName = "sessions")]
public class Session : Identifiable<string>
{
    public string Name { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public ScheduleStatus ScheduleStatus { get; set; }

    [HasMany]
    public HashSet<Match> Matches { get; set; }

    // Default constructor
    public Session() { }

    // Parameterized constructor
    public Session(string id, string name, string startTime, string endTime, ScheduleStatus scheduleStatus, HashSet<Match> matches)
    {
        Id = id;
        Name = name;
        StartTime = startTime;
        EndTime = endTime;
        ScheduleStatus = scheduleStatus;
        Matches = matches;
    }

    public override string ToString()
    {
        return $"Session{{Id='{Id}', Name='{Name}', StartTime='{StartTime}', EndTime='{EndTime}', ScheduleStatus={ScheduleStatus}}}";
    }
}
