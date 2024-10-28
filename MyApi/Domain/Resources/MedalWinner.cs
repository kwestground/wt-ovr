namespace SmoothStrike.Domain.Resources;

[Resource(PublicName = "medal-winners")]
public class MedalWinner : Identifiable<string>
{
    public int? Position { get; set; }

    public string MedalType { get; set; }

    // Default constructor
    public MedalWinner() { }

    // Parameterized constructor
    public MedalWinner(string id, int? position, string medalType)
    {
        Id = id;
        Position = position;
        MedalType = medalType;
    }

    public override string ToString()
    {
        return $"MedalWinner{{Id='{Id}', Position={Position}, MedalType='{MedalType}'}}";
    }
}
