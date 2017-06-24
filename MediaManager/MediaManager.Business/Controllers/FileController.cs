using JLS.Data.Generic;
using MediaManager.Business;
using MediaManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;

namespace MediaManager.Business.Controllers
{
    class FileController : IFileController
    {
        IRepository<File> FileRepository { get; set; }
        IRepository<Folder> FolderRepository { get; set; }

        public FileController(IRepository<File> fileRepository, IRepository<Folder> folderRepository)
        {
            FileRepository = fileRepository;
            FolderRepository = folderRepository;
        }

        public IEnumerable<IFile> Add(IEnumerable<IFile> files, int folderId)
        {
            var folder = FolderRepository.Entities.Single(f => f.Id == folderId);
            List<File> result = new List<File>();
            foreach (var file in files)
            {
                var concrete = file.AsFile();
                result.Add(concrete);
                folder.Files.Add(concrete);
            }

            FolderRepository.Save();

            return result;
        }
    }
}
