using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business.ViewModels
{
    public interface ISelectableMediaFile : IMediaFile
    {
        bool IsSelected { get; set; }
    }
}
