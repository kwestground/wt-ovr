namespace Models;

[Resource(PublicName = "organizations")]
public class Organization : Identifiable<string>
{
    public string Name { get; set; }

    public string Country { get; set; }

    // Default constructor
    public Organization() { }

    // Parameterized constructor
    public Organization(string id, string name, string country)
    {
        Id = id;
        Name = name;
        Country = country;
    }

    public override string ToString()
    {
        return $"Organization{{Id='{Id}', Name='{Name}', Country='{Country}'}}";
    }
}
