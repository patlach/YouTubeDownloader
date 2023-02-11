using System;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


namespace YouTubeVideoDownloader
{
    public class Playlist
    {
        public async Task Download(string linkToPlaylist) 
        {
            var youTube = new YoutubeClient();

            //"https://www.youtube.com/playlist?list=PL7KtZC4GHpj7mbhQYasIBECuX6Gf6RUO7"
            await foreach (var video in youTube.Playlists.GetVideosAsync(linkToPlaylist))
            {
                Console.WriteLine($"start download {video.Title}");
                var streamManifest = await youTube.Videos.Streams.GetManifestAsync(video.Url);

                var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();

                if (streamInfo is null)
                {
                    Console.Error.WriteLine("This video has no muxed streams.");
                    return;
                }

                var name = $"{video.Title}.{ streamInfo.Container.Name }";

                using (var progress = new ConsoleProgress())
                    await youTube.Videos.Streams.DownloadAsync(streamInfo, name, progress);

                Console.WriteLine($"end download {video.Title}");
            }
        }
    }
}
