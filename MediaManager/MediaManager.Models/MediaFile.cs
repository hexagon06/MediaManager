using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Models
{
    internal class MediaFile : MediaManager.Models.IMediaFile
    {
        public IFile FileInfo { get; set; }
        public string MediaType { get; set; }
        public DateTime DateAdded { get; set; }
        public IMediaMetaData MetaData { get; set; }
        public IProductionData ProductionData { get; set; }
    }
}
