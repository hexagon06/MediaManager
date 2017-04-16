using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Models
{
    internal abstract class AbstractMediaMetaData : IMediaMetaData
    {
        public AbstractMediaMetaData()
        {
            _Labels = new List<ILabel>();
            _Groups = new List<IGroup>();
        }

        public float Rating { get; set; }

        public string Description { get; set; }

        private List<ILabel> _Labels;

        public IEnumerable<ILabel> Labels
        {
            get
            {
                return _Labels;
            }
        }

        public void AddLabel(ILabel label)
        {
            _Labels.Add(label);
        }

        public void RemoveLabel(ILabel label)
        {
            _Labels.Remove(label);
        }

        private List<IGroup> _Groups;

        public IEnumerable<IGroup> Groups
        {
            get
            {
                return _Groups;
            }
        }

        public void AddGroup(IGroup group)
        {
            _Groups.Add(group);
        }

        public void RemoveGroup(IGroup group)
        {
            _Groups.Remove(group);
        }
    }
}
