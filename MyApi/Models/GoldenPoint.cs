namespace Models;

public class GoldenPoint // : Identifiable<int>
{
    [JsonIgnore]
    public int Id { get; set; }
    
    public bool? Enabled { get; set; }
    public string Time { get; set; }

    // Default constructor
    public GoldenPoint() { }

    // Parameterized constructor
    public GoldenPoint(bool? enabled, string time)
    {
        Enabled = enabled;
        Time = time;
    }

    public override string ToString()
    {
        return $"GoldenPoint{{Enabled={Enabled}, Time='{Time}'}}";
    }
}
