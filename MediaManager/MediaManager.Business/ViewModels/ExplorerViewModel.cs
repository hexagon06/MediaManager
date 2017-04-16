using System;
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

        private IRepository<Folder> FolderRepository { get; set; }
        private IRepository<File> FileRepository { get; set; }
        private IFolderScanner Scanner { get; set; }
        private IUserInput Input { get; set; }

        public ExplorerViewModel(IRepository<Folder> folderRepository, IRepository<File> fileRepository, IFolderScanner scanner, IUserInput input)
        {
            FolderRepository = folderRepository;
            FileRepository = fileRepository;
            Scanner = scanner;
            Input = input;
            Folders = new ObservableCollection<IFolder>(FolderRepository.Entities.ToList());
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
                    var existing = FolderRepository.Entities.SingleOrDefault(f => f.Path == path);
                    if (existing == null)
                    {
                        var folder = new Folder()
                        {
                            Path = path,
                            Name = Path.GetDirectoryName(path)
                        };
                        
                        folder = FolderRepository.Add(folder);
                        FolderRepository.Save();

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
        }
    }
}
