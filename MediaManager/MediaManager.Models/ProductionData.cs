using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Models
{
    internal class ProductionData : IProductionData
    {
        public IProducer Producer { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
