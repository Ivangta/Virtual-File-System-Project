using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_File_System_Project
{
    public class NavigationService
    {
        private Folder root;
        private bool shouldExit;
        Folder currentFolder;

        private File root2;
        File currentFile;
        public NavigationService()
        {
            root = new Folder(null, "root", "root");
            currentFolder = root;
            root2 = new File(null, "root2", "root2");
            currentFile = root2;
        }


        public void StartProgram()
        {
            while (!shouldExit)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(currentFolder.Path);
                Console.WriteLine("Input a command: (type \"commands\" to list all commands)");
                string command = Console.ReadLine();
                ExecuteCommand(command);
                Console.WriteLine("------------------------------------------------");
            }
        }


        void ExecuteCommand(string command)
        {
            var commandDetails = command.Split(" ");
            switch(commandDetails[0])
            {
                case "exit":
                    shouldExit = true;
                    break;
                case "addFile":
                    currentFile.Add(new File(currentFile, commandDetails[1], (currentFile.Path + "/" + commandDetails[1])));
                    break;
                case "addFolder":
                    currentFolder.Add(new Folder(currentFolder, commandDetails[1], (currentFolder.Path + "/" + commandDetails[1])));
                    break;
                case "deleteFile":
                    currentFolder.Remove(currentFolder.GetFileByName(commandDetails[1]));
                    break;
                case "deleteFolder":
                    currentFolder.Remove(currentFolder.GetFolderByName(commandDetails[1]));
                    break;
                case "list":
                    ListContents();
                    break;
                case "listAll":
                    ListAllContents();
                    break;
                case "commands":
                    ListCommands();
                    break;
                case "openFolder":
                    var targetFolder = currentFolder.GetFolderByName(commandDetails[1]);
                    if (targetFolder != null)
                    {
                        currentFolder = targetFolder;
                    }
                    else
                    {
                        Console.WriteLine("#Error folder does not exist");
                    }
                    break;
                case "closeFolder":
                    var targetFolder2 = currentFolder.Parent;
                    if (targetFolder2 != null)
                    {
                        currentFolder = targetFolder2;
                    }
                    else
                    {
                        Console.WriteLine("#Error You are at the root");
                    }
                    break;
                default:
                    Console.WriteLine("Command does not exist");
                    break;
            }
        }


        private void ListCommands()
        {
            Console.WriteLine("\nexit");
            Console.WriteLine("addFile name");
            Console.WriteLine("addFolder name");
            Console.WriteLine("deleteFile name");
            Console.WriteLine("deleteFolder name");
            Console.WriteLine("openFolder name");
            Console.WriteLine("closeFolder");
            Console.WriteLine("list");
            Console.WriteLine("listAll");
        }

        private void ListContents()
        {
            Console.WriteLine();
            var allItems = currentFolder.ListSubItems();
            foreach (var item in allItems)
            {
                var type = ((item is File) ? "file" : "folder");
                Console.WriteLine(item.Name + "      type: " + type + " size: " + item.GetSize() + " created: " + item.CreatedOn);
            }
        }
        private void ListAllContents()
        {
            Console.WriteLine();
            var allItems = GetAllSubItems(root);
            foreach (var item in allItems)
            {
                var type = ((item is File) ? "file" : "folder");
                Console.WriteLine(item.Path + "      type: " + type + " size: " + item.GetSize() + " created: " + item.CreatedOn);
            }
        }

        private List<Container> GetAllSubItems(Folder folder)
        {
            List<Container> allItems = new List<Container>();
            foreach (var item in folder.ListSubItems())
            {
                allItems.Add(item);
                var folderItem = item as Folder;
                if (folderItem != null)
                {
                    var subitems = GetAllSubItems(folderItem);
                    allItems.AddRange(subitems);
                }
            }
            return allItems;
        }
    }
}
