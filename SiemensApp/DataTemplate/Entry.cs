

using System.Text.Json.Serialization;

namespace SiemensApp.DataTemplate
{
    /// <summary>
    /// Data structure class that describes a node in directory hierarchy
    /// </summary>
    public class Entry
    {

        
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public bool? IsDirectory { get; set; }
        public List<Entry>? Entries {get; set; }

        /// <summary>
        /// Returns a hash set of distinct extensions of files in the directory and related subdirectories
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GetDistinctExtensions()
        { 
            HashSet<string> result = new HashSet<string>();
            foreach(Entry e in Entries.Where(e => e.IsDirectory == true)) 
            {
                result.UnionWith(e.GetDistinctExtensions());
            }
            foreach(Entry e in Entries.Where(e=> e.IsDirectory == false && e.Extension!=null)) 
            {
                result.Add(e.Extension);
            }
            return result;
        }

    }
}
