//This class ReactiveFileSystemWatcher was copied from 
//https://github.com/g0t4/Rx-FileSystemWatcher all credit to the original author. 
//Any mistakes added are mine. I would have just used the nuget package but it is not 
//compatable with RX 3 the current version at the time of this writing.
using System;
using System.IO;

namespace MediaLib
{

    using System;
    using System.IO;
    using System.Reactive;
    using System.Reactive.Linq;
    public class MediaFileWatcher : ReactiveFileSystemWatcher<IMediaFileEvent>, IMediaFileWatcher
    {
        public MediaFileWatcher(FileSystemWatcher watcher) : 
            //Todo fill in conversion functions. 
            base(watcher,
            ( x => null),
            (x => null),
            (x => null),
            (x => null),
            (x => null))
        {

        }

    }
}