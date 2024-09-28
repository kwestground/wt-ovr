namespace Models;

public class Timing// : Identifiable<int>
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Round { get; set; }
    public string Rest { get; set; }
    public string Injury { get; set; }

    // Default constructor
    public Timing() { }

    // Parameterized constructor
    public Timing(string round, string rest, string injury)
    {
        Round = round;
        Rest = rest;
        Injury = injury;
    }

    public override string ToString()
    {
        return $"Timing{{Round='{Round}', Rest='{Rest}', Injury='{Injury}'}}";
    }
}
