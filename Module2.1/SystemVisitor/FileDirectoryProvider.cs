using System.Collections.Generic;
using System.IO;

namespace SystemVisitor
{
    public class FileDirectoryProvider: IFileDirectoryProvider
    {
        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public IEnumerable<TreeElement> GetFileSystemEntries(string path)
        {
            var entities = Directory.GetFileSystemEntries(path);
            
            var result = new List<TreeElement>();

            foreach (var entity in entities)
            {
                if (Directory.Exists(entity))
                {
                    var newDirectory = new TreeElement(TreeElement.ElementType.Directory, entity);
                    result.Add(newDirectory);
                    continue;
                }

                if (File.Exists(entity))
                {
                    var newFile = new TreeElement(TreeElement.ElementType.File, entity);
                    result.Add(newFile);
                }

            }

            return result;
        }
    }
}
