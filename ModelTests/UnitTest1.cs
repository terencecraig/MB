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
    public class UnitTest1
    {
        [TestMethod]
        public void WatcherFindsAllVideoFiles()
        {

            var sut = new MediaDirectory(A.Fake<IObservable<FileSystemEventArgs>>());
            var cnt = sut.MediaFileStream().Subscribe()
            cnt.Should().BeSameAs(2);
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
