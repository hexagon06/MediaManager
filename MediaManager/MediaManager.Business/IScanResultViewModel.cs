using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaManager.Business
{
    public interface IScanResultViewModel : ICollection<IScanResultChoice>
    {
        string Label { get; set; }

        ICommand IgnoreAllCommand { get; }
        ICommand AddAllCommand { get; }
    }
}
