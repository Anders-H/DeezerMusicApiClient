using System.Web;
using DeezerMusicApiClient.Clients.ClientBaseTypes;
using DeezerMusicApiClient.Responses;
using RestSharp;

namespace DeezerMusicApiClient.Clients;

public class SearchClient : DeezerRestClient
{
    public SearchClient(ISettings settings) : base(settings)
    {
    }

    public SearchResult Search(string search)
    {
        var request = CreateRequest($"search?q={HttpUtility.UrlEncode(search)}");
        var response = Client.Execute(request);
        return SearchResult.Create(response);
    }
}