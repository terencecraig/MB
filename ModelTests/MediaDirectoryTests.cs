using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using FluentAssertions;
using MediaBrowser;
using System.Reactive.Subjects;
using FakeItEasy;

namespace ModelTests
{
    [TestClass]
    public class MediaDirectoryTests
    {
        [TestMethod]
        public void WatcherFindsAllVideoFiles()
        {

            var sut = new MediaDirectory(A.Fake<IObservable<FileSystemEventArgs>>());
            sut.MediaFileStream().Subscribe(x => Console.WriteLine(x));
            Assert.Fail();
        }

        [TestMethod]
        public void WatcherFindsAllVideoFilesInSubFolders()
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
