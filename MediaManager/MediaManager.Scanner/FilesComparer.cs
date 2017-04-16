using MediaManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Scanner
{
    public class FilesComparer
    {
        private IEnumerable<IFile> _currentState;
        public IEqualityComparer<IFile> comparer = new FileComparer();

        public FilesComparer(IEnumerable<IFile> currentState)
        {
            _currentState = currentState;
        }

        public IEnumerable<ScanCompareResult> Compare(IEnumerable<IFile> targetSource)
        {
            List<ScanCompareResult> results = new List<ScanCompareResult>();
            foreach (IFile target in targetSource)
            {
                ScanCompareResult result = GetTargetScanResult(target);

                if (result != null)
                {
                    results.Add(result);
                }
            }

            var existing = results.Where(sr => sr.OldScan != null).Select(sr => sr.OldScan).ToList();
            foreach (IFile current in _currentState)
            {
                if (!existing.Contains(current, comparer))
                {
                    var result = new ScanCompareResult()
                    {
                        Result = CompareResult.Removed,
                        OldScan = current
                    };
                    results.Add(result);
                }
            }

            return results;
        }

        private ScanCompareResult GetTargetScanResult(IFile target)
        {
            ScanCompareResult result = null;

            //- first most strict same
            var locationMatch = _currentState.SingleOrDefault(f => f.FileLocation == target.FileLocation);

            if (locationMatch != null)
            {
                result = new ScanCompareResult()
                {
                    Result = CompareResult.NoChange,
                    NewScan = target,
                    OldScan = locationMatch
                };
            }
            else
            {
                var fileMatch = _currentState.SingleOrDefault(f => f.FileName == target.FileName && f.Extension == target.Extension);
                if (fileMatch != null)
                {
                    result = new ScanCompareResult()
                    {
                        Result = CompareResult.Moved,
                        NewScan = target,
                        OldScan = fileMatch
                    };
                }
                else
                {
                    result = new ScanCompareResult()
                    {
                        Result = CompareResult.New,
                        NewScan = target
                    };
                }
            }
            return result;
        }

    }
}
