namespace DeezerMusicApiClient.Responses.Domain;

public class MusicTrack
{
    public ulong Id { get; }
    public string Title { get; }
    public int Duration { get; }
    public ulong ArtistId { get; }
    public string ArtistName { get; }
    public ulong AlbumId { get; }
    public string AlbumName { get; }

    public MusicTrack(ulong id, string title, int duration, ulong artistId, string artistName, ulong albumId, string albumName)
    {
        Id = id;
        Title = title;
        Duration = duration;
        ArtistId = artistId;
        ArtistName = artistName;
        AlbumId = albumId;
        AlbumName = albumName;
    }

    public static MusicTrack Create(dynamic o)
    {
        var id = (ulong)(o.id ?? 0);
        var title = (string)(o.title ?? "");
        var duration = (int)(o.duration ?? 0);
        var artistId = (ulong)(o.artist?.id ?? 0);
        var artistName = (string)(o.artist?.name ?? "");
        var albumId = (ulong)(o.album?.id ?? 0);
        var albumTitle = (string)(o.album.title ?? "");
        return new MusicTrack(id, title, duration, artistId, artistName, albumId, albumTitle);
    }

    public override string ToString() =>
        $@"Track ID: {Id}
Title: {Title}
Duration: {Duration}
Artist ID: {ArtistId}
Artist name: {ArtistName}
Album ID: {AlbumId}
Album name: {AlbumName}
";
}