namespace DeezerMusicApiClient.Clients.ClientBaseTypes;

public abstract class DeezerRestClient
{
    protected static HttpClient HttpClient { get; }
    protected ISettings Settings { get; }

    static DeezerRestClient()
    {
        HttpClient = new HttpClient();
    }

    protected DeezerRestClient(ISettings settings)
    {
        Settings = settings;
    }

    protected string GetUrl() =>
        $"https://{Settings.ApiHost}/";
}