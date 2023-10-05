using SiemensApp;
using SiemensApp.DataTemplate;

namespace SiemensAppTest
{
    [TestClass]
    public class FolderExplorerTest
    {
        
        [TestMethod]
        public void InvalidPathTest()
        {
            //Arrange
            string path = " .  [[";

            //Assert
            Assert.ThrowsException<DirectoryNotFoundException>(() => { FolderExplorer.DirSearch(path); }) ;
        }
    }
}