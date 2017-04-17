﻿using JLS.Data.Generic;
using MediaManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;

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
            return FolderRepository.Entities.ToList();
        }

        public IFolder Add(IFolder folder)
        {
            FolderRepository.Add(folder.AsFolder());
            FolderRepository.Save();
            return folder;
        }
    }
}
