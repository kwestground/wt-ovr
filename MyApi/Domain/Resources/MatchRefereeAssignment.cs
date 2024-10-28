namespace SmoothStrike.Domain.Resources;

[Resource(PublicName = "match-referee-assignments")]
public class MatchRefereeAssignment : Identifiable<string>
{

    [HasOne]
    public Match Match { get; set; }

    [HasOne]
    public Participant RefJ1 { get; set; }

    [HasOne]
    public Participant RefJ2 { get; set; }

    [HasOne]
    public Participant RefJ3 { get; set; }

    [HasOne]
    public Participant RefCR { get; set; }

    [HasOne]
    public Participant RefRJ { get; set; }

    [HasOne]
    public Participant RefTA { get; set; }

    public override string ToString()
    {
        return $"MatchRefereeAssignment{{Id='{Id}', RefJ1={RefJ1}, RefJ2={RefJ2}, RefJ3={RefJ3}, RefCR={RefCR}, RefRJ={RefRJ}, RefTA={RefTA}}}";
    }
}
