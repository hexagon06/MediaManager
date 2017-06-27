using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business.ViewModels
{
    class LibraryViewModel : ILibraryViewModel
    {
        public ObservableCollection<IMediaFile> Media { get; private set; }

        private IMediaFileController MediaFileController { get; set; }
        private IUserInput Input { get; set; }
        private IMediaSubscription Subscription { get; set; }

        public LibraryViewModel(IMediaFileController mediaFileController, IUserInput input, IMediaSubscription subscription)
        {
            MediaFileController = mediaFileController;
            Input = input;
            Subscription = subscription;

            subscription.Subscribe(NewMediaHandler);

            Media = new ObservableCollection<IMediaFile>(MediaFileController.GetList());
        }

        private void NewMediaHandler(object sender, NewMediaEventArgs e)
        {
            foreach (var media in e.Media)
            {
                Media.Add(media);
            }
        }
    }
}
