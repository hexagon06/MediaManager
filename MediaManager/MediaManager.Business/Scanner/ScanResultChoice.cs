using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaManager.Business.Scanner
{
    internal class ScanResultChoice : IScanResultChoice
    {
        public IScanResult ScanResult { get; set; }
        public string Text
        {
            get
            {
                return ScanResult.Name;
            }
        }

        public bool? IsAddOption { get; set; }
        public bool? IsIgnoreOption { get; set; }
        
        public ScanResultChoice(IScanResult r)
            :base()
        {
            this.ScanResult = r;

            IsIgnoreOption = false;
            switch (r.Result)
            {
                case Business.ScanResult.New:
                    IsAddOption = true;
                    break;
                case Business.ScanResult.Unchanged:
                default:
                    break;
            }
        }

    }
}