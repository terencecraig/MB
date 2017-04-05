using System;
using System.Reactive.Linq;
using System.Reactive;
using System.IO;

namespace MediaBrowser
{
    public static class MediaExtensions
    {
        public enum MediaType {avi,wmv, mp4, Unknown };
        public static bool IsVideoFile(this string fullPath)
        {
            var ext = Path.GetExtension(fullPath);
            if (ext.Equals("wmv") ||
                ext.Equals("mp4") ||
                    ext.Equals("avi"))
            {
                return true;
            }
            else return false;
        }

        public static bool IsVideoFile(this FileSystemEventArgs ev)
        {
            return IsVideoFile(ev.FullPath);
        }
    }

    
}