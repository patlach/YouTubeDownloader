using System;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeVideoDownloader
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Link");
            string link = Console.ReadLine();
            // создадим отправителя
            var sender = new Sender();

            // создадим получателя
            var receiver = new Receiver();

            // создадим команду
            var singleVideo = new SingleVideo(receiver);
            var singleVideoInfo = new SingleVideoInfo(receiver);

            sender.SetCommand(singleVideo);
            sender.Run(link);

            sender.SetCommand(singleVideoInfo);
            sender.Run(link);
        }
    }
}
