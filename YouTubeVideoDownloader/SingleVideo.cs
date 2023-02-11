using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeVideoDownloader
{
    class SingleVideo : Download
    {
        Receiver receiver;

        public SingleVideo(Receiver receiver)
        {
            this.receiver = receiver;
        }

        // Выполнить
        public override async Task Run(string link)
        {
            var youTube = new YoutubeClient();
            Console.WriteLine($"start download");

            try
            {
                var streamManifest = await youTube.Videos.Streams.GetManifestAsync(link);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
