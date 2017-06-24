using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Configuration
{
    using Entity.Configuration;

    static class ApplicationConfig
    {
        public static MediaTypeSection MediaTypes {
            get
            {
                var section = ConfigurationManager.GetSection("MediaTypes");
                return section as MediaTypeSection;
            }
        }
    }
}
