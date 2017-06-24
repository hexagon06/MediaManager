using System;
using System.Collections.Generic;
using MediaManager.Business;
using Microsoft.Win32;
using System.Linq;
using MediaManager.Resources;

namespace MediaManager.IoC
{
    internal class UserInput : IUserInput
    {
        public bool AskFolder(IStringRequest request)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            var result = dialog.ShowDialog();

            if(result == System.Windows.Forms.DialogResult.OK)
            {
                request.Input = dialog.SelectedPath;
                return true;
            }

            return false;
        }

        public IEnumerable<IScanResult> ProcessResult(string folderName, IEnumerable<IScanResult> result)
        {
            var changed = result.Where(r => r.Result != ScanResult.Unchanged);
            var viewmodel = IoCKernel.Get<IScanResultViewModel>(
                IoCKernel.Param("results", changed));
            viewmodel.Label = string.Format(StringFormats.ScanResultTitle, folderName);
            var window = new ScanResultWindow(viewmodel);

            if(window.ShowDialog()??false)
            {
                return viewmodel
                    .Where(c => (c.IsIgnoreOption ?? false) == false)
                    .Select(c => c.ScanResult)
                    .ToList();
            }

            return new List<IScanResult>();
        }
    }
}