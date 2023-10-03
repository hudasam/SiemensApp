using SiemensApp.DataTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensApp
{
    public static class ConsoleInterface
    {
        public static void WriteDirStructure(FolderEntry folderObject, int indent = 1) 
        {

            foreach (FileEntry f in folderObject.Entries.OfType<FileEntry>())
            {
                for (int i = 0; i < indent; i++) Console.Write("    ");
                Console.WriteLine(f.Name+f.Extension);
            }
            foreach (FolderEntry f in folderObject.Entries.OfType<FolderEntry>())
            {
                for (int i = 0; i < indent; i++) Console.Write("    ");
                Console.WriteLine(f.Name);
                WriteDirStructure(f, indent + 1);
            }
        }
    }
}
