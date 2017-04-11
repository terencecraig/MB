using System.IO;

namespace MediaBrowser
{
    public interface IMediaFileEvent
    {
        WatcherChangeTypes FileAction { get;  }
        string FileID { get; }


    }
}