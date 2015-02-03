using System;
namespace MediaManager.Models
{
    public interface IMediaFile
    {
        DateTime DateAdded { get; set; }
        IFile FileInfo { get; set; }
        string MediaType { get; set; }
        IMediaMetaData MetaData { get; set; }
        IProductionData ProductionData { get; set; }
    }
}
