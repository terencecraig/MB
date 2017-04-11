using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using System.Reactive.Linq;
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

            var foo = new List<String>() { "1.avi","2.avi", "3.avi"};

            var sut = new MediaDirectory("fakedir", 
                A.Fake<IObservable<IMediaFileEvent>>(), 
                (x => A.Fake<IMediaFile>()));

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
