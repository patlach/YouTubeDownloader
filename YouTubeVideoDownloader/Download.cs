using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader
{
    abstract class Download
    {
        public abstract Task Run(string link);
    }
}
