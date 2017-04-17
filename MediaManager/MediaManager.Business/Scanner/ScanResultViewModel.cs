using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaManager.Business.Scanner
{
    class ScanResultViewModel : Collection<IScanResultChoice>, IScanResultViewModel
    {
        public string Label { get; set; }

        public ICommand IgnoreAllCommand { get { return new RelayCommand(ExecuteIgnoreAll); } }

        public ICommand AddAllCommand { get { return new RelayCommand(ExecuteAddAll); } }

        public ScanResultViewModel(IEnumerable<IScanResult> results)
            : base(results.Select(r => (IScanResultChoice)new ScanResultChoice(r)).ToList())
        {
        }

        private void ExecuteIgnoreAll()
        {
            foreach(var choice in this.Where(r=>r.IsIgnoreOption != null))
            {
                choice.IsIgnoreOption = true;
            }
        }

        private void ExecuteAddAll()
        {
            foreach (var choice in this.Where(r => r.IsAddOption != null))
            {
                choice.IsAddOption = true;
            }
        }

    }
}
