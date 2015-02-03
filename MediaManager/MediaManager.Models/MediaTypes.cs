using MediaManager.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Models
{
    public class MediaTypes
    {
        public Dictionary<string, IEnumerable<string>> TypeExtensions { get; private set; }

        public MediaTypes(Configuration.MediaTypeSection section)
        {
            TypeExtensions = new Dictionary<string, IEnumerable<string>>();
            foreach (MediaTypeElement type in section.Types)
            {
                var name = type.Name;
                var extensions = type.Extensions.Cast<string>();
                TypeExtensions.Add(name, extensions);
            }
        }

        internal string GetFileType(string extension)
        {
            return TypeExtensions
                .Where(kvp => kvp.Value.Contains(extension))
                .Select(kvp => kvp.Key)
                .Single();
        }
    }
}
