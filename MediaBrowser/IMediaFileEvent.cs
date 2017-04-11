using System.IO;

namespace MediaBrowser
{
    public interface IMediaFileEvent
    {
        WatcherChangeTypes Action { get;  }
        string FileID { get; }


    }
}