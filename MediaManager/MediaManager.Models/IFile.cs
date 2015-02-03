using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Models
{
    public interface IFile
    {
        string FileLocation { get; set; }
        string FileName { get; }
        string Extension { get; }
        int FileSize { get; set; }
    }
}
