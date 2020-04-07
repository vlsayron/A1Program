using System;
using System.Windows.Forms;
using Task2.Library;

namespace Task1.WinForm
{
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
        }
        private void NameTB_TextChanged(object sender, EventArgs e)
        {
            var name = NameTB.Text;
            LabelWelcome.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(name))
            {
                LabelWelcome.Text = $@"{WelcomeUser.Welcome(name)}";
            }
        }
    }
}
