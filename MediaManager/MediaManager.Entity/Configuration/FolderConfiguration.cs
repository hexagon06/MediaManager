using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity.Configuration
{
    class FolderConfiguration : EntityTypeConfiguration<Folder>
    {
        public FolderConfiguration()
        {
            this.HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name);
            this.Property(t => t.Path);

            this.Ignore(t => t.FileCount);
        }
    }
}
