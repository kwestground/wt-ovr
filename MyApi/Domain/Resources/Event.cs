using SmoothStrike.Domain.Constants;

namespace SmoothStrike.Domain.Resources;

[Resource(PublicName = "events")]
public class Event : Identifiable<string>
{
    [Attr]
    public string Discipline { get; set; }
    [Attr]
    public string Division { get; set; }
    [Attr]
    public Gender Gender { get; set; }
    [Attr]
    public string Name { get; set; }
    [Attr]
    public string WeightCategory { get; set; }
    [Attr]
    public string SportClass { get; set; }
    [Attr]
    public string Category { get; set; }
    [Attr]
    public Role Role { get; set; }

    [HasMany]
    public HashSet<MedalWinner> MedalWinners { get; set; }

    [HasMany]
    public HashSet<Match> Matches { get; set; }

    // Default constructor
    public Event() { }

    // Parameterized constructor
    public Event(string id, string discipline, string division, Gender gender, string name, string weightCategory, string sportClass,
                 string category, Role role, HashSet<MedalWinner> medalWinners, HashSet<Match> matches)
    {
        Id = id;
        Discipline = discipline;
        Division = division;
        Gender = gender;
        Name = name;
        WeightCategory = weightCategory;
        SportClass = sportClass;
        Category = category;
        Role = role;
        MedalWinners = medalWinners;
        Matches = matches;
    }

    public override string ToString()
    {
        return $"Event{{Id='{Id}', Discipline='{Discipline}', Division='{Division}', Gender='{Gender}', Name='{Name}', " +
               $"WeightCategory='{WeightCategory}', SportClass='{SportClass}', Category='{Category}', Role='{Role}', " +
               $"MedalWinners={MedalWinners}, Matches={Matches}}}";
    }
}
