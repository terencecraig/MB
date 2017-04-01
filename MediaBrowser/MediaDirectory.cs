using System;
using System.Reactive.Subjects;

namespace MediaBrowser
{
    public class MediaDirectory
    {

        ISubject<IMediaFile,IMediaFile> files = null; 
        public MediaDirectory(IObservable<IMediaFile> fileWatcher)
        {
            fileWatcher.Subscribe(x => this.ProcessDirectoryUpdate(x));
        }

        public ISubject<IMediaFile, IMediaFile> Files { get => files; set => files = value; }

        private void ProcessDirectoryUpdate(IMediaFile x)
        {
            
        }
    }
}