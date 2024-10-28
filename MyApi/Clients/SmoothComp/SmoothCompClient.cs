using HtmlAgilityPack;
using SmoothStrike.Clients.SmoothComp.Models;
using System.Net;
using System.Text.Json;

namespace SmoothStrike.Clients.SmoothComp;

public class SmoothCompClient
{
    private bool isDemo;
    private readonly HttpClient httpClient;
    private string bearer;
    private readonly Dictionary<string, string> cookies = [];

    private string BaseUrl => isDemo ? "https://demo.smoothcomp.com" : "https://smoothcomp.com";

    public SmoothCompClient(bool demo = true)
    {
        httpClient = new HttpClient();
        isDemo = demo;

        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Safari/537.36 Edg/130.0.0.0");
    }

    // add cookie
    public void SetCookie(string key, string value)
    {
        if (!cookies.TryAdd(key, value))
        {
            cookies[key] = value;
        }
    }

    // Set Bearer token
    public void SetBearer(string bearer)
    {
        this.bearer = bearer;
    }

    // Get Form Token from /en/auth/login
    public async Task<string> GetFormTokenAsync()
    {
        var url = $"{BaseUrl}/en/auth/login";
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // save cookies
        var responseCookies = response.Headers.GetValues("Set-Cookie");
        foreach (var cookie in responseCookies)
        {
            var parts = cookie.Split(';');
            var key = parts[0].Split('=')[0];
            var value = parts[0].Split('=')[1];
            SetCookie(key, value);
        }

        var content = await response.Content.ReadAsStringAsync();
        var doc = new HtmlDocument();
        doc.LoadHtml(content);
        var token = doc.DocumentNode.SelectSingleNode("//input[@name='_token']");
        return token.GetAttributeValue("value", "");
    }

    // Login /en/auth/login
    public async Task LoginAsync(string username, string password)
    {
        var token = await GetFormTokenAsync();

        var url = $"{BaseUrl}/en/auth/login";
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("email", username),
            new KeyValuePair<string, string>("password", password),
            new KeyValuePair<string, string>("_token", token),
            new KeyValuePair<string, string>("create_account", "0"),
            new KeyValuePair<string, string>("_next_url", string.Empty),
            new KeyValuePair<string, string>("remember", "1")
        });

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Cookie", string.Join("; ", cookies.Select(x => $"{x.Key}={x.Value}")));
        request.Content = content;
        var response = await httpClient.SendAsync(request);

        //var response = await httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode != HttpStatusCode.Found)
        {
            var htmlBody = await response.Content.ReadAsStringAsync();
            // throw new Exception("Login failed");
        }

        var responseCookies = response.Headers.GetValues("Set-Cookie");
        foreach (var cookie in responseCookies)
        {
            var parts = cookie.Split(';');
            var key = parts[0].Split('=')[0];
            var value = parts[0].Split('=')[1];
            SetCookie(key, value);

            Console.WriteLine(key + "=" + value);
        }
    }

    // Get Matches /sv/event/{eventId}/schedule/new/mat/{matId}/matches.json
    public async Task<ICollection<Match>> GetMatchesAsync(int eventId, int matId, string lang = "sv")
    {
        var url = $"{BaseUrl}/{lang}/event/{eventId}/schedule/new/mat/{matId}/matches.json";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Cookie", string.Join("; ", cookies.Select(x => $"{x.Key}={x.Value}")));
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var matches = JsonSerializer.Deserialize<ICollection<Match>>(content);
        return matches;
    }

    public async Task<string> GetJsonTokenFromHtmlAsync(string url)
    {
        var response = await this.httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string htmlContent = await response.Content.ReadAsStringAsync();

        // Use Regex to find the `window.jsonToken` variable in the HTML content
        // This assumes `window.jsonToken` is set in a way like `window.jsonToken = "your-jwt-token";`
        var tokenRegex = new System.Text.RegularExpressions.Regex(@"window\.jsonToken\s*=\s*""(?<token>[^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        var match = tokenRegex.Match(htmlContent);

        if (match.Success)
        {
            // Extract the token
            return match.Groups["token"].Value;
        }

        throw new Exception("Token not found in HTML.");
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        return await httpClient.GetAsync(url);
    }
}
