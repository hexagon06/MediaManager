using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaManager.Business
{
    public interface ISettingsViewModel
    {
        string AcceptedVideoFormats { get; set; }
        ICommand SaveSettingsCommand { get; }
    }
}
