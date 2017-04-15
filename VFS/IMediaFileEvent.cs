using System.IO;

namespace VFS
{
    public interface IMediaFileEvent
    {
        WatcherChangeTypes FileAction { get;  }
        string FileURI { get; }


    }
}