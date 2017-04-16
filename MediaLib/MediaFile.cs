using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace MediaLib
{    public class MediaFile: IMediaFile
    {
        
        MediaExtensions.MediaType type = MediaExtensions.MediaType.Unknown;
        IObservable<IMediaFileEvent> _fileEventStream = null;
        private string _uri;
        private readonly IObservable<ICommandEvent> _commandStream;

        
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
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));

            _fileEventStream = from fev in fileEventStream
                               where fev.FileURI == uri
                               select fev;
          
        }

    }

}