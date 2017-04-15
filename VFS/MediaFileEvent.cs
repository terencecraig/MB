using System;
using System.IO;

namespace VFS
{
    public class MediaFileEvent:IMediaFileEvent
    {
        public MediaFileEvent(string fileID, WatcherChangeTypes fileEventType)
        {
        }

        public WatcherChangeTypes FileAction => throw new NotImplementedException();

        public string FileID => throw new NotImplementedException();

        public string FileURI => throw new NotImplementedException();
    }
}