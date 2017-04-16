using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Interfaces
{
    public interface IMediaMetaData
    {
        float Rating { get; set; }
        string Description { get; set; }

        IEnumerable<ILabel> Labels { get; } 
        void AddLabel(ILabel label);
        void RemoveLabel(ILabel label);

        IEnumerable<IGroup> Groups { get; }
        void AddGroup(IGroup group);
        void RemoveGroup(IGroup group);
    }
}
