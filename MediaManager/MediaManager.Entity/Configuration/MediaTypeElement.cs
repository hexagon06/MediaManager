using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity.Configuration
{
    public class MediaTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
        [ConfigurationProperty("extensions", IsRequired = true)]
        public string ExtensionString
        {
            get
            {
                return (string)this["extensions"];
            }
            set
            {
                this["extensions"] = value;
            }
        }

        public IEnumerable<string> Extensions
        {
            get
            {
                return ExtensionString.Split(',');
            }
        }
    }
}
