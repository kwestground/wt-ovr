using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace SmoothStrike.EventListner;

public static class Endpoints
{
    public const string NewMatchConfigured = "/{matchCode}/events-listener/new-match-configured";
    public const string NewMatchEvent = "/{matchCode}/events-listener/new-match-event";
    public const string MatchResult = "/{matchCode}/events-listener/match-result";

    private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

    public static NewMatch GetMatch(string matchNumber)
    {
        return _cache.Get<NewMatch>(matchNumber);
    }


    public static void SetMatch(NewMatch match)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(60));

        _cache.Set(match.MatchNumber, match, cacheEntryOptions);
    }

    public static void MapEventListner(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/events-listener/match/{matchNumber}", (string matchNumber) =>
        {
            var match = GetMatch(matchNumber);
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

            SetMatch(input);
            return Results.Ok();
        });

        endpoints.MapPost(NewMatchEvent, async (IHubContext<OverlayHub> hubContext, [FromRoute] string matchCode, [FromBody] MatchEvent input) =>
        {
            var match = GetMatch(input.MatchNumber);

            //await hubContext.Clients.All.SendAsync("new-match-event", "Overlay", input);
            await hubContext.Clients.Groups($"mat-{matchCode}").SendAsync("new-match-event", "Overlay", input);
            return Results.Ok();
        });

        endpoints.MapPost(MatchResult, async (IHubContext<OverlayHub> hubContext, [FromRoute] string matchCode, [FromBody] MatchResult input) =>
        {
            var match = GetMatch(input.MatchNumber);
            //await hubContext.Clients.All.SendAsync("match-result", "Overlay", input);
            await hubContext.Clients.Groups($"mat-{matchCode}").SendAsync("match-result", "Overlay", input);
            return Results.Ok();
        });
    }
}