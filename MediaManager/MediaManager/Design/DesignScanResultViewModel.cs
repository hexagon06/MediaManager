using MediaManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MediaManager.Design
{
    class DesignScanResultViewModel : ObservableCollection<IScanResultChoice>, IScanResultViewModel
    {
        public string Label { get; set; }

        public ICommand IgnoreAllCommand => throw new NotImplementedException();

        public ICommand AddAllCommand => throw new NotImplementedException();
    }
}
