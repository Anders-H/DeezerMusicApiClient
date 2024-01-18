using RestSharp;

namespace DeezerMusicApiClient.Clients.ClientBaseTypes;

public abstract class DeezerRestClient
{
    protected static HttpClient HttpClient { get; }
    protected static RestClient Client { get; }

    protected ISettings Settings { get; }

    static DeezerRestClient()
    {
        HttpClient = new HttpClient();
        Client = new RestClient(HttpClient, new RestClientOptions());
    }

    protected DeezerRestClient(ISettings settings)
    {
        Settings = settings;
    }

    private string GetUrl() =>
        $"https://{Settings.ApiHost}/";

    protected RestRequest CreateRequest(string parameters)
    {
        var request = new RestRequest($"{GetUrl()}{parameters}");
        request.AddHeader("X-RapidAPI-Key", Settings.ApplicationKey);
        request.AddHeader("X-RapidAPI-Host", Settings.ApiHost);
        return request;
    }
}