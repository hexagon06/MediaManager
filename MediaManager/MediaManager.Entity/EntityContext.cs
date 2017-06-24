using System.Data.Entity;

namespace MediaManager.Entity
{
    using EntityConfiguration;

    public class EntityContext : DbContext
    {
        public virtual IDbSet<Folder> Folder { get; set; }
        public virtual IDbSet<File> Files { get; set; }
        public virtual IDbSet<Setting> Settings { get; set; }
        public virtual IDbSet<MediaFile> MediaFiles { get; set; }

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
            modelBuilder.Configurations.Add(new SettingConfiguration());
            modelBuilder.Configurations.Add(new MediaFileConfiguration());
        }
    }
}
