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
        IObservable<FileSystemEventArgs> _fileEventStream = null;
        private string _fullPath;
        private readonly IObservable<ICommandEvent> _commandStream;

        public Icon Thumbnail { get; set; } = null;
        public string FullPath
        {
            get { return _fullPath; }
        }

        private Task LaunchPlayer() //Delibertly private will only be called as an observable side effect to IPlayEvent ....
        {
            
            return Task.CompletedTask;
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public MediaFile(string fullPath, IObservable<ICommandEvent> commandStream, IObservable<FileSystemEventArgs> fileEventStream)
        {
            if (fullPath == null)
                throw new ArgumentNullException(nameof(fullPath));

            if (commandStream == null)
                throw new ArgumentNullException(nameof(commandStream));

            _fullPath = fullPath;

            _fileEventStream = from fev in fileEventStream
                               where fev.FullPath == FullPath
                               select fev;
            _commandStream = from cmd in commandStream
                             where cmd.TargetID == FullPath
                             select cmd;
        }

    }

}