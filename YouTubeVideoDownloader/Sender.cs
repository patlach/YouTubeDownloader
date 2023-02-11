using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeVideoDownloader
{
    class Sender
    {
        Download _download;

        public void SetCommand(Download download)
        {
            _download = download;
        }

        // Выполнить
        public void Run(string link)
        {
            _download.Run(link);
        }
    }
}
