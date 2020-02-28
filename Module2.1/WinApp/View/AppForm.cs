using System.Windows.Forms;
using WinApp.ViewModel;

namespace WinApp.View
{
    partial class AppForm : Form
    {
        private readonly AppFormViewModel _viewModel;

        public AppForm(AppFormViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            AllRadioButton.Checked = true;
        }
        
        private void PathTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _viewModel.DirectoryPath = pathTextBox.Text;
        }
        
        private void PathButton_Click(object sender, System.EventArgs e)
        {
            var fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };

            var path = fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : null;

            if (path != null)
            {
                pathTextBox.Text = path;
                _viewModel.DirectoryPath = path;
            }
        }

        private void ButtonClearFilter_Click(object sender, System.EventArgs e)
        {
            DirectoriesRadioButton.Checked = false;
            NameFileRadioButton.Checked = false;
            AllRadioButton.Checked = true;
            StopFileCheckBox.Checked = false;
            StopAfterFilterTextBox.Text = string.Empty;
            SearchStringTextBox.Text = string.Empty;
        }

        private void SearchStringTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _viewModel.SearchString = SearchStringTextBox.Text;
        }

        private void SelectResult_Update(object sender, System.EventArgs e)
        {
            _viewModel.DirectoryAdded = DirectoriesRadioButton.Checked || AllRadioButton.Checked;
            _viewModel.FileAdded = NameFileRadioButton.Checked || AllRadioButton.Checked;
        }

        private void StopAfterFilterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _viewModel.StopAfterFilter = StopAfterFilterTextBox.Text;
        }

        private void StopFileCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            _viewModel.IsStopAfterFilter = StopFileCheckBox.Checked;
        }

        private void FilterButton_Click(object sender, System.EventArgs e)
        {
            TreeElementsListBox.Items.Clear();
            LogElementsListBox.Items.Clear();

            var result = _viewModel.StartProcess();

            if (!result.ResultIsCorrect)
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var path in result.ReturnedPath)
            {
                TreeElementsListBox.Items.Add(path);
            }
            foreach (var path in result.Logs)
            {
                LogElementsListBox.Items.Add(path);
            }
        }
  
    }
}
