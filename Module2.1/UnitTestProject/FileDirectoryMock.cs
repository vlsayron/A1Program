using System;
using System.Collections.Generic;
using SystemVisitor;

namespace UnitTestProject
{
    public class FileDirectoryMock : IFileDirectoryProvider
    {
        //  DirMain
        //  |-DirOne.1
        //  | |-FileTwo.1.1
        //  | |-FileTwo.1.2
        //  |-DirOne.2
        //  | |-FileTwo.2.1
        //  | |-FileTwo.2.2
        //  |-FileOne.1
        //  |-FileOne.2

        public bool DirectoryExists(string directoryPath)
        {
            return directoryPath == "DirMain" || directoryPath == "DirOne.1" || directoryPath == "DirOne.2";
        }

        public IEnumerable<TreeElement> GetFileSystemEntries(string path)
        {
            if (path == "DirMain")
            {
                return new List<TreeElement>()
                {
                    new TreeElement(TreeElement.ElementType.Directory, "DirOne.1"),
                    new TreeElement(TreeElement.ElementType.Directory, "DirOne.2"),
                    new TreeElement(TreeElement.ElementType.File, "FileOne.1"),
                    new TreeElement(TreeElement.ElementType.File, "FileOne.2")
                };
            }

            if (path == "DirOne.1")
            {
                return new List<TreeElement>()
                {
                    new TreeElement(TreeElement.ElementType.File, "FileTwo.1.1"),
                    new TreeElement(TreeElement.ElementType.File, "FileTwo.1.2")
                };
            }

            if (path == "DirOne.2")
            {
                return new List<TreeElement>()
                {
                    new TreeElement(TreeElement.ElementType.File, "FileTwo.2.1"),
                    new TreeElement(TreeElement.ElementType.File, "FileTwo.2.2")
                };
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
