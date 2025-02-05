using JsonApiDotNetCore.Configuration;
using Microsoft.EntityFrameworkCore;
using SmoothStrike.EventListner;
using SmoothStrike.Servers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string db = "(localdb)\\MSSQLLocalDB";

    // Use whatever provider you want, this is just an example.
    options.UseSqlServer($"Server={db};Database=wt-ovr;Trusted_Connection=True;");
});
builder.Services.AddJsonApi<AppDbContext>(options => 
{
    options.EnableLegacyFilterNotation = true;
    // options.Namespace = "api";
}, discovery: discovery => discovery.AddCurrentAssembly());

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddSignalR();

var app = builder.Build();

app.UseRequestLogging();
app.UseRouting();
app.UseJsonApi();
app.MapControllers();
app.MapRazorPages();
app.UseStaticFiles();
app.MapHub<OverlayHub>("/hub");

app.MapGet("/status", () => "Hell yeah, it's working!");
app.MapGet("/overlay-test", async (IHubContext<OverlayHub> hubContext) => 
{
    await hubContext.Clients.All.SendAsync("ReceiveMessage", "Overlay", "Hello from the overlay!");
});
// app.MapGet("/matches", () => "{\r\n  \"data\": [\r\n    {\r\n      \"type\": \"matches\",\r\n      \"id\": \"103\",\r\n      \"attributes\": {\r\n        \"mat\": 1,\r\n        \"number\": \"103\",\r\n        \"phase\": \"R32\",\r\n        \"schedule\": {\r\n          \"status\": \"SCHEDULED\",\r\n          \"scheduledStart\": \"1-01-01-T22:52:00+02:00\",\r\n          \"estimatedStart\": \"1-01-01-T22:52:00+02:00\",\r\n          \"actualStart\": \"1-01-01-T22:52:00+02:00\"\r\n        },\r\n        \"result\": {\r\n          \"status\": null,\r\n          \"decision\": null,\r\n          \"homeType\": null,\r\n          \"awayType\": null\r\n        },\r\n        \"score\": {\r\n          \"home\": 0,\r\n          \"away\": 0\r\n        },\r\n        \"penalties\": {\r\n          \"home\": 0,\r\n          \"away\": 0\r\n        },\r\n        \"round\": 0,\r\n        \"roundTime\": null\r\n      },\r\n      \"relationships\": {\r\n        \"homeCompetitor\": {\r\n          \"data\": {\r\n            \"type\": \"competitors\",\r\n            \"id\": \"TPL-4124\"\r\n          }\r\n        },\r\n        \"awayCompetitor\": {\r\n          \"data\": {\r\n            \"type\": \"competitors\",\r\n            \"id\": \"TUN-1791\"\r\n          }\r\n        },\r\n        \"event\": {\r\n          \"data\": {\r\n            \"type\": \"events\",\r\n            \"id\": \"3b4ffc7c-0b14-48df-9116-1a1328627305\"\r\n          }\r\n        },\r\n        \"matchConfiguration\": {\r\n          \"data\": {\r\n            \"type\": \"match-configurations\",\r\n            \"id\": \"103_381561fc-5485-4b23-aefc-0762392d7313\"\r\n          }\r\n        },\r\n        \"refereeAssignment\": {}\r\n      }\r\n    }\r\n  ],\r\n  \"included\": [\r\n    {\r\n      \"type\": \"competitors\",\r\n      \"id\": \"TPL-4124\",\r\n      \"attributes\": {\r\n        \"competitorType\": \"A\",\r\n        \"printName\": \"SWEENEY Liam \",\r\n        \"printInitialName\": \"SWEENEY Liam \",\r\n        \"tvName\": \"SWEENEY Liam \",\r\n        \"tvInitialName\": \"L. SWEENEY\",\r\n        \"scoreboardName\": \"SWEENEY L.\",\r\n        \"rank\": 38,\r\n        \"seed\": 25,\r\n        \"country\": \"AUS\"\r\n      }\r\n    },\r\n    {\r\n      \"type\": \"competitors\",\r\n      \"id\": \"TUN-1791\",\r\n      \"attributes\": {\r\n        \"competitorType\": \"A\",\r\n        \"printName\": \"KATOUSI Firas \",\r\n        \"printInitialName\": \"KATOUSI Firas \",\r\n        \"tvName\": \"KATOUSI Firas \",\r\n        \"tvInitialName\": \"F. KATOUSI\",\r\n        \"scoreboardName\": \"KATOUSI F.\",\r\n        \"rank\": 8,\r\n        \"seed\": 8,\r\n        \"country\": \"TUN\"\r\n      },\r\n      \"relationships\": {\r\n        \"organization\": {\r\n          \"data\": {\r\n            \"type\": \"organizations\",\r\n            \"id\": \"fb7d418b-79bc-4896-a643-634f50863067\"\r\n          }\r\n        },\r\n        \"event\": {\r\n          \"data\": {\r\n            \"type\": \"events\",\r\n            \"id\": \"3b4ffc7c-0b14-48df-9116-1a1328627305\"\r\n          }\r\n        },\r\n        \"participant\": {\r\n          \"data\": {\r\n            \"type\": \"participants\",\r\n            \"id\": \"TUN-1791\"\r\n          }\r\n        }\r\n      }\r\n    },\r\n    {\r\n      \"type\": \"match-configurations\",\r\n      \"id\": \"103_381561fc-5485-4b23-aefc-0762392d7313\",\r\n      \"attributes\": {\r\n        \"rules\": \"BESTOF3\",\r\n        \"rounds\": 3,\r\n        \"timing\": {\r\n          \"round\": \"2:00\",\r\n          \"rest\": \"1:00\",\r\n          \"injury\": \"1:00\"\r\n        },\r\n        \"thresholds\": {\r\n          \"body\": 23,\r\n          \"head\": 1\r\n        },\r\n        \"videoReplayQuota\": {\r\n          \"home\": 1,\r\n          \"away\": 1\r\n        },\r\n        \"goldenPoint\": {\r\n          \"enabled\": false,\r\n          \"time\": \"00:00\"\r\n        },\r\n        \"maxDifference\": 12\r\n      }\r\n    },\r\n    {\r\n      \"type\": \"events\",\r\n      \"id\": \"3b4ffc7c-0b14-48df-9116-1a1328627305\",\r\n      \"attributes\": {\r\n        \"discipline\": \"Taekwondo Kyorugi\",\r\n        \"division\": \"Seniors\",\r\n        \"gender\": \"MALE\",\r\n        \"name\": \"Men -80kg\",\r\n        \"weightCategory\": \"M -80kg\",\r\n        \"sportClass\": null,\r\n        \"category\": null,\r\n        \"role\": \"ATHLETE\"\r\n      }\r\n    }\r\n  ]\r\n}");

//app.MapGet("/static/status", () => "Hell yeah, it's working!");
app.MapGet("/matches-test", () => {
    var jsonFromFile = File.ReadAllText("workingmatches.json");
    return jsonFromFile;
});


app.MapGet("/events-listener/ping", () => "Hell yeah, it's working!");

// /events-listener/new-match-configured
// /events-listener/new-match-event

app.MapEventListner();

app.UseSwagger();
app.UseSwaggerUI();
// app.UseHttpsRedirection();

app.UseRtBroadcastServer();



app.Run();


public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Enable buffering to allow multiple reads of the request body
        context.Request.EnableBuffering();

        // Read the request body stream and log it
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        _logger.LogInformation("Incoming request: {method} {url}{queryString} from {ipAddress}",
            context.Request.Method,
            context.Request.Path,
            context.Request.QueryString,
            context.Connection.RemoteIpAddress);
        _logger.LogInformation("Payload: {payload}", requestBody);

        // Rewind the stream so it's available for the next middleware
        context.Request.Body.Position = 0;

        // Call the next middleware in the pipeline
        await _next(context);

        // Log response status
        _logger.LogInformation("Response status: {statusCode}", context.Response.StatusCode);
    }
}

// Extension method för att använda middleware
public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
}
