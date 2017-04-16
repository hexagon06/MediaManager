using MediaManager.Entity.Configuration;
using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity
{
    public class EntityContext : DbContext
    {
        public virtual IDbSet<Folder> Folder { get; set; }
        public virtual IDbSet<File> Files { get; set; }

        public EntityContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            if (Database.Exists() && Database.CompatibleWithModel(false) == false)
            {
                Database.Delete();
            }

            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FolderConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());
        }
    }
}
