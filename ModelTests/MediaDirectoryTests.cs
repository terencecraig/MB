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
        public void FileEventStreamCapturesMediaChanges()
        {

            
            var sut = new MediaDirectory(@"./TestDir", A.Fake<IObservable<FileSystemEventArgs>>());
            sut.MediaFileStream().Subscribe(x => Console.WriteLine(x));
            Assert.Fail();
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
