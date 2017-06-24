using MediaManager.Business;
using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaManager.Design
{
    class DesignExplorerViewModel : IExplorerViewModel
    {
        public ICommand RescanAllCommand { get; set; }

        public ICommand AddFolderCommand { get; set; }

        public ICommand RescanSingleCommand { get; set; }

        public ObservableCollection<IFolder> Folders { get; set; }
    }
}
