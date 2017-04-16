using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity.Configuration
{
    class FileConfiguration : EntityTypeConfiguration<File>
    {
        public FileConfiguration()
        {
            this.HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(t => t.FileLocation);
            this.Property(t => t.FileName);
            this.Property(t => t.Extension);
            this.Property(t => t.FileSize);
            this.Property(t => t.RootId);

            this.HasRequired(f => f.Root)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.RootId);
        }
    }
}
