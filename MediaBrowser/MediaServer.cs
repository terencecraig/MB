using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBrowser
{
    public class MediaServer
    {
        public MediaServer(IMediaServerConfiguration config, ILogger log)
        {
            Restore(config); //Restore persistance settings. 
        }

        private void Restore(IMediaServerConfiguration config)
        {
            throw new NotImplementedException();
        }

        private IMediaDirectory AddDirectory(string id)
        {
            throw new NotImplementedException();
        }
    }
}
