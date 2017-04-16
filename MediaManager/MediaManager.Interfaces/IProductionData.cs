using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager.Interfaces
{
    public interface IProductionData
    {
        IProducer Producer { get; set; }
        DateTime? ReleaseDate { get; set; }
    }
}
