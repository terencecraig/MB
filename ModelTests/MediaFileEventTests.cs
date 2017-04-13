using System; 
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
//using Microsoft.Reactive.Testing;
using FluentAssertions;

using MediaBrowser;
using System.Collections.Generic;
using System.Linq;

namespace ModelTests
{
    [TestClass]
    public class MediaEventTests
    {


        dynamic events = new List<IMediaFileEvent>()
            {
                new MediaFileEvent("fakedir", WatcherChangeTypes.Created)
            }.ToObservable();

    }
}
