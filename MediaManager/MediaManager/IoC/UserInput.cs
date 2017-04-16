using System;
using MediaManager.Business;
using Microsoft.Win32;

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
    }
}