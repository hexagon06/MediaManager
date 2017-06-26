using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;

namespace MediaManager.Business
{
    public interface IUserInput
    {
        bool AskFolder(IStringRequest request);
        IEnumerable<IScanResult> ProcessResult(string folderName, IEnumerable<IScanResult> result);
    }
}
