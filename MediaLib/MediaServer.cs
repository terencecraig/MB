using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Subjects;

namespace MediaLib
{
    public class BaseMediaServer:IMediaServer
    {
        private readonly IObservable<FileSystemEventArgs> _fileEvents;
        private readonly ISubject<IMediaFileEvent> _mediaEvents = new Subject<IMediaFileEvent>();
        private readonly Func<string,IReactiveFileSystemWatcher,IMediaDirectory> _directoryFactory;
        private readonly IDictionary<string, IMediaDirectory> _mapFileWatchers = new Dictionary<string, IMediaDirectory>();
        private readonly dynamic _log;

        public IObservable<IMediaDirectory> Directories { get; set; }
        public IObservable<IMediaFile> MediaFiles { get; set; }

        public BaseMediaServer( IMediaServerConfiguration config, 
            Func<string,IReactiveFileSystemWatcher,
            MediaDirectory> directoryFactory, 
            dynamic log)
        {

            //Configure(config); //Restore persistance settings. 

            _directoryFactory = directoryFactory ?? throw new ArgumentNullException(nameof(directoryFactory));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        private void Configure(IMediaServerConfiguration config)
        {
           
        }

        public void AddMediaDirectory(string uri)
        {
            if (!uri.IsValidString())
            {
                throw new ArgumentException($"The parameter {nameof(uri)} was null or empty");
            }
            //TODO: Replace with an autofac Resolve call. This will make the DI module the only place in the code that is platform aware. 
            var rsw = new ReactiveFileSystemWatcher(new FileSystemWatcher(uri)); //Set watch on the directory. 
            var dir = _directoryFactory(uri, rsw);
            _mapFileWatchers[uri] = dir;
        }
        public IMediaDirectory this[string index]
        {
            get
            {
              
                if (index.IsValidString())
                {
                    return _mapFileWatchers[index];
                }
                else
                {
                    throw new ArgumentException($"The parameter {nameof(index)} was null or empty");
                }
                    
            }
        }
    }
   
}
