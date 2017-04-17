﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaManager.Interfaces;
using GalaSoft.MvvmLight.Command;
using JLS.Data.Generic;
using MediaManager.Entity;
using System.IO;
using File = MediaManager.Entity.File;
using System.Windows.Forms;

namespace MediaManager.Business.ViewModels
{
    class ExplorerViewModel : IExplorerViewModel
    {
        public ICommand RescanAllCommand { get { return new RelayCommand(ExecuteRescan); } }

        public ICommand AddFolderCommand { get { return new RelayCommand(ExecuteAddFolder); } }

        public ObservableCollection<IFolder> Folders { get; private set; }

        private IFolderController FolderController { get; set; }
        private IFileController FileController { get; set; }
        private IFolderScanner Scanner { get; set; }
        private IUserInput Input { get; set; }

        public ExplorerViewModel(IFolderController folderController, IFileController fileController, IFolderScanner scanner, IUserInput input)
        {
            FolderController = folderController;
            FileController = fileController;
            Scanner = scanner;
            Input = input;
            Folders = new ObservableCollection<IFolder>(FolderController.GetList());
        }

        private void ExecuteRescan()
        {
            foreach (IFolder folder in Folders)
            {
                ScanFolder(folder);
            }
        }

        private void ExecuteAddFolder()
        {
            IStringRequest request = new StringRequest();

            if (Input.AskFolder(request))
            {
                string path = request.Input;
                
                if(IsDirectory(path) &&
                    Directory.Exists(path))
                {
                    var existing = FolderController.GetList().SingleOrDefault(f => f.Path == path);
                    if (existing == null)
                    {
                        IFolder folder = new Folder()
                        {
                            Path = path,
                            Name = Path.GetDirectoryName(path)
                        };
                        
                        folder = FolderController.Add(folder);

                        Folders.Add(folder);

                        ScanFolder(folder);
                    }
                    else
                    {
                        var retry = MessageBox.Show(
                            "Folder already added to library. Would you like to add another?",
                            "Folder in library", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if(retry == DialogResult.Yes)
                        {
                            ExecuteAddFolder();
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("Not a valid directory");
                }
            }
        }

        private static bool IsDirectory(string path)
        {
            var attributes = System.IO.File.GetAttributes(path);
            bool isDirectory = (System.IO.File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
            return isDirectory;
        }

        private void ScanFolder(IFolder folder)
        {
            var result = Scanner.Scan(folder);

            var confirmed = Input.ProcessResult(result);

            IEnumerable<IFile> files = confirmed
                .Where(r => r.Result == ScanResult.New)
                .Select(sr => new File()
                {
                    FileName = Path.GetFileNameWithoutExtension(sr.Path),
                    Extension = Path.GetExtension(sr.Path),
                    FileLocation = sr.Path,
                    Root = folder.AsFolder(),
                    RootId = folder.Id,
                    FileSize = new FileInfo(sr.Path).Length
                });

            FileController.Add(files, folder.Id);
        }
    }
}