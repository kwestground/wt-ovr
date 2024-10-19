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

    public override string ToString()
    {
        return $"Participant{{Id='{Id}', LicenseNumber='{LicenseNumber}', GivenName='{GivenName}', FamilyName='{FamilyName}', PassportGivenName='{PassportGivenName}', PassportFamilyName='{PassportFamilyName}', PreferredGivenName='{PreferredGivenName}', PreferredFamilyName='{PreferredFamilyName}', PrintName='{PrintName}', PrintInitialName='{PrintInitialName}', TvName='{TvName}', TvInitialName='{TvInitialName}', ScoreboardName='{ScoreboardName}', Gender='{Gender}', BirthDate='{BirthDate}', MainRole='{MainRole}', Country='{Country}', Organization={Organization}}}";
    }
}
