﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;

namespace MediaManager.Business
{
    public interface IFileController
    {
        IEnumerable<IFile> Add(IEnumerable<IFile> files, int folderId);
    }
}
