using DeezerMusicApiClient.Responses.Domain;
using DeezerMusicApiClient.Responses.ResponseBaseTypes;
using Newtonsoft.Json;
using RestSharp;

namespace DeezerMusicApiClient.Responses;

public class SearchResult : ResultObjects
{
    public List<MusicTrack> Tracks { get; }

    public SearchResult(bool success) : base(success)
    {
        Tracks = new List<MusicTrack>();
    }

    internal static SearchResult Create(RestResponse? restResponse)
    {
        if (restResponse == null)
            return new SearchResult(false);

        var result = new SearchResult(restResponse.IsSuccessful);

        if (!result.Success)
            return result;

        var json = restResponse.Content ?? "";

        if (string.IsNullOrEmpty(json))
            return result;

        var o = JsonConvert.DeserializeObject<dynamic>(json);

        if (o?.data == null)
            return result;

        foreach (var d in o.data)
        {
            var track = MusicTrack.Create(d);

            if (track != null)
                result.Tracks.Add(track);
        }

        return result;
    }
}