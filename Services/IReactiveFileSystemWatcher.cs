using System;
using System.IO;

namespace VFS 
{
    public interface IReactiveFileSystemWatcher
    {
        IObservable<FileSystemEventArgs> Changed { get; }
        IObservable<FileSystemEventArgs> Created { get; }
        IObservable<FileSystemEventArgs> Deleted { get; }
        IObservable<ErrorEventArgs> Errors { get; }
        IObservable<RenamedEventArgs> Renamed { get; }

        void Dispose();
        void Start();
        void Stop();
    }
}