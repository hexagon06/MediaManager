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

        public ICommand RescanSingleCommand { get { return new RelayCommand<IFolder>(ExecuteRescanSingle); } }

        public bool HasChanged { get; private set; }

        public ObservableCollection<IFolder> Folders { get; private set; }

        private IFolderController FolderController { get; set; }
        private IFileController FileController { get; set; }
        private IMediaFileController MediaFileController { get; set; }
        private IFolderScanner Scanner { get; set; }
        private IUserInput Input { get; set; }
        private IMediaFactory Factory { get; set; }
        private IMediaBroadcaster Broadcaster { get; set; }

        public ExplorerViewModel(IFolderController folderController, IFileController fileController, IMediaFileController mediaFileController, IMediaFactory factory, IFolderScanner scanner, IUserInput input, IMediaBroadcaster broadcaster)
        {
            FolderController = folderController;
            FileController = fileController;
            Scanner = scanner;
            Input = input;
            MediaFileController = mediaFileController;
            Factory = factory;
            Broadcaster = broadcaster;
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
                            Name = Path.GetFileNameWithoutExtension(path)
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

        private void ExecuteRescanSingle(IFolder folder)
        {
            ScanFolder(folder);
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

            var confirmed = Input.ProcessResult(folder.Name, result);

            if (confirmed.Count() > 0)
            {
                IEnumerable<IFile> files = confirmed
                    .Where(r => r.Result == ScanResult.New)
                    .Select(sr => new File()
                    {
                        FileName = Path.GetFileNameWithoutExtension(sr.Path),
                        Extension = sr.Extension,
                        FileLocation = sr.Path,
                        Root = folder.AsFolder(),
                        RootId = folder.Id,
                        FileSize = new FileInfo(sr.Path).Length
                        //- to list must be done, otherwise the following population will be lost
                    }).ToList();

                //- populate required entity tree
                foreach (var file in files)
                {
                    IMediaFile media = Factory.GetMediaFile(file);
                    file.Media = media;
                    IMediaMetaData meta = Factory.GetMediaMetaData(media);
                    media.MetaData = meta;
                }

                var processed = FileController.Add(files, folder.Id);

                Broadcaster.SendNewMediaMessage(processed.Select(f => f.Media));

                HasChanged = true;
            }
        }
    }
}
