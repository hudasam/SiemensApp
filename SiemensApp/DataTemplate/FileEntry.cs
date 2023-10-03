
namespace SiemensApp.DataTemplate
{
    public class FileEntry : IEntry
    {
        public String Name { get; set; }
        public String Extension { get; set; }

        public FileEntry(String name, String extension)
        { 
            Name = name;
            Extension = extension;
        }
    }
}
