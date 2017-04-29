using JLS.Data.Generic;
using MediaManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;
using System.Data.Entity;

namespace MediaManager.Business.Controllers
{
    class FolderController : IFolderController
    {
        IRepository<Folder> FolderRepository { get; set; }

        public FolderController(IRepository<Folder> folderRepository)
        {
            FolderRepository = folderRepository;
        }

        public IEnumerable<IFolder> GetList()
        {
            return FolderRepository.Entities
                .Include(f => f.Files)
                .ToList();
        }

        public IFolder Add(IFolder folder)
        {
            Folder concrete = folder.AsFolder();
            FolderRepository.Add(concrete);
            FolderRepository.Save();
            return concrete;
        }
    }
}
