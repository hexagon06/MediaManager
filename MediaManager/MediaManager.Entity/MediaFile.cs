using System;

namespace MediaManager.Entity
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MediaFile : IMediaFile
    {
        public int MediaFileId { get; set; }
        public string MediaType { get; set; }
        public string Label { get; set; }
        public DateTime DateAdded { get; set; }


        [ForeignKey("FileId")]
        public File File { get; set; }

        //public int? MediaMetaDataId { get; set; }
        [ForeignKey("MetaDataId")]
        public AbstractMediaMetaData MediaMetaData { get; set; }

        public IMediaMetaData MetaData { get { return MediaMetaData; } set { MediaMetaData = value as AbstractMediaMetaData; } }
        public IProductionData ProductionData { get; set; }
    }
}
