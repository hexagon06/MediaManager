using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Scanner
{
    public enum CompareResult
    {
        NoChange,
        New,
        Removed,
        Moved
    }

    public class ScanCompareResult
    {
        public IFile NewScan { get; set; }
        public IFile OldScan { get; set; }
        public CompareResult Result { get; set; }
    }
}
