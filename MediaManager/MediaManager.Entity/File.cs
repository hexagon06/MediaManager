using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Entity
{
    public class File : IFile
    {
        public int FileId { get; set; }
        public int RootId { get; set; }
        public Folder Root { get; set; }
        //public int MediaFileId { get; set; }
        public MediaFile MediaFile { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long FileSize { get; set; }
    }
}
