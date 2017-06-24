using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity.Configuration
{
    public class MediaTypeSection : ConfigurationSection
    {
        [ConfigurationProperty("Types", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(MediaTypeCollection))]
        public MediaTypeCollection Types
        {
            get
            {
                return (MediaTypeCollection)base["Types"];
            }
        }
    }
}
