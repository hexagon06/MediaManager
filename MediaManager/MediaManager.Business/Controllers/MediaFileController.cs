using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;
using JLS.Data.Generic;

namespace MediaManager.Business.Controllers
{
    using Entity;
    using System.Data.Entity;

    class MediaFileController : IMediaFileController
    {
        private IMediaFactory MediaFactory { get; set; }
        private IRepository<MediaFile> MediaRepository { get; set; }

        public MediaFileController(IRepository<MediaFile> repository, IMediaFactory factory)
        {
            MediaRepository = repository;
            MediaFactory = factory;
        }

        public void AddFor(IEnumerable<IFile> files)
        {
            IEnumerable<IMediaFile> media = files.Select(f => MediaFactory.GetMediaFile(f));
            Add(media);
        }

        public void Add(IEnumerable<IMediaFile> media)
        {
            foreach (var mediaFile in media)
            {
                MediaRepository.Add(mediaFile.AsMediaFile());
            }
            MediaRepository.Save();
        }

        public IEnumerable<IMediaFile> GetList()
        {
            return MediaRepository.Entities
                .ToList();
        }

        public IMediaFile Single(int id)
        {
            return MediaRepository.Entities
                .Include(m => m.File)
                .Single(m => m.MediaFileId == id);
        }
    }
}
