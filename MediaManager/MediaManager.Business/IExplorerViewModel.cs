using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaManager.Business
{
    public interface IExplorerViewModel
    {
        bool HasChanged { get; }

        ICommand RescanAllCommand { get; }
        ICommand AddFolderCommand { get; }
        ICommand RescanSingleCommand { get; }

        ObservableCollection<IFolder> Folders { get; }
    }
}
