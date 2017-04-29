using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    interface ISettingController
    {
        string GetSetting(string key);
        void SaveSetting(string key, string value);
        Dictionary<string, string> GetAll();
    }
}
