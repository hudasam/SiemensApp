using SiemensApp.DataTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SiemensApp
{
    /// <summary>
    /// Handles user input and console output
    /// </summary>
    public static class ConsoleInterface
    {
        private static bool _running = false;
        /// <summary>
        /// Prints out the structure of the object <see cref="Entry">Entry</see> in a tree like fashion to console
        /// </summary>
        /// <param name="folderObject"></param>
        /// <param name="indent"></param>
        private static void WriteDirStructure(Entry folderObject, int indent = 1) 
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
        /// <summary>
        /// Initializes the <see cref="ConsoleInterface"/>
        /// </summary>
        public static void Init()
        { 
            _running = true;
            Help();
            HandleInput();
        }
        private static void HandleInput()
        {
            while (_running)
            {
                Console.WriteLine("Please enter a command");
                string? input = Console.ReadLine();
                ParseInputCommand(input);
            }
            

        }
        private static void ParseInputCommand(string? input)
        {
            if (input == null) return;
 
            switch (input.ToLower()) 
            {
                case "serialize":
                case "s":
                case "serialise":
                    Serialize();
                    break;
                case "deserialize":
                case "d":
                case "deserialise":
                    Deserialize();
                    break;
                case "distinct extensions":
                case "extension":
                    DistExtension();
                    break;
                case "help":
                case "h":
                    Help();
                    break;
                case "exit":
                case "e":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try one of these");
                    Help();
                    break;
            }
        }
        private static void Serialize()
        {
            Console.WriteLine("Please specify the target directory. The output JSON file will also be created in this directory.\n Target:");
            string? input = Console.ReadLine();
            try
            {
                Entry? entry = FolderExplorer.DirSearch(input);
                WriteDirStructure(entry);
                DataSerializer.OutputPath = input;
                DataSerializer.Serialize(entry);
            }
            catch(Exception e) 
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(e.Message);
                return;
            }
            
            
        }
        private static void Deserialize() 
        {
            Console.WriteLine("Please specify the target JSON file.\n Target:");
            string? input = Console.ReadLine();
            DataSerializer.FilePath = input;
            Entry? entry = DataSerializer.Deserialize();
            WriteDirStructure(entry);
        }
        private static void Help() 
        {
            Console.WriteLine("\nHere are the known commands:");
            Console.WriteLine(" serialize   - serialize the contents of a directory into a json file");
            Console.WriteLine(" deserialize - deserialize a json file and print out a directory structure");
            Console.WriteLine(" extension   - print out all distinct extensions of files in a directory");
            Console.WriteLine(" help        - print out all known commands");
            Console.WriteLine(" exit        - exit out of the application\n");
        }
        private static void DistExtension()
        {
            Console.WriteLine("Please specify the target directory.\n Target:");
            string? input = Console.ReadLine();
            try
            {
                Entry? entry = FolderExplorer.DirSearch(input);
                WriteDirStructure(entry);
                Console.WriteLine("\n Distinct file extensions are:");
                HashSet<string> dist = entry.GetDistinctExtensions();
                Console.WriteLine(string.Join(" ", dist));
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(e.Message);
                return;
            }
        }
        private static void Exit() 
        {
            _running = false;
        }
    }
}
