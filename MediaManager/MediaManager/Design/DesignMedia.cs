using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Design
{
    class DesignMedia : IMediaFile
    {
        public DateTime DateAdded { get; set; }

        public string Label { get; set; }

        public int MediaFileId { get; set; }

        public string MediaType { get; set; }

        public IMediaMetaData MetaData { get; set; }

        public IProductionData ProductionData { get; set; }
    }
}
