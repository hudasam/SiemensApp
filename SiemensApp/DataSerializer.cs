using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using SiemensApp.DataTemplate;
using System.Text.Json.Serialization;

namespace SiemensApp
{
    /// <summary>
    /// Handles object serialization, deserialization, file reading and writing
    /// </summary>
    public static class DataSerializer
    {

        private static JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Gets or sets the options for <code>JsonSerializer</code>
        /// </summary>
        public static JsonSerializerOptions Options { 
            get
            {
                return options;
            }
            set
            { 
                options = value;
            }
        }
        /// <summary>
        /// Gets or sets the output directory for JSON file
        /// </summary>
        public static string? OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the input JSON file path
        /// </summary>
        public static string? FilePath { get; set; }

        /// <summary>
        /// Serialize the <see cref="Entry"/> object into JSON file at the <see cref="OutputPath">specified directory path</see>
        /// </summary>
        /// <param name="_folderEntry"></param>
        public static void Serialize(Entry _folderEntry)
        {
            string serializedString = JsonSerializer.Serialize<Entry>(_folderEntry,options);
            WriteJSON(serializedString);
        }

        /// <summary>
        /// Read and deserialize a JSON file at the <see cref="FilePath">specified path</see> and return an object of the type <see cref="Entry"/>
        /// </summary>
        /// <returns></returns>
        public static Entry? Deserialize()
        {
            string serializedString = ReadJSON();
            Entry entryObject = new Entry();
            try
            {
                entryObject = JsonSerializer.Deserialize<Entry>(serializedString);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured during JSON file deserialization");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(e.Message);
            }
            return entryObject;
            
        }
        private static void WriteJSON(string serialized)
        {
            string finalPath = OutputPath + "/DirStructure.json";
            try
            {
                File.WriteAllText(finalPath, serialized);
            }
            catch (Exception e) 
            {
                Console.WriteLine("An error occured during JSON file creation");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(e.Message);
            }
        }
        private static string ReadJSON()
        {
            string json = "";
            try
            {
                using StreamReader reader = new(FilePath);
                json = reader.ReadToEnd();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while reading the file: " + FilePath);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(e.Message);
            }
            return json;
        }
    }
}
