using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity.Configuration
{
    public class MediaTypeCollection : ConfigurationElementCollection
    {
        public MediaTypeElement this[int index]
        {
            get { return (MediaTypeElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MediaTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as MediaTypeElement).Name;
        }
    }
}
