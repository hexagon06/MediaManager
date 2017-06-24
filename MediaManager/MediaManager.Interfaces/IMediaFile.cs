using System;
namespace MediaManager.Interfaces
{
    public interface IMediaFile
    {
        int MediaFileId { get; set; }
        DateTime DateAdded { get; set; }
        string MediaType { get; set; }
        string Label { get; set; }
        IMediaMetaData MetaData { get; set; }
        IProductionData ProductionData { get; set; }
    }
}
