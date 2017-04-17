using System;
using System.IO;

namespace MediaLib 
{
    public interface IReactiveFileSystemWatcher<T>:IDisposable
    {
        IObservable<T> Changed { get; }
        IObservable<T> Created { get; }
        IObservable<T> Deleted { get; }
        IObservable<T> Errors { get; }
        IObservable<T> Renamed { get; }

        void Start();
        void Stop();
    }
}