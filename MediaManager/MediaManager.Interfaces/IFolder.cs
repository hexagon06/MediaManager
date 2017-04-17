using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Interfaces
{
    public interface IFolder
    {
        int Id { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        int FileCount { get; }
    }
}
