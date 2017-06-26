using System.Collections.Generic;

namespace MediaManager.Entity
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class AbstractMediaMetaData : IMediaMetaData
    {
        [Key]
        public int MetaDataId { get; set; }
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

        private List<IGroup> _Groups;
        public IEnumerable<IGroup> Groups
        {
            get
            {
                return _Groups;
            }
        }

        //public int MediaId { get; set; }
        [ForeignKey("MediaFileId"), Required]
        public MediaFile Media { get; set; }
        public IMediaFile MediaFile { get { return Media; } set { Media = value as MediaFile; } }

        public AbstractMediaMetaData()
        {
            _Labels = new List<ILabel>();
            _Groups = new List<IGroup>();
        }



        public void AddLabel(ILabel label)
        {
            _Labels.Add(label);
        }

        public void RemoveLabel(ILabel label)
        {
            _Labels.Remove(label);
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
