using System;

namespace MediaManager.Entity
{
    using Interfaces;

    public class ProductionData : IProductionData
    {
        public IProducer Producer { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
