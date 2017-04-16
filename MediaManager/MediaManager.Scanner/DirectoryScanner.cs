using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Scanner
{
    public class DirectoryScanner
    {
        private List<string> _directories;
        public IEnumerable<string> Directories
        {
            get
            {
                return _directories;
            }
        }

        private List<string> _files;
        public IEnumerable<string> Files
        {
            get
            {
                return _files;
            }
        }

        public DirectoryScanner(string path)
        {
            bool isDirectory = IsDirectory(path);
            if (isDirectory)
            {
                if (Directory.Exists(path))
                {
                    ScanDirectory(path);
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

        private void ScanDirectory(string path)
        {
            _directories.Add(path);
            var dirs = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            _files.AddRange(files);
            foreach (string dir in dirs)
            {
                ScanDirectory(dir);
            }
        }

        private static bool IsDirectory(string path)
        {
            var attributes = File.GetAttributes(path);
            bool isDirectory = (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
            return isDirectory;
        }

    }
}
