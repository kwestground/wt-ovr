using Models.Constants;

namespace Models;

public class MatchInternalResult : Identifiable<int>
{
    public ResultStatus Status { get; set; }

    public string Decision { get; set; }

    public ResultType HomeType { get; set; }

    public ResultType AwayType { get; set; }

    // Default constructor
    public MatchInternalResult() { }

    // Parameterized constructor
    public MatchInternalResult(ResultStatus status, string decision, ResultType homeType, ResultType awayType)
    {
        Status = status;
        Decision = decision;
        HomeType = homeType;
        AwayType = awayType;
    }

    public override string ToString()
    {
        return $"MatchInternalResult{{Status={Status}, Decision='{Decision}', HomeType={HomeType}, AwayType={AwayType}}}";
    }
}
