using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity.EntityConfiguration
{
    class MediaFileConfiguration : EntityTypeConfiguration<MediaFile>
    {
        public MediaFileConfiguration()
        {
            this.Property(m => m.MediaType);
            this.Property(m => m.DateAdded);
            this.Property(m => m.Label);
            this.Ignore(m => m.MetaData);
            this.Ignore(m => m.ProductionData);
        }
    }
}
