using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business.Scanner
{
    class ScanResultViewModel : Collection<IScanResultChoice>, IScanResultViewModel
    {
        public string Label { get; set; }
        
        public ScanResultViewModel(IEnumerable<IScanResult> results)
            :base(results.Select(r => (IScanResultChoice)new ScanResultChoice(r)).ToList())
        {
        }
    }
}
