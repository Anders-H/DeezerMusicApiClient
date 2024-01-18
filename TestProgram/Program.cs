using DeezerMusicApiClient.Clients;
using TestProgram;

var settings = new Settings();

Menu:
Console.WriteLine("A. Get artist");
Console.WriteLine("S. Search");
Console.WriteLine("X. Quit");

var x = (Console.ReadLine() ?? "").Trim().ToLower();

if (x.StartsWith("s"))
    Search();
else if (x.StartsWith("x"))
    return;

goto Menu;

void Search()
{
    Console.Write("Search: ");
    var searchFor = Console.ReadLine() ?? "";
    
    if (string.IsNullOrWhiteSpace(searchFor))
        return;

    var searchClient = new SearchClient(settings);
    var response = searchClient.Search(searchFor);

    if (response.Success)
    {
        foreach (var track in response.Tracks)
        {
            Console.WriteLine(track.ToString());
        }
    }
    else
    {
        Console.WriteLine("Failed.");
    }
}