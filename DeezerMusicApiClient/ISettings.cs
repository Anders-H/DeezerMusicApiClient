namespace DeezerMusicApiClient;

public interface ISettings
{
    public string DeezerRapidApiApplication { get; }
    public string RequestUrl { get; }
    public string ApplicationKey { get; }
    public string ApiHost { get; }
}