using System;

namespace MediaBrowser
{
    public interface IMediaDirectory
    {
        IObservable<IMediaFile> FilesManaged { get; }
        IObservable<ICommandEvent> CommandEvents { get; }
    }
}