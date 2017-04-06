using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using System.Reactive.Linq;
using FluentAssertions;
using MediaBrowser;

using FakeItEasy;
using System.Reactive.Disposables;

namespace ModelTests
{
    [TestClass]
    public class MediaDirectoryTests
    {
         
        [TestMethod]
        public void MediaDirectoryIgnoresNonVideoFiles()
        {

            var foo =   Observable.Create<string>(o =>
            {
                o.OnNext("1.avi");
                o.OnNext("2.avi");
                o.OnNext("1.mp4");
                o.OnNext("1.mp23");
                o.OnCompleted();
                return Disposable.Empty;

            });
            var sut = new MediaDirectory(foo.ToEnumerable(), 
                A.Fake<IObservable<FileSystemEventArgs>>(), 
                (x => A.Fake<IMediaFile>()));

            sut.MediaFileStream.Count().ShouldBeEquivalentTo(3);
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
