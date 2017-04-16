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

        public FolderScanner(IScanResultFactory factory)
        {
            ResultFactory = factory;
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
            var results = new List<IScanResult>();
            var directories = Directory.GetDirectories(path);
            foreach (string dir in directories)
            {
                results.AddRange(ScanDirectory(dir));
            }
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                results.Add(ResultFactory.File(file));
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
