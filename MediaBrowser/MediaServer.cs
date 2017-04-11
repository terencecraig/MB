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
        private readonly Func<string,IMediaDirectory> _directoryFactory;
        private readonly IDictionary<string, IMediaDirectory> MapFileWatchers = new Dictionary<string, IMediaDirectory>();

        public BaseMediaServer( IMediaServerConfiguration config, Func<string,IMediaDirectory> directoryFactory, ILogger log)
        {
            if (directoryFactory == null)
                throw new ArgumentNullException(nameof(directoryFactory));

            Configure(config); //Restore persistance settings. 
            
            _directoryFactory = directoryFactory;
        }

        private void Configure(IMediaServerConfiguration config)
        {
            throw new NotImplementedException();
        }

        public void AddMediaDirectory(string uri)
        {
            var rsw = new ReactiveFileSystemWatcher(new FileSystemWatcher(uri)); //Set watch on the directory. 
            var dir = _directoryFactory(uri);
            dir.Watcher = rsw;
            MapFileWatchers[uri] = dir;

        }

    }
}
