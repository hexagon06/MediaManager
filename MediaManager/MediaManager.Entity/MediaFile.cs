using System;

namespace MediaManager.Entity
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MediaFile : IMediaFile
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, ForeignKey("Id")]
        public int MediaFileId { get; set; }

        public File File { get; set; }
        //public int FileId { get; set; }
        public string MediaType { get; set; }
        public string Label { get; set; }
        public DateTime DateAdded { get; set; }
        public IMediaMetaData MetaData { get; set; }
        public IProductionData ProductionData { get; set; }
    }
}
