using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    public interface IMediaFileController
    {
        void Add(IEnumerable<IMediaFile> media);
        void AddFor(IEnumerable<IFile> files);
    }
}
