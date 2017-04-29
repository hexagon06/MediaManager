using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaManager.Business.ViewModels
{
    class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        private static readonly string KEY_ACCEPTED_VIDEO_FORMATS = "acceptedVideoFormats";

        private string acceptedVideoFormats;
        public string AcceptedVideoFormats
        {
            get { return acceptedVideoFormats; }
            set
            {
                acceptedVideoFormats = value;
                RaisePropertyChanged("AcceptedVideoFormats");
            }
        }
        public ICommand SaveSettingsCommand { get { return new RelayCommand(ExecuteSaveSettings); } }
        private ISettingController Controller { get; set; }

        public SettingsViewModel(ISettingController controller)
        {
            Controller = controller;
            LoadSettings();
        }

        private void ExecuteSaveSettings()
        {
            Controller.SaveSetting(KEY_ACCEPTED_VIDEO_FORMATS, AcceptedVideoFormats);
        }

        private void LoadSettings()
        {
            var stored = Controller.GetAll();

            AcceptedVideoFormats = GetSetting(KEY_ACCEPTED_VIDEO_FORMATS, stored);
        }

        private static string GetSetting(string key, Dictionary<string, string> stored)
        {
            if(stored.ContainsKey(key))
            {
                return stored[key];
            }
            else
            {
                return ConfigurationManager.AppSettings[key] ?? string.Empty;
            }
        }
    }
}
