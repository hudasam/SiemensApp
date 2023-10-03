

namespace SiemensApp.DataTemplate
{
    public class FolderEntry: IEntry
    {
        public String Name { get; set; }
        public List<IEntry> Entries { get; set; }

        public FolderEntry(String name, List<IEntry>? entries)
        { 
            this.Name = name;
            this.Entries = entries;
        }
    }
}
