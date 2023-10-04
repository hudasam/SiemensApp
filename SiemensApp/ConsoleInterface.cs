using SiemensApp.DataTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensApp
{
    /// <summary>
    /// Handles user input and console output
    /// </summary>
    public static class ConsoleInterface
    {
        /// <summary>
        /// Prints out the structure of the object <see cref="Entry">Entry</see> in a tree like fashion to console
        /// </summary>
        /// <param name="folderObject"></param>
        /// <param name="indent"></param>
        public static void WriteDirStructure(Entry folderObject, int indent = 1) 
        {
            for (int i = 1; i < indent; i++) Console.Write("    ");
            Console.WriteLine(folderObject.Name);
            foreach (Entry f in folderObject.Entries.Where<Entry>(p=> p.IsDirectory == false))
            {
                for (int i = 0; i < indent; i++) Console.Write("    ");
                Console.WriteLine(f.Name+f.Extension);
            }
            foreach (Entry f in folderObject.Entries.Where<Entry>(p => p.IsDirectory == true))
            {
                WriteDirStructure(f, indent + 1);
            }
        }
        public static void Init()
        { 
             
        }
        private static void HandleInput()
        { 
            
        }
    }
}
