using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;

namespace MediaManager.Business.Scanner
{
    internal class ScanResult : IScanResult
    {
        public Business.ScanResult Result { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Extension {get;set;}
    }
}
