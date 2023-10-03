// See https://aka.ms/new-console-template for more information
using SiemensApp;
using SiemensApp.DataTemplate;

FolderEntry f = FolderExplorer.DirSearch("D:\\Photoshop\\Adobe Photoshop 2023 v24.5.0.500 (x64) Multilingual\\Autoplay");
ConsoleInterface.WriteDirStructure(f);



