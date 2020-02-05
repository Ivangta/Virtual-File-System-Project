using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Virtual_File_System_Project
{
    public class Folder : Container
    {
        public Folder()
        {
            files = new List<File>();
            folders = new List<Folder>();
        }
        public Folder(Folder parent, string name, string path) : this()
        {
            Parent = parent;
            Name = name;
            CreatedOn = DateTime.Now;
            LastModifiedOn = DateTime.Now;
            Path = path;
        }

        public override double GetSize()
        {
            double fileSize = 0.00;

            foreach(var file in files)
            {
                fileSize += file.GetSize();
            }
            foreach (var folder in folders)
            {
                fileSize += folder.GetSize();
            }
            return fileSize;
        }
        public int GetItemsCount()
        {
            return files.Count + folders.Count;
        }

        public Container[] ListSubItems()
        {
            Container[] container = new Container[files.Count + folders.Count];
            for (int i = 0; i < files.Count; i++)
            {
                container[i] = files[i];
            }
            for (int j = 0; j < folders.Count; j++)
            {
                container[j + files.Count] = folders[j];
            }

            return container;
        }

        public void Add(File file)
        {
            if (files.Any(f => f.Name == file.Name))
            {
                Console.WriteLine("#Error File already exists");
                return;
            }

            files.Add(file);
        }

       
        public void Add(Folder folder)
        {
            if (folders.Any(f => f.Name == folder.Name))
            {
                Console.WriteLine("#Error Folder already exists");
                return;
            }

            folders.Add(folder);
        }


        public void Remove(File file)
        {
            var targetFile = files.FirstOrDefault(f => f.Name == file.Name);
            if (targetFile == null)
            {
                Console.WriteLine("#Error File does not exist");
                return;
            }
            files.Remove(targetFile);
        }
        public void Remove(Folder folder)
        {
            var targetFolder = folders.FirstOrDefault(f => f.Name == folder.Name);
            if (targetFolder == null)
            {
                Console.WriteLine("#Error Folder does not exist");
                return;
            }
            folders.Remove(targetFolder);
        }

        public File GetFileByName(string fileName)
        {
            return files.FirstOrDefault(f => f.Name == fileName);
        }

        public Folder GetFolderByName(string folderName)
        {
            return folders.FirstOrDefault(f => f.Name == folderName);
        }

        public Folder Parent { get; private set; }
        private List<File> files { get; set; }
        private List<Folder> folders { get; set; }
    }
}
