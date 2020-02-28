using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemVisitor;
using WinApp.Model;

namespace WinApp.ViewModel
{
    class AppFormViewModel
    {
        public string DirectoryPath { get; set; }

        public bool DirectoryAdded { get; set; }
        public bool FileAdded { get; set; }

        public bool IsStopAfterFilter { get; set; }
        public string StopAfterFilter { get; set; }

        public string SearchString { get; set; }


        private readonly IFileDirectoryProvider _provider;
        private readonly List<string> _logs = new List<string>();

        public AppFormViewModel(IFileDirectoryProvider provider)
        {
            _provider = provider;
        }

        public VisitorViewResult StartProcess()
        {
            if (!_provider.DirectoryExists(DirectoryPath))
            {
                return new VisitorViewResult
                {
                    ResultIsCorrect = false,
                    ErrorMessage = $"Directory '{DirectoryPath}' is not exists"
                };
            }

            _logs.Clear();

            var visitor = new FileSystemVisitor(_provider, DirectoryPath, FilterCondition);

            visitor.Start += ShowLogMessage;
            visitor.Finish += ShowLogMessage;
            visitor.DirectoryFinded += VisitorOnDirectoryFinded;
            visitor.FileFinded += VisitorOnFileFinded;
            visitor.FilteredDirectoryFinded += VisitorOnFilteredDirectoryFinded;
            visitor.FilteredFileFinded += VisitorOnFilteredFileFinded;

            var visitorResult = visitor.StartSearch();
            var listResult = visitorResult.Select(path => path.Path).ToList();

            return new VisitorViewResult
            {
                ResultIsCorrect = true,
                ReturnedPath = listResult,
                Logs = _logs
            };

        }

        private bool FilterCondition(string path)
        {
            return string.IsNullOrEmpty(SearchString) || path.ToLower().Contains(SearchString.ToLower());
        }
        
        private bool VisitorOnDirectoryFinded(TreeElement element)
        {
            _logs.Add($"DirectoryFinded: {element.Path}");

            if (IsStopAfterFilter)
            {
                if (!string.IsNullOrEmpty(element.Path) &&
                    !string.IsNullOrEmpty(StopAfterFilter) &&
                    element.Path.ToLower().Contains(StopAfterFilter.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool VisitorOnFileFinded(TreeElement element)
        {
            _logs.Add($"FileFinded: {element.Path}");

            if (IsStopAfterFilter)
            {
                var name = Path.GetFileName(element.Path);

                if (!string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(StopAfterFilter) &&
                    name.ToLower().Contains(StopAfterFilter.ToLower()))
                { 
                    return false;
                }
            }

            return true;
        }
        
        private bool VisitorOnFilteredFileFinded(TreeElement element)
        {
            _logs.Add($"FilteredFileFinded: {element.Path}");

            return FileAdded;
        }
        
        private bool VisitorOnFilteredDirectoryFinded(TreeElement element)
        {
            _logs.Add($"FilteredDirectoryFinded: {element.Path}");

            return DirectoryAdded;
        }

        private void ShowLogMessage(string message)
        {
            _logs.Add(message);
        }
    }
}
