using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity
{
    public class Folder : IFolder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int FileCount { get { return Files.Count; } }
        public ICollection<File> Files { get; set; }

        public Folder()
        {
            Files = new List<File>();
        }
    }
}
