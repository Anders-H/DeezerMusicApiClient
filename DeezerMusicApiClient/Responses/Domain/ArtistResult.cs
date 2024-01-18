using DeezerMusicApiClient.Responses.ResponseBaseTypes;
using Newtonsoft.Json;
using RestSharp;

namespace DeezerMusicApiClient.Responses.Domain;

public class ArtistResult : ResultObjects
{
    public uint Id { get; }
    public string Name { get; }

    public ArtistResult(bool success, uint id, string name) : base(success)
    {
        Id = id;
        Name = name;
    }

    internal static ArtistResult Create(RestResponse? restResponse)
    {
        if (restResponse == null)
            return Fail();

        var result = new SearchResult(restResponse.IsSuccessful);

        if (!result.Success)
            return Fail();

        var json = restResponse.Content ?? "";

        if (string.IsNullOrEmpty(json))
            return Fail();

        var o = JsonConvert.DeserializeObject<dynamic>(json);

        if (o?.data == null)
            return Fail();

        var id = (uint)(o.id ?? 0);
        var name = (string)(o.name ?? "");
        return Done(id, name);
    }

    internal static ArtistResult Fail() =>
        new(false, 0, "");

    internal static ArtistResult Done(uint id, string name) =>
        new(true, id, name);
}