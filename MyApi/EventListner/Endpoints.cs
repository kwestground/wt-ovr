using Microsoft.AspNetCore.Mvc;

namespace SmoothStrike.EventListner;

public static class Endpoints
{
    public const string NewMatchConfigured = "/events-listener/new-match-configured";
    public const string NewMatchEvent = "/events-listener/new-match-event";
    public const string MatchResult = "/events-listener/match-result";



    public static void MapEventListner(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(NewMatchConfigured, async (IHubContext<OverlayHub> hubContext, [FromBody] NewMatch input) =>
        {
            await hubContext.Clients.All.SendAsync("new-match-configured", "Overlay", input);
            return Results.Ok();
        });

        endpoints.MapPost(NewMatchEvent, async (IHubContext<OverlayHub> hubContext, [FromBody] MatchEvent input) =>
        {
            await hubContext.Clients.All.SendAsync("new-match-event", "Overlay", input);
            return Results.Ok();
        });

        endpoints.MapPost(MatchResult, async (IHubContext<OverlayHub> hubContext, [FromBody] MatchResult input) =>
        {
            await hubContext.Clients.All.SendAsync("match-result", "Overlay", input);
            return Results.Ok();
        });
    }
}