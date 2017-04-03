using System;
using System.Reactive.Linq;
using System.Reactive;
using System.IO;
namespace MediaBrowser
{
    public class MediaDirectory
    {
        private IObservable<FileSystemEventArgs> _fileStream = null;
     
        public MediaDirectory(IObservable<FileSystemEventArgs> fileStream)
        {
            _fileStream = fileStream;
        }

        
        public IObservable<IMediaFile> MediaFileStream()
        {
            return from file in _fileStream
                   where file.IsVideoFile()
                   select new MediaFile(file);
        }
        private void ProcessDirectoryUpdate(FileSystemEventArgs x)
        {
            
        }
    }
    public static class MediaExtensions
    {
        public static bool IsVideoFile(this FileSystemEventArgs self)
        {
            var ext = Path.GetExtension(self.FullPath);
            if (ext.Equals("wmv") ||
                ext.Equals("mp4") ||
                    ext.Equals("avi"))
            {
                return true;
            }
            else return false;
        }
    }
}