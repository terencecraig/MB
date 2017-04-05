using System;
using System.Reactive.Linq;
using System.Reactive;
using System.IO;
namespace MediaBrowser
{
    public class MediaDirectory
    {
        private string _path;
        
        

        public MediaDirectory(string dirpath, IObservable<string> filesStreams, IObservable<FileSystemEventArgs> fileEventsStream)
        {
            this._path = dirpath;
            this.MediaFileEventsStream
                = from f in fileEventsStream
                  where f.IsVideoFile()
                  select f;
           filesStreams.
           
        }

        public IObservable<FileSystemEventArgs> MediaFileEventsStream { get; private set; }
        

        public IObservable<IMediaFile> MediaFileStream()
        {
            return from file in FilesStreams
                   where file.IsVideoFile()
                   select new MediaFile(file);
        }
        private void ProcessDirectoryUpdate(FileSystemEventArgs x)
        {
            
        }
    }
}