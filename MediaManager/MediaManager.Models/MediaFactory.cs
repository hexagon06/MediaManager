using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Models
{
    public class MediaFactory
    {
        private MediaTypes Types { get; set; }
        public MediaFactory(MediaTypes types)
        {
            if(types == null)
            {
                throw new ArgumentNullException("types");
            }
            Types = types;
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
                DateAdded = DateTime.Now,
                FileInfo = file,
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
                    result = new VideoMetaData();
                    break;
                case "Audio":
                    result = new AudioMetaData();
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
