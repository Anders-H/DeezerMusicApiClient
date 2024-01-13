namespace DeezerMusicApiClient.Responses.ResponseBaseTypes;

public abstract class ResultObjects
{
    public bool Success { get; }

    protected ResultObjects(bool success)
    {
        Success = success;
    }
}