using JLS.Data.Generic;
using MediaManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business.Scanner
{
    class ScanResultFactory : IScanResultFactory
    {
        private IRepository<File> FileRepository { get; set; }
        private IEnumerable<File> Files { get; set; }
        public ScanResultFactory(IRepository<File> fileRepository)
        {
            FileRepository = fileRepository;
            Refresh();
        }

        public void Refresh()
        {
            Files = FileRepository.Entities.ToList();
        }

        public IScanResult File(string file)
        {
            var result = new ScanResult()
            {
                Path = file,
                Name = System.IO.Path.GetFileName(file),
                Extension = System.IO.Path.GetExtension(file)
            };

            var existing = Files
                .SingleOrDefault(f => f.FileLocation == file);

            if (existing == null)
            {
                result.Result = Business.ScanResult.New;
            }

            return result;
        }
    }
}
