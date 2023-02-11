using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeVideoDownloader
{
    class SingleVideoInfo : Download
    {
        Receiver receiver;

        public SingleVideoInfo(Receiver receiver)
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
                var video = await youTube.Videos.GetAsync(link);

                var title = video.Title; // "Collections - Blender 2.80 Fundamentals"
                var author = video.Author.ChannelTitle; // "Blender"
                var duration = video.Duration; // 00:07:20

                Console.WriteLine(title);
                Console.WriteLine(author);
                Console.WriteLine(duration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
