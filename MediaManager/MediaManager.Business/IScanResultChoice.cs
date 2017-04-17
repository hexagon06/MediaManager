using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    public interface IScanResultChoice
    {
        IScanResult ScanResult { get; set; }
        string Text { get; }
        bool? IsAddOption { get; set; }
        bool? IsIgnoreOption { get; set; }
    }
}
