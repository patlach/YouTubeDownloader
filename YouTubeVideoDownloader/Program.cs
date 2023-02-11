using System;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeVideoDownloader
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Welcome to YouTube Downloader");
            Console.WriteLine("Choose what you want:");
            Console.WriteLine("Show video info - press 1");
            Console.WriteLine("Download one video - press 2");
            Console.WriteLine("Download playlist - press 3");

            try
            {
                int press = int.Parse(Console.ReadLine());

                switch (press)
                {
                    case 1:
                        Console.WriteLine("Enter link to video on YouTube");
                        string info = Console.ReadLine();
                        SingleVideoInfo singleVideoInfo = new SingleVideoInfo();
                        await singleVideoInfo.ShowInfo(info);
                        break;
                    case 2:
                        Console.WriteLine("Enter link to video on YouTube");
                        string video = Console.ReadLine();
                        SingleVideo singleVideo = new SingleVideo();
                        await singleVideo.Download(video);
                        break;
                    case 3:
                        Console.WriteLine("Enter link to playlist on YouTube");
                        string playlist = Console.ReadLine();
                        Playlist plist = new Playlist();
                        await plist.Download(playlist);
                        break;
                    default:
                        Console.WriteLine("try again");
                        break;

                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
