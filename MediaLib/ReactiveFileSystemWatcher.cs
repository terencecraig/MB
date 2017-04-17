//Terence: This class ReactiveFileSystemWatcher was based on 
//https://github.com/g0t4/Rx-FileSystemWatcher all credit to the original author(s). 
//Any mistakes added are mine. I would have just used the nuget package but it is not 
//compatable with RX 3 the current version at the time of this writing.
using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;

namespace MediaLib
{


    /// <summary>
    ///     This is a wrapper around a file system watcher to use the Rx framework instead of event handlers to handle
    ///     notifications of file system changes.
    /// </summary>
    public class ReactiveFileSystemWatcher<T>: IDisposable, IReactiveFileSystemWatcher<T> where T:class
    {
        private readonly FileSystemWatcher Watcher;
        private readonly Func<EventPattern<FileSystemEventArgs>, T>   _changed;
        private readonly Func<EventPattern<FileSystemEventArgs>, T>   _created;
        private readonly Func<EventPattern<FileSystemEventArgs>, T>   _deleted;
        private readonly Func<EventPattern<ErrorEventArgs>, T>        _errored;
        private readonly Func<EventPattern<RenamedEventArgs>, T>      _renamed;

        public IObservable<T> Changed => Observable
                    .FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(h => Watcher.Changed += h, h => Watcher.Changed -= h)
                    .Select(x => _changed(x));

        public IObservable<T> Created => Observable
                    .FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(h => Watcher.Created += h, h => Watcher.Created -= h)
                    .Select(x => _created(x));

        public IObservable<T> Deleted => Observable
                    .FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(h => Watcher.Deleted += h, h => Watcher.Deleted -= h)
                    .Select(x => _deleted(x));

        public IObservable<T> Errors => Observable
                    .FromEventPattern<ErrorEventHandler, ErrorEventArgs>(h => Watcher.Error += h, h => Watcher.Error -= h)
                    .Select(x => _errored(x));

        public IObservable<T> Renamed => Observable
                    .FromEventPattern<RenamedEventHandler, RenamedEventArgs>(h => Watcher.Renamed += h, h => Watcher.Renamed -= h)
                    .Select(x => _renamed(x));

        /// <summary>
        //Be aware that disposing this wrapper will dispose the FileSystemWatcher instance too.
        /// </summary>
        /// <param name="watcher"></param>
        public ReactiveFileSystemWatcher(FileSystemWatcher watcher,
            Func<EventPattern<FileSystemEventArgs>, T> changed,
            Func<EventPattern<FileSystemEventArgs>, T> created,
            Func<EventPattern<RenamedEventArgs>, T> renamed,
            Func<EventPattern<FileSystemEventArgs>, T> deleted,
            Func<EventPattern<ErrorEventArgs>, T> errored)
        {
            if (changed == null)
                throw new ArgumentNullException(nameof(changed));

            if (created == null)
                throw new ArgumentNullException(nameof(created));

            if (renamed == null)
                throw new ArgumentNullException(nameof(renamed));

            if (deleted == null)
                throw new ArgumentNullException(nameof(deleted));

            if (errored == null)
                throw new ArgumentNullException(nameof(errored));

            Watcher = watcher;
            _changed = changed;
            _created = created;
            _created = created;
            _renamed = renamed;
            _deleted = deleted;
            _errored = errored;
        }


        public void Start()
            {
                Watcher.EnableRaisingEvents = true;
            }

            public void Stop()
            {
                Watcher.EnableRaisingEvents = false;
            }

            public void Dispose()
            {
                Watcher.Dispose();
            }
        }
}