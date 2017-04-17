using System;

namespace MediaLib
{
    public interface IMediaDirectory
    {
        IObservable<IMediaFile> FilesManaged { get; }
        IObservable<ICommandEvent> CommandEvents { get; }
        IReactiveFileSystemWatcher<IMediaFileEvent> Watcher { get; set; }
    }
}