using System; 
using System.IO;

using System.Reactive.Linq;
using Microsoft.Reactive.Testing;
using FluentAssertions;

using System.Collections.Generic;
using System.Linq;
using FakeItEasy;

using MediaLib;
using Xunit;

namespace MediaLibTests
{
  
    public class MediaServerTests
    {
        
        [Fact]
        public void ExceptionIsThrownForNullDirectoryURI()
        {
            var sut = new BaseMediaServer(A.Fake<IMediaServerConfiguration>(),
                (s,  rsw) => A.Fake<IMediaDirectory>(),  
                A.Fake<object>());

           Action a = () => sut.AddMediaDirectory(null);
          
            
                 
                 a.ShouldThrow<ArgumentException>();
        }


        [Fact]
        public void ExceptionIsThrownForEmptyURI()
        //Bad in this case means not a valid file system
        //for the particular directory implementation invoked.
        {

        
            //No exception thrown by constructor because given deferred execution, even if the directory doesn't 
            //exist at the time the MediaDirectory is created that doesn't mean it won't be there before execution stops being deferred. 
            //Note that a non-existant directory is different from an empty one. Non existant directories will cause an exeception on subscription.  
            var sut = new BaseMediaServer(A.Fake<IMediaServerConfiguration>(),
                (s, rsw) => A.Fake<MediaDirectory>(),  //TODO: Clean up signature and a real logging factory.
                A.Fake<object>());

            Action a = () => sut.AddMediaDirectory("");
            a.ShouldThrow<ArgumentException>();
        }


         [Fact]
        public void EventuallyAnExceptionIsThrownForNonExistantContainerURI()
        {

           
            var scheduler = new TestScheduler();
            scheduler.AdvanceBy(10);

            //No exception thrown by constructor because given deferred execution, even if the directory doesn't 
            //exist at the time the MediaDirectory is created that doesn't mean it won't be there before execution stops being deferred. 
            //Note that a non-existant directory is different from an empty one. Non existant directories will cause an exeception on subscription.  
            var sut = new BaseMediaServer(A.Fake<IMediaServerConfiguration>(),
                (string s, IMediaFileWatcher rsw) => A.Fake<MediaDirectory>(),  //Nasty. 
                A.Fake<object>());
            IObservable<IMediaDirectory> foo = sut.Directories;
            IObservable<IMediaFile> bar = sut.MediaFiles;
            Action a = () => sut.AddMediaDirectory("");

         
            /*
            scheduler.Schedule(a());
           
            //Schedule the OnNext
            scheduler.Schedule(() => priceStream.OnNext(expected));
            Assert.AreEqual(0, _viewModel.Prices.Count);
            //Execute the OnNext action
            _schedulerProvider.ThreadPool.AdvanceBy(1);
            Assert.AreEqual(0, _viewModel.Prices.Count);
            //Execute the OnNext handler
            _schedulerProvider.Dispatcher.AdvanceBy(1);
            Assert.AreEqual(1, _viewModel.Prices.Count);
            Assert.AreEqual(expected, _viewModel.Prices.First());
            
            
            */
        }


    }
}
