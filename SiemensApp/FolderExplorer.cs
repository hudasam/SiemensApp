using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiemensApp.DataTemplate;

namespace SiemensApp
{
    internal class FolderExplorer
    {

        /// <summary>
        /// Method <c>DirSearch</c> looks through the target <paramref name="directory"/> and subdirectiories and returns an <see cref="Entry"/> object describing its structure.
        /// </summary>
        /// <param name="directory"> specifies the target directory</param>
        public static Entry DirSearch(string directory)
        {
            var dirName = Path.GetFileName(directory);
            Entry output = new Entry()
            {
                IsDirectory = true,
                Name = dirName,
                Entries = new List<Entry>()
            };
            foreach (string fp in Directory.GetFiles(directory))
            {
                string file = fp.Split(Path.DirectorySeparatorChar).Last();
                string fileExtension = Path.GetExtension(file);
                string fileName = Path.GetFileNameWithoutExtension(file);

                output.Entries.Add(new Entry()
                {
                    Name = fileName,
                    Extension = fileExtension,
                    IsDirectory = false
                });
                
            }
            foreach (string dp in Directory.GetDirectories(directory))
            {
                string dir = dp.Split(Path.DirectorySeparatorChar).Last();

                output.Entries.Add(new Entry()
                {
                    Name = dir,
                    IsDirectory = true,
                    Entries = DirSearch(dp).Entries
                });
            }
            return output;
        }


    }
}
