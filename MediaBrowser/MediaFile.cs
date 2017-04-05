using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace MediaBrowser
{
    public class MediaFile:IMediaFile
    {
        string _path = null;
        MediaExtensions.MediaType type = MediaExtensions.MediaType.Unknown;
        

        public MediaFile(string path)
        {
            _path = path;
        }

        public Icon Thumbnail { get; set; } = null;
        public Task LaunchPlayer()
        {
            return Task.CompletedTask;
        }
    }
}