using MediaManager.Entity;
using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    public class MediaFactory : IMediaFactory
    {
        private MediaTypes Types { get; set; }
        public MediaFactory(MediaTypes mediaTypes)
        {
            if(mediaTypes == null)
            {
                throw new ArgumentNullException("types");
            }
            Types = mediaTypes;
        }

        public IMediaFile GetMediaFile(IFile file)
        {
            if(file == null)
            {
                throw new ArgumentNullException("file");
            }
            string mediaType = GetMediaType(file);
            IMediaMetaData metaData = GetMetaData(mediaType);
            IProductionData productionData = GetProductionData();
            var media = new MediaFile()
            {
                MediaFileId = file.FileId,
                DateAdded = DateTime.Now,
                Label = file.FileName,
                File =file.AsFile(),
                MediaType = mediaType,
                MetaData = metaData,
                ProductionData = productionData
            };

            return media;
        }

        private IProductionData GetProductionData()
        {
            var data = new ProductionData();
            return data;
        }

        private IMediaMetaData GetMetaData(string mediaType)
        {
            IMediaMetaData result = default(IMediaMetaData);
            switch(mediaType)
            {
                case "Video":
                    result = new VideoMetaData() as IMediaMetaData;
                    break;
                case "Audio":
                    result = new AudioMetaData() as IMediaMetaData;
                    break;
            }
            return result;
        }

        private string GetMediaType(IFile file)
        {
            return Types.GetFileType(file.Extension);
        }
    }
}
