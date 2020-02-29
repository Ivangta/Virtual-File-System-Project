1. Root
1. public void GetItemsCount()
2. public Container[] ListSubItems()
3. public void Add(File file)
4. public void AddFile(string fileName, byte[] fileData)
5. public void Add(Folder folder)
6. public void AddFolder(string folderName)
7. public void Remove(File file)
8. public void Remove(Folder folder)
9. public File GetFileByName(string fileName)
10. public Folder GetFolderByName(string folderName)3
11. private List<File> files;
12. private List<Folder> folders;

2. Папка : Container
1. public void GetItemsCount()
2. public Container[] ListSubItems()
3. private void Add(File file)
4. public void Add(Folder folder)
5. public void Remove(File file)
6. public void Remove(Folder folder)
7. public File GetFileByName(string fileName)
8. public Folder GetFolderByName(string folderName)
9. private List<File> files;
10. private List<Folder> folders;

3. Файл : Container
1. public string FileType{get;set;}
2. private double fileSize;
3. public byte[] FileData{get;set;}

4. abstract Container:
1. public abstract double GetSize()
2. public string Name{get; set;}
3. public string Path{get;set;}
4. public DateTime CreatedOn {get; set;}
5. public DateTime LastModified{get;set;}

5. NavigationService
