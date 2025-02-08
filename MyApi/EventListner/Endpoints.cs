using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace SmoothStrike.EventListner;

public static class Endpoints
{
    public const string NewMatchConfigured = "/tks/{matchCode}/events-listener/new-match-configured";
    public const string NewMatchEvent = "/tks/{matchCode}/events-listener/new-match-event";
    public const string MatchResult = "/tks/{matchCode}/events-listener/match-result";
    public const string Ping = "/tks/{matchCode}/events-listener/ping";
    public const string GetMatchPath = "/tks/{matchCode}/events-listener/match/{matchNumber}";    

    private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

    public static NewMatch GetMatch(string matchId)
    {
        var match = _cache.Get<NewMatch>(matchId);

        Console.WriteLine("GetMatch: " + matchId + " MAT: " + match.Mat);
        
        return match;
    }
    public static void SetMatch(string matchId, NewMatch match)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(60));

        _cache.Set(matchId, match, cacheEntryOptions);
    }

    public static void MapEventListner(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(Ping, () => "Hell yeah, it's working!");

        endpoints.MapGet(GetMatchPath, ([FromRoute] string matchCode,[FromRoute] string matchNumber) =>
        {
            var matchId = $"mat-{matchCode}-{matchNumber}";

            var match = GetMatch(matchId);
            if (match == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(match);
        });

        endpoints.MapPost(NewMatchConfigured, async (IHubContext<OverlayHub> hubContext, [FromRoute] string matchCode, [FromBody] NewMatch input) =>
        {
            //await hubContext.Clients.All.SendAsync("new-match-configured", "Overlay", input);
            await hubContext.Clients.Groups($"mat-{matchCode}").SendAsync("new-match-configured", "Overlay", input);

            var matchId = $"mat-{matchCode}-{input.MatchNumber}";
            SetMatch(matchId, input);
            return Results.Ok();
        });

        endpoints.MapPost(NewMatchEvent, async (IHubContext<OverlayHub> hubContext, [FromRoute] string matchCode, [FromBody] MatchEvent input) =>
        {
            var matchId = $"mat-{matchCode}-{input.MatchNumber}";
            var match = GetMatch(matchId);

            await hubContext.Clients.Groups($"mat-{matchCode}").SendAsync("new-match-event", "Overlay", input);
            return Results.Ok();
        });

        endpoints.MapPost(MatchResult, async (IHubContext<OverlayHub> hubContext, [FromRoute] string matchCode, [FromBody] MatchResult input) =>
        {
            var matchId = $"mat-{matchCode}-{input.MatchNumber}";
            var match = GetMatch(matchId);
            
            await hubContext.Clients.Groups($"mat-{matchCode}").SendAsync("match-result", "Overlay", input);
            return Results.Ok();
        });
    }
}