using MediaManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;
using System.Collections.ObjectModel;

namespace MediaManager.Design
{
    class DesignLibraryViewModel : ILibraryViewModel
    {
        public ObservableCollection<IMediaFile> Media { get; set; }
    }
}
