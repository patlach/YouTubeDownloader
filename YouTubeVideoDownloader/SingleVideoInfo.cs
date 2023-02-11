using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeVideoDownloader
{
    public class SingleVideoInfo
    {
        public async Task ShowInfo(string linkToVideo)
        {
            var youTube = new YoutubeClient();
            var video = await youTube.Videos.GetAsync("https://youtube.com/watch?v=u_yIGGhubZs");

            var title = video.Title; // "Collections - Blender 2.80 Fundamentals"
            var author = video.Author.ChannelTitle; // "Blender"
            var duration = video.Duration; // 00:07:20

            Console.WriteLine(title);
            Console.WriteLine(author);
            Console.WriteLine(duration);
        }
    }
}
