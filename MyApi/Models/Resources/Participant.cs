using Models.Constants;

namespace Models;

[Resource(PublicName = "participants")]
public class Participant : Identifiable<string>
{
    public override string Id { get; set; }
    public string LicenseNumber { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string PassportGivenName { get; set; }
    public string PassportFamilyName { get; set; }
    public string PreferredGivenName { get; set; }
    public string PreferredFamilyName { get; set; }
    public string PrintName { get; set; }
    public string PrintInitialName { get; set; }
    public string TvName { get; set; }
    public string TvInitialName { get; set; }
    public string ScoreboardName { get; set; }
    public Gender Gender { get; set; }
    public string BirthDate { get; set; }
    public Role MainRole { get; set; }
    public string Country { get; set; }

    [HasOne]
    public Organization Organization { get; set; }

    // Default constructor
    public Participant() { }

    // Parameterized constructor
    public Participant(string id, string licenseNumber, string givenName, string familyName, string passportGivenName, 
                       string passportFamilyName, string preferredGivenName, string preferredFamilyName, 
                       string printName, string printInitialName, string tvName, string tvInitialName, 
                       string scoreboardName, Gender gender, string birthDate, Role mainRole, string country, 
                       Organization organization)
    {
        Id = id;
        LicenseNumber = licenseNumber;
        GivenName = givenName;
        FamilyName = familyName;
        PassportGivenName = passportGivenName;
        PassportFamilyName = passportFamilyName;
        PreferredGivenName = preferredGivenName;
        PreferredFamilyName = preferredFamilyName;
        PrintName = printName;
        PrintInitialName = printInitialName;
        TvName = tvName;
        TvInitialName = tvInitialName;
        ScoreboardName = scoreboardName;
        Gender = gender;
        BirthDate = birthDate;
        MainRole = mainRole;
        Country = country;
        Organization = organization;
    }

    public override string ToString()
    {
        return $"Participant{{Id='{Id}', LicenseNumber='{LicenseNumber}', GivenName='{GivenName}', FamilyName='{FamilyName}', PassportGivenName='{PassportGivenName}', PassportFamilyName='{PassportFamilyName}', PreferredGivenName='{PreferredGivenName}', PreferredFamilyName='{PreferredFamilyName}', PrintName='{PrintName}', PrintInitialName='{PrintInitialName}', TvName='{TvName}', TvInitialName='{TvInitialName}', ScoreboardName='{ScoreboardName}', Gender='{Gender}', BirthDate='{BirthDate}', MainRole='{MainRole}', Country='{Country}', Organization={Organization}}}";
    }
}
