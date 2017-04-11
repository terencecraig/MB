using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.Reactive.Testing;
using FluentAssertions;
using MediaBrowser;

using FakeItEasy;
using System.Reactive.Disposables;
using System.Collections.Generic;

namespace ModelTests
{
    [TestClass]
    public class MediaDirectoryTests
    {

        [TestMethod]
        public void MediaDirectoryIgnoresNonVideoFiles()
        {
            var events = new List<IMediaFileEvent>()
            {
                new MediaFileEvent("fakedir", WatcherChangeTypes.Created)
            }
            .ToObservable();
            var sut = new MediaDirectory("fakedir",
                events,
                (x =>
              
                     new MediaFile(x, events)
                ));
            sut.FilesManaged.Count().ShouldBeEquivalentTo(3);
        }

        [TestMethod]
        public void MediaFilesStreamAllVideoFilesInMediaDirectoryRegardlessOfSubfolderStructure()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteExistingVideoCompletesSuccessfully()
        {
            Assert.Fail();
        }

    }
}
