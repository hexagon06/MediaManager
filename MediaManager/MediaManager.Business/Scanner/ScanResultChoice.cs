using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaManager.Business.Scanner
{
    internal class ScanResultChoice : ViewModelBase, IScanResultChoice
    {
        public IScanResult ScanResult { get; set; }
        public string Text
        {
            get
            {
                return ScanResult.Name;
            }
        }

        private bool? isAddOption;
        private bool? isIgnoreOption;

        public bool? IsAddOption
        {
            get { return isAddOption; }
            set { Set<bool?>(() => this.IsAddOption, ref isAddOption, value); }
        }
        public bool? IsIgnoreOption
        {
            get { return isIgnoreOption; }
            set { Set<bool?>(() => this.IsIgnoreOption, ref isIgnoreOption, value); }
        }

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