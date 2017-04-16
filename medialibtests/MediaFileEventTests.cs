using System.IO;

using System.Reactive.Linq;
//using Microsoft.Reactive.Testing;
using System.Collections.Generic;
using MediaLib;
using Xunit;

namespace ModelTests
{
    
    public class MediaEventTests
    {


        dynamic events = new List<IMediaFileEvent>()
            {
                new MediaFileEvent("fakedir", WatcherChangeTypes.Created)
            }.ToObservable();

    }
}
