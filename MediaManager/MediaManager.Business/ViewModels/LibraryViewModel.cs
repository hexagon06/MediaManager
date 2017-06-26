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

        public LibraryViewModel(IMediaFileController mediaFileController, IUserInput input)
        {
            MediaFileController = mediaFileController;
            Input = input;

            Media = new ObservableCollection<IMediaFile>(MediaFileController.GetList());
        }
    }
}
