using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Scanner
{
    public class FileComparer : IEqualityComparer<IFile>
    {
        public bool Equals(IFile x, IFile y)
        {
            return x.Extension == y.Extension &&
                x.FileLocation == y.FileLocation &&
                x.FileName == y.FileName &&
                x.FileSize == y.FileSize;
        }

        public int GetHashCode(IFile obj)
        {
            return obj.GetHashCode();
        }
    }
}
