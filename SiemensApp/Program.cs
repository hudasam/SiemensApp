// See https://aka.ms/new-console-template for more information
using SiemensApp;
using SiemensApp.DataTemplate;
using System.Text.Json;

Entry f = FolderExplorer.DirSearch("C:\\Users\\hudak\\Desktop\\TestFolder");
ConsoleInterface.WriteDirStructure(f);

DataSerializer.OutputPath = "C:\\Users\\hudak\\Desktop";
DataSerializer.Serialize(f);
DataSerializer.FilePath = "C:\\Users\\hudak\\Desktop\\DirStruct.json";






