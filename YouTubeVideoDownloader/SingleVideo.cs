using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


namespace YouTubeVideoDownloader
{
    public class SingleVideo
    {
        public async Task Download(string linkToVideo)
        {
            var youTube = new YoutubeClient();
            Console.WriteLine($"start download");
            var streamManifest = await youTube.Videos.Streams.GetManifestAsync(linkToVideo);

            var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();

            if (streamInfo is null)
            {
                Console.Error.WriteLine("This video has no muxed streams.");
                return;
            }

            var name = $"{ streamInfo.Container.Name }";

            using (var progress = new ConsoleProgress())
                await youTube.Videos.Streams.DownloadAsync(streamInfo, name, progress);

            Console.WriteLine($"end download");
        }
    }
}
