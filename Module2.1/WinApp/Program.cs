using System;
using System.Windows.Forms;
using SystemVisitor;
using WinApp.View;
using WinApp.ViewModel;

namespace WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm(new AppFormViewModel(new FileDirectoryProvider())));
        }
    }
}
