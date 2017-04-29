using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business.Scanner
{
    class FolderScanner : IFolderScanner
    {
        private IScanResultFactory ResultFactory { get; set; }
        private ISettingsViewModel Settings { get; set; }

        public FolderScanner(IScanResultFactory factory, ISettingsViewModel settings)
        {
            ResultFactory = factory;
            Settings = settings;
        }

        public IEnumerable<IScanResult> Scan(IFolder folder)
        {
            return Scan(folder.Path);
        }

        private IEnumerable<IScanResult> Scan(string path)
        {
            bool isDirectory = IsDirectory(path);
            List<IScanResult> results = new List<IScanResult>();
            if (isDirectory)
            {
                if (Directory.Exists(path))
                {
                    return ScanDirectory(path);
                }
                else
                {
                    throw new InvalidOperationException("Path does not exist");
                }
            }
            else
            {
                throw new InvalidOperationException("Path is not a directory");
            }
        }

        private IEnumerable<IScanResult> ScanDirectory(string path)
        {
            ResultFactory.Refresh();
            var results = new List<IScanResult>();
            IEnumerable<string> acceptedExtensions = Settings.AcceptedVideoFormats.Split(',');
            var files = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var result = ResultFactory.File(file);
                if(acceptedExtensions.Contains(result.Extension))
                {
                    results.Add(result);
                }
            }
            return results;
        }
        
        private static bool IsDirectory(string path)
        {
            var attributes = File.GetAttributes(path);
            bool isDirectory = (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
            return isDirectory;
        }
    }
}
