using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace MediaBrowser
{    public class MediaFile: IMediaFile
    {
        
        MediaExtensions.MediaType type = MediaExtensions.MediaType.Unknown;
        IObservable<IMediaFileEvent> _fileEventStream = null;
        private string _uri;
        private readonly IObservable<ICommandEvent> _commandStream;

        public Icon Thumbnail { get; set; } = null;
        public string FullPath
        {
            get { return _uri; }
        }

        private Task LaunchPlayer() //Delibertly private will only be called as an observable side effect to IPlayEvent ....
        {
            
            return Task.CompletedTask;
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public MediaFile(string uri,  IObservable<IMediaFileEvent> fileEventStream)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

           

            _uri = uri;

            _fileEventStream = from fev in fileEventStream
                               where fev.FileID == uri
                               select fev;
          
        }

    }

}