using MediaManager.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Design
{
    class DesignScanResultChoice : IScanResultChoice
    {
        public IScanResult ScanResult { get; set; }
        public string Text { get; set; }
        public bool? IsAddOption { get; set; }
        public bool? IsIgnoreOption { get; set; }
    }
}
