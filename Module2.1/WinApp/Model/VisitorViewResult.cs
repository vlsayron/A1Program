using System.Collections.Generic;

namespace WinApp.Model
{
    public class VisitorViewResult
    {
        public bool ResultIsCorrect { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> ReturnedPath { get; set; }
        public List<string> Logs { get; set; }
    }
}
