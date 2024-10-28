using SmoothStrike.Clients.SmoothComp;

namespace SmootStrike.Tests;

[TestClass]
public class SmoothCompClientTests
{
    [TestMethod]
    public void Login_Test()
    {
        var client = new SmoothCompClient(true);

        client.LoginAsync("kenny@westground.se", "eFZr").Wait();

        var matches = client.GetMatchesAsync(3798, 56501).Result;

    }
}