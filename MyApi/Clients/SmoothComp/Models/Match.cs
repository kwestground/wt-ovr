namespace SmoothStrike.Clients.SmoothComp.Models;

public class Match
{
    public int Id { get; set; }
    public int BracketId { get; set; }
    public string Name { get; set; }
    public string Group { get; set; }
    public int Round { get; set; }
    public string State { get; set; }
    public int MatchNr { get; set; }
    public List<int> ScheduleBlockId { get; set; }
    public string MatMatchNr { get; set; }
    public string EstimatedStart { get; set; }
    public object WinnerFromBracket { get; set; } // If the data type is known, replace 'object' with the appropriate type
    public object TimePassed { get; set; } // If the data type is known, replace 'object' with the appropriate type
    public string WonBy { get; set; }
    public List<Seat> Seats { get; set; }
}

public class Seat
{
    public string Type { get; set; }
    public object Image { get; set; } // Use a specific type if image data is available in the JSON
    public string Name { get; set; }
    public string Country { get; set; }
    public int EventRegistrationId { get; set; }
    public string Club { get; set; }
    public string Affiliation { get; set; }
    public int Approved { get; set; }
    public bool IsWinner { get; set; }
    public object Status { get; set; } // If the data type is known, replace 'object' with the appropriate type
}
