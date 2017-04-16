using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Interfaces
{
    public interface ILabel
    {
        int Id { get; set; }
        string Label { get; set; }
    }
}
