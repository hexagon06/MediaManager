using MediaManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MediaManager.Design
{
    class DesignScanResultViewModel : ObservableCollection<IScanResultChoice>, IScanResultViewModel
    {
        public string Label { get; set; }
    }
}
