using System.IO;

namespace MediaLib
{
    public interface IMediaFileEvent
    {
        WatcherChangeTypes FileAction { get;  }
        string FileURI { get; }


    }
}