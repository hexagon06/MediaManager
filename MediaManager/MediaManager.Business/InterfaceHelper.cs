using MediaManager.Entity;
using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    internal static class InterfaceHelper
    {
        public static Folder AsFolder(this IFolder folder)
        {
            return new Folder()
            {
                Id = folder.Id,
                Name = folder.Name,
                Path = folder.Path,
            };
        }

        public static File AsFile(this IFile file)
        {
            return new File()
            {
                Extension = file.Extension,
                FileLocation = file.FileLocation,
                FileName = file.FileName,
                FileSize = file.FileSize,
                FileId = file.FileId
            };
        }

        public static MediaFile AsMediaFile(this IMediaFile mediafile)
        {
            return new MediaFile()
            {
                MediaFileId = mediafile.MediaFileId,
                DateAdded = mediafile.DateAdded,
                Label = mediafile.Label,
                MediaType = mediafile.MediaType,
                MetaData = mediafile.MetaData,
                ProductionData = mediafile.ProductionData,
            };
        }
    }
}
