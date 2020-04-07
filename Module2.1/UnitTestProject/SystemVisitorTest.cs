using System.IO;
using SystemVisitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class SystemVisitorTest
    {
        private static IFileDirectoryProvider _provider;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _provider = new FileDirectoryMock();
        }


        [TestMethod]
        public void CheckSystemVisitor_WithoutFilters()
        {
            _provider = new FileDirectoryMock();
            var visitor = new FileSystemVisitor(_provider, "DirMain");
            
            visitor.Start += message => { };
            visitor.Finish += message => { };
            visitor.DirectoryFinded += message => true;
            visitor.FileFinded += message => true;
            visitor.FilteredDirectoryFinded += message => true;
            visitor.FilteredFileFinded += message => true;

            var result = visitor.StartSearch();

            Assert.IsTrue(result.Count == 8);
            Assert.IsTrue(result[0].Type == TreeElement.ElementType.Directory &&
                          result[0].Path == "DirOne.1");
            Assert.IsTrue(result[7].Type == TreeElement.ElementType.File &&
                          result[7].Path == "FileOne.2");
        }

        [TestMethod]
        public void CheckSystemVisitor_OnlyFiles()
        {
            _provider = new FileDirectoryMock();
            var visitor = new FileSystemVisitor(_provider, "DirMain");

            visitor.Start += message => { };
            visitor.Finish += message => { };
            visitor.DirectoryFinded += message => true;
            visitor.FileFinded += message => true;
            visitor.FilteredDirectoryFinded += message => false;
            visitor.FilteredFileFinded += message => true;

            var result = visitor.StartSearch();

            Assert.IsTrue(result.Count == 6);
            Assert.IsTrue(result[0].Type == TreeElement.ElementType.File &&
                          result[0].Path == "FileTwo.1.1");
            Assert.IsTrue(result[5].Type == TreeElement.ElementType.File &&
                          result[5].Path == "FileOne.2");
        }

        [TestMethod]
        public void CheckSystemVisitor_OnlyDirectories()
        {
            _provider = new FileDirectoryMock();
            var visitor = new FileSystemVisitor(_provider, "DirMain");

            visitor.Start += message => { };
            visitor.Finish += message => { };
            visitor.DirectoryFinded += message => true;
            visitor.FileFinded += message => true;
            visitor.FilteredDirectoryFinded += message => true;
            visitor.FilteredFileFinded += message => false;

            var result = visitor.StartSearch();

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Type == TreeElement.ElementType.Directory &&
                          result[0].Path == "DirOne.1");
            Assert.IsTrue(result[1].Type == TreeElement.ElementType.Directory &&
                          result[1].Path == "DirOne.2");
        }

        [TestMethod]
        public void CheckSystemVisitor_CorrectSearch()
        {
            _provider = new FileDirectoryMock();

            var visitor = new FileSystemVisitor(_provider, "DirMain", param => param.Contains("One"));
            
            visitor.Start += message => { };
            visitor.Finish += message => { };
            visitor.DirectoryFinded += message => true;
            visitor.FileFinded += message => true;
            visitor.FilteredDirectoryFinded += message => true;
            visitor.FilteredFileFinded += message => true;

            var result = visitor.StartSearch();

            Assert.IsTrue(result.Count == 4);
            Assert.IsTrue(result[0].Type == TreeElement.ElementType.Directory &&
                          result[0].Path == "DirOne.1");
            Assert.IsTrue(result[3].Type == TreeElement.ElementType.File &&
                          result[3].Path == "FileOne.2");
        }

        [TestMethod]
        public void CheckSystemVisitor_StopAfterFile()
        {
            _provider = new FileDirectoryMock();

            var visitor = new FileSystemVisitor(_provider, "DirMain");

            visitor.Start += message => { };
            visitor.Finish += message => { };
            visitor.DirectoryFinded += message => true;
            visitor.FileFinded += element =>
            {
                var name = Path.GetFileName(element.Path);
                return string.IsNullOrEmpty(name) || !name.ToLower().Contains("FileTwo.2.1".ToLower());
            };
            visitor.FilteredDirectoryFinded += message => true;
            visitor.FilteredFileFinded += message => true;

            var result = visitor.StartSearch();

            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0].Type == TreeElement.ElementType.Directory &&
                          result[0].Path == "DirOne.1");
            Assert.IsTrue(result[4].Type == TreeElement.ElementType.File &&
                          result[4].Path == "FileTwo.2.1");
        }

        [TestMethod]
        public void CheckSystemVisitor_SearchWithParam()
        {
            _provider = new FileDirectoryMock();

            var visitor = new FileSystemVisitor(_provider, "DirMain", param => param.Contains("Two"));

            visitor.Start += message => { };
            visitor.Finish += message => { };
            visitor.DirectoryFinded += message => true;
            visitor.FileFinded += element =>
            {
                var name = Path.GetFileName(element.Path);
                return string.IsNullOrEmpty(name) || !name.ToLower().Contains("FileTwo.1.2".ToLower());
            };
            visitor.FilteredDirectoryFinded += message => false;
            visitor.FilteredFileFinded += message => true;

            var result = visitor.StartSearch();

            Assert.IsTrue(result.Count == 2);

            Assert.IsTrue(result[0].Type == TreeElement.ElementType.File &&
                          result[0].Path == "FileTwo.1.1");
            Assert.IsTrue(result[1].Type == TreeElement.ElementType.File &&
                          result[1].Path == "FileTwo.1.2");
        }

    }
}
