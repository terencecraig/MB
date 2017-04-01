using System;
using System.IO;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;

namespace SaveAllTheTime.Models
{
    interface IFilesystemWatchCache
    {
        IObservable<string> Register(string directory, string filter = null);
    }

    public class FilesystemWatchCache : IFilesystemWatchCache
    {
        MemoizingMRUCache<Tuple<string, string>, IObservable<string>> watchCache = new MemoizingMRUCache<Tuple<string, string>, IObservable<string>>((pair, _) => {
            return Observable.Create<string>(subj => {
                var disp = new CompositeDisposable();

                var fsw = pair.Item2 != null ? 
                    new FileSystemWatcher(pair.Item1, pair.Item2) : 
                    new FileSystemWatcher(pair.Item1);

                disp.Add(fsw);

                var allEvents = Observable.Merge(
                    Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(x => fsw.Changed += x, x => fsw.Changed -= x),
                    Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(x => fsw.Created += x, x => fsw.Created -= x),
                    Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(x => fsw.Deleted += x, x => fsw.Deleted -= x));

                disp.Add(allEvents.Throttle(TimeSpan.FromMilliseconds(250), RxApp.TaskpoolScheduler)
                    .Select(x => x.EventArgs.FullPath)
                    .Synchronize(subj)
                    .Subscribe(subj));

                fsw.EnableRaisingEvents = true;
                return disp;
            }).Publish().RefCount();
        }, 25);

        public IObservable<string> Register(string directory, string filter = null)
        {
            lock (watchCache) {
                return watchCache.Get(Tuple.Create(directory, filter));
            }
        }
    }
}