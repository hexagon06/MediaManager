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

        public void Add(IEnumerable<IFile> files, int folderId)
        {
            var folder = FolderRepository.Entities.Single(f => f.Id == folderId);

            foreach (var file in files)
            {
                folder.Files.Add(file.AsFile());
            }

            FolderRepository.Save();
        }
    }
}
