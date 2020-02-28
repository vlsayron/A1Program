using System.Collections.Generic;

namespace SystemVisitor
{
    public interface IFileDirectoryProvider
    {
        bool DirectoryExists(string directoryPath);
        IEnumerable<TreeElement> GetFileSystemEntries(string path);
    }
}
