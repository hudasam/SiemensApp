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
        /// Method <c>DirSearch</c> looks through the target <paramref name="directory"> and subdirectiories and returns an object describing its structure.
        /// <param name="directory"> specifies the target directory</param>
        /// </summary>
        public static FolderEntry DirSearch(string directory)
        {
            FolderEntry output = new FolderEntry(directory, new List<IEntry>());
            foreach (string fp in Directory.GetFiles(directory))
            {
                string file = fp.Split(Path.DirectorySeparatorChar).Last();
                string fileExtension = Path.GetExtension(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                output.Entries.Add(new FileEntry(fileName, fileExtension));
                
            }
            Console.WriteLine();
            foreach (string dp in Directory.GetDirectories(directory))
            {
                string dir = dp.Split(Path.DirectorySeparatorChar).Last();
                output.Entries.Add(new FolderEntry(dir, DirSearch(dp).Entries));
            }
            return output;
        }


    }
}
