using System;
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
            var sut = new MediaDirectory(A.Fake<IObservable<IMediaFile>>());
            var cnt = sut.Files.Count();
            cnt.Should().BeSameAs(2);
        }

        [TestMethod]
        public void WatcherFindsAllVideoFilesInSubFolders()
        {

        }

        [TestMethod]
        public void DeleteExistingVideoCompletesSuccessfully()
        {

        }

    }
}
