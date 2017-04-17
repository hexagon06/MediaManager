using MediaManager.Interfaces;

namespace MediaManager.Business
{
    public interface IScanResult
    {
        ScanResult Result { get; }
        string Path { get; }
        string Name { get; set; }
    }
}