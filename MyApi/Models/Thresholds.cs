namespace Models;

public class Thresholds // : Identifiable<int>
{
    [JsonIgnore]
    public int Id { get; set; }

    public int? Body { get; set; }
    public int? Head { get; set; }

    // Default constructor
    public Thresholds() { }

    // Parameterized constructor
    public Thresholds(int? body, int? head)
    {
        Body = body;
        Head = head;
    }

    public override string ToString()
    {
        return $"Thresholds{{Body={Body}, Head={Head}}}";
    }
}
