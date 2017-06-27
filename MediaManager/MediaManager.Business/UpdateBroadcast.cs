using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager
{
    public interface IMediaBroadcaster
    {
        void SendNewMediaMessage(IEnumerable<IMediaFile> newMedia);
    }

    public interface IMediaSubscription
    {
        void Subscribe(EventHandler<NewMediaEventArgs> handler);
        void UnSubscribe(EventHandler<NewMediaEventArgs> handler);
    }

    internal class UpdateBroadcast : IMediaBroadcaster
    {
        public static event EventHandler<NewMediaEventArgs> NewMediaHandler;
        
        public void SendNewMediaMessage(IEnumerable<IMediaFile> newMedia)
        {
            var handler = NewMediaHandler;
            if(handler != null)
            {
                var args = new NewMediaEventArgs(newMedia);
                handler(this, args);
            }
        }
    }

    internal class UpdateSubscription : IMediaSubscription
    {
        public void Subscribe(EventHandler<NewMediaEventArgs> handler)
        {
            UpdateBroadcast.NewMediaHandler += handler;
        }
        public void UnSubscribe(EventHandler<NewMediaEventArgs> handler)
        {
            UpdateBroadcast.NewMediaHandler -= handler;
        }
    }

    public class NewMediaEventArgs : EventArgs
    {
        public IEnumerable<IMediaFile> Media { get; private set; }

        public NewMediaEventArgs(IEnumerable<IMediaFile> newMedia)
        {
            Media = newMedia;
        }
    }
}
