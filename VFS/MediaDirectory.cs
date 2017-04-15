using System;
using System.Reactive.Linq;
using System.Reactive;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace VFS
{
    /// <summary>
    /// The media directory is the domain root for this application. In keeping with SOLID principles & the Reactive manifesto this class is designed 
    /// with both construction injection and Rx in mind.
    /// 
    /// The Media directory offers the main public UI for the VFS library. 
    /// </summary>
    public class MediaDirectory : IMediaDirectory, IDisposable
    {
      
      
 
        private readonly Func<string,IMediaFile> _mediaFileFactory;
        private readonly IObservable<IMediaFileEvent> _fileEvents;
        private readonly IObservable<IMediaFile> _filesManaged;

      
        public MediaDirectory(string uri, IObservable<IMediaFileEvent> fileEvents,  Func<string,IMediaFile> mediaFileFactory)
        {
            _fileEvents = fileEvents ?? throw new ArgumentNullException(nameof(fileEvents));
            _mediaFileFactory = mediaFileFactory ?? throw new ArgumentNullException(nameof(mediaFileFactory));

           
           _fileEvents.Subscribe(x =>
            {
                Log("Media directory has recieved a FSWE", x);
                switch (x.FileAction)
                {
                    case WatcherChangeTypes.Changed:
                        {
                            break;
                        }

                    case WatcherChangeTypes.Created:
                        {

                            //Add IMediaFile to an obs here._filesManaged.On(_mediaFileFactory(x.FullPath));
                            break;
                        }

                    case WatcherChangeTypes.Deleted:
                        {
                            break;
                        }

                    case WatcherChangeTypes.Renamed:
                        {
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("roh roh");
                            break;
                        }
                }
            });
            
        }

        private void Log<T>(string msg, T loggedObject = null) where T: class
        {
             Console.WriteLine(loggedObject != null ? msg + loggedObject.ToString() : msg);
        }

        public IObservable<ICommandEvent> CommandEvents  //Events caused by user action as opposed to File system. 
        {
            get
            {
                return _commands;
            }
        }

        public IObservable<IMediaFile> FilesManaged { get => _filesManaged;  }
        public IReactiveFileSystemWatcher Watcher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void ProcessDirectoryUpdate(FileSystemEventArgs x)
        {
            
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private readonly IObservable<ICommandEvent> _commands;
        private readonly IObservable<IMediaFileEvent> _files;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                   (_filesManaged as IDisposable).Dispose();// TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MediaDirectory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion



    }
}