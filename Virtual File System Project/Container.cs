using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_File_System_Project
{
    public abstract class Container
    {
        public abstract double GetSize();

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime LastModifiedOn { get; set; }
    }
}
