using MediaManager.Business.ViewModels;
using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    public interface ILibraryViewModel
    {
        ObservableCollection<ISelectableMediaFile> Media { get; }
    }
}
