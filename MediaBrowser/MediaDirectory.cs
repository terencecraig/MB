using System;
using System.Reactive.Linq;
using System.Reactive;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MediaBrowser
{
    /// <summary>
    /// The media directory is the domain root for this application. In keeping with SOLID principles & the Reactive manifesto this class is designed 
    /// with both construction injection and Rx in mind.
    /// 
    /// The Media directory offers the main public UI for the MediaBrowser library. 
    /// </summary>
    public class MediaDirectory : IMediaDirectory
    {
      
        private readonly IObservable<FileSystemEventArgs> _fileEvents;
        private readonly IEnumerable<string> _fileNames;
        private readonly Func<string,IMediaFile> _mediaFileFactory;
        private IObservable<IMediaFile> _filesManaged;

        /// <summary>
        /// Constructor.
        /// </summary>
        ///Media directory is delibertly insulated from the file system. Different implementation of <see cref=">IMediaFile"/> will deal with interactions
        /// with hardware/environment specific services such as playing a video file or retriving an icon.  The default implementation will be for Windows 10. But eventually I would like to write one for the roku. 
        /// <param name="fileNames">IEnumerable of the init</param>
        /// <param name="fileEvents"></param>
        /// 

        public MediaDirectory(IEnumerable<string> fileNames, IObservable<FileSystemEventArgs> fileEvents, Func<string,IMediaFile> mediaFileFactory)
        {
            if (fileNames == null)
                throw new ArgumentNullException(nameof(fileNames));


            if (fileEvents == null)
                throw new ArgumentNullException(nameof(fileEvents));

            if (mediaFileFactory == null)
                throw new ArgumentNullException(nameof(mediaFileFactory));

            _mediaFileFactory = mediaFileFactory;

            _fileEvents = from ev in fileEvents
                          where ev.IsVideoFile()
                          select ev;

            _fileNames = from file in fileNames
                         where file.IsVideoFile()
                         select file;


            _fileEvents.Subscribe(x =>
            {
                Log("Media directory has recieved a FSWE", x);
                switch (x.ChangeType)
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
                return null;
            }
        }

        public IObservable<IMediaFile> FilesManaged { get => _filesManaged;  }

        private void ProcessDirectoryUpdate(FileSystemEventArgs x)
        {
            
        }

     

    }
}