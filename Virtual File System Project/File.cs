using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Virtual_File_System_Project
{
    public class File : Container
    {
        public File(File parent, string name, string path)
        {
            Parent = parent;
            Name = name;
            CreatedOn = DateTime.Now;
            LastModifiedOn = DateTime.Now;
            Path = path;
            files = new List<File>();
            folders = new List<Folder>();
        }

        public override double GetSize()
        {
            return fileSize;
        }

        public void Add(File file)
        {
            if (files.Any(f => f.Name == file.Name))
            {
                Console.WriteLine("#Error Folder already exists");
                return;
            }

            files.Add(file);
        }


        public string FileType { get; set; }
        private double fileSize = 1;
        public byte[] FileData { get; set; }
        public File Parent { get; private set; }

        private List<File> files { get; set; }
        private List<Folder> folders { get; set; }
    }
}
