using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Virtual_File_System_Project
{
    public class File : Container
    {
        public File(Folder parent, string name, string path)
        {
            Parent = parent;
            Name = name;
            CreatedOn = DateTime.Now;
            LastModifiedOn = DateTime.Now;
            Path = path;
        }

        public override double GetSize()
        {
            return fileSize;
        }

        public string FileType { get; set; }
        private double fileSize = 1;
        public byte[] FileData { get; set; }
        public Folder Parent { get; private set; }
    }
}
