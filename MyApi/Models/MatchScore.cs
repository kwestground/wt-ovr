namespace Models;

public class MatchScore // : Identifiable<int>
{
    [JsonIgnore]
    public int Id { get; set; }

    public int? Home { get; set; }

    public int? Away { get; set; }

    // Default constructor
    public MatchScore() { }

    // Parameterized constructor
    public MatchScore(int? home, int? away)
    {
        Home = home;
        Away = away;
    }

    public override string ToString()
    {
        return $"MatchScore{{Home={Home}, Away={Away}}}";
    }
}
