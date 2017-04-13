using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Subjects;

namespace MediaBrowser
{
    public class BaseMediaServer:IMediaServer
    {
        private readonly IObservable<FileSystemEventArgs> _fileEvents;
        private readonly ISubject<IMediaFileEvent> _mediaEvents = new Subject<IMediaFileEvent>();
        private readonly Func<string,IReactiveFileSystemWatcher,IMediaDirectory> _directoryFactory;
        private readonly IDictionary<string, IMediaDirectory> MapFileWatchers = new Dictionary<string, IMediaDirectory>();
        private readonly ILogger _log;

        public BaseMediaServer( IMediaServerConfiguration config, 
            Func<string,IReactiveFileSystemWatcher,
            MediaDirectory> directoryFactory, 
            ILogger log)
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
            //TODO: Replace with an autofac Resolve call. 
            var rsw = new ReactiveFileSystemWatcher(new FileSystemWatcher(uri)); //Set watch on the directory. 
            var dir = _directoryFactory(uri,rsw);
            MapFileWatchers[uri] = dir;
        }

    }
}
