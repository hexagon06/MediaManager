using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Interfaces
{
    public interface IFile
    {
        int Id { get; set; }
        string FileLocation { get; set; }
        string FileName { get; }
        string Extension { get; }
        int FileSize { get; set; }
    }
}
