using System;

namespace VFS
{
    public interface IMediaDirectory
    {
        IObservable<IMediaFile> FilesManaged { get; }
        IObservable<ICommandEvent> CommandEvents { get; }
        IReactiveFileSystemWatcher Watcher { get; set; }
    }
}