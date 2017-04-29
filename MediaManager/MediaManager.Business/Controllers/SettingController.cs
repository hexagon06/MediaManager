using JLS.Data.Generic;
using MediaManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business.Controllers
{
    class SettingController : ISettingController
    {
        private IRepository<Setting> Repository { get; set; }

        public SettingController(IRepository<Setting> repo)
        {
            Repository = repo;
        }

        public Dictionary<string, string> GetAll()
        {
            return Repository.Entities.ToDictionary(s => s.Id, s => s.Value);
        }

        public string GetSetting(string key)
        {
            return Repository.Entities.SingleOrDefault(s => s.Id == key).Value;
        }

        public void SaveSetting(string key, string value)
        {
            var existing = Repository.Entities.SingleOrDefault(s => s.Id == key);
            if(existing == null)
            {
                Repository.Add(new Setting()
                {
                    Id = key,
                    Value = value
                });
            }
            else
            {
                existing.Value = value;
            }
            Repository.Save();
        }
    }
}
