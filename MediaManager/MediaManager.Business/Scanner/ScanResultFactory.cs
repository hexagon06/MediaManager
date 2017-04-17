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
        public ScanResultFactory(IRepository<File> fileRepository)
        {
            FileRepository = fileRepository;
        }

        public IScanResult File(string file)
        {
            var result = new ScanResult()
            {
                Path = file,
                Name = System.IO.Path.GetFileName(file)
            };

            var existing = FileRepository.Entities
                .SingleOrDefault(f => f.FileLocation == file);

            if (existing == null)
            {
                result.Result = Business.ScanResult.New;
            }

            return result;
        }
    }
}
