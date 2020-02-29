using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_File_System_Project
{
    public class NavigationService
    {
        private Folder root;
        private bool shouldExit;
        Folder CurrentFolder;

        public NavigationService()
        {
            root = new Folder(null, "root", "root");
            CurrentFolder = root;
        }


        public void StartProgram()
        {
            while (!shouldExit)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(CurrentFolder.Path);
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
                    CurrentFolder.Add(new File(CurrentFolder, commandDetails[1], (CurrentFolder.Path + "/" + commandDetails[1])));
                    break;
                case "addFolder":
                    CurrentFolder.Add(new Folder(CurrentFolder, commandDetails[1], (CurrentFolder.Path + "/" + commandDetails[1])));
                    break;
                case "deleteFile":
                    CurrentFolder.Remove(CurrentFolder.GetFileByName(commandDetails[1]));
                    break;
                case "deleteFolder":
                    CurrentFolder.Remove(CurrentFolder.GetFolderByName(commandDetails[1]));
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
                    var targetFolder = CurrentFolder.GetFolderByName(commandDetails[1]);
                    if (targetFolder != null)
                    {
                        CurrentFolder = targetFolder;
                    }
                    else
                    {
                        Console.WriteLine("#Error folder does not exist");
                    }
                    break;
                case "closeFolder":
                    var targetFolder2 = CurrentFolder.Parent;
                    if (targetFolder2 != null)
                    {
                        CurrentFolder = targetFolder2;
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
            var allItems = CurrentFolder.ListSubItems();
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
