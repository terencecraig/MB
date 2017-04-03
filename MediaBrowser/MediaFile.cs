using System.IO;

namespace MediaBrowser
{
    public class MediaFile:IMediaFile
    {
        private FileSystemEventArgs file;

        public MediaFile(FileSystemEventArgs file)
        {
            this.file = file;
        }
    }
}