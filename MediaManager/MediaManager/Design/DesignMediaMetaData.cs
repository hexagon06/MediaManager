using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Design
{
    class DesignMediaMetaData : IMediaMetaData
    {
        public int MetaDataId { get; set; }
        public string Description { get; set; }

        public IEnumerable<IGroup> Groups { get; set; }

        public IEnumerable<ILabel> Labels { get; set; }
        

        public float Rating { get; set; }

        public IMediaFile MediaFile { get; set; }

        public void AddGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void AddLabel(ILabel label)
        {
            throw new NotImplementedException();
        }

        public void RemoveGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void RemoveLabel(ILabel label)
        {
            throw new NotImplementedException();
        }
    }
}
