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
        var client = new RestClient(HttpClient, new RestClientOptions());
        var request = new RestRequest($"{GetUrl()}search?q={HttpUtility.UrlEncode(search)}");
        request.AddHeader("X-RapidAPI-Key", Settings.ApplicationKey);
        request.AddHeader("X-RapidAPI-Host", Settings.ApiHost);
        var response = client.Execute(request);
        return SearchResult.Create(response);
    }
}