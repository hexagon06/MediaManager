using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Interfaces
{
    public interface IProducer
    {
        string Name { get; set; }
        string Url { get; set; }
    }
}
