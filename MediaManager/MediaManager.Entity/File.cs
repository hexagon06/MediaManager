using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity
{
    public class File : IFile
    {
        public int Id { get; set; }
        public int RootId { get; set; }
        public Folder Root { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long FileSize { get; set; }
    }
}
