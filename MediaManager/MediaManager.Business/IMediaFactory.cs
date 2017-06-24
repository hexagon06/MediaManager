using MediaManager.Interfaces;

namespace MediaManager.Business
{
    public interface IMediaFactory
    {
        IMediaFile GetMediaFile(IFile file);
    }
}