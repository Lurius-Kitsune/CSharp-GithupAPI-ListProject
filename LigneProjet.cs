using ProjectList.Github;
using ProjectList.Widget.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectList
{
    public partial class LigneProjet : UserControl
    {

        string repositoryUrl = string.Empty;

        public LigneProjet()
        {
            InitializeComponent();
        }

        public LigneProjet(Repository _repository)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            projectNameLabel.Text = _repository.Name;
            visibilityLabel.Text = _repository.IsPrivate ? "Private" : _repository.Fork ? "Fork" : "Public";
            repositoryUrl = _repository.HtmlUrl;

        }

        private void dowloadButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _folderDialogue = new FolderBrowserDialog();
            _folderDialogue.Description = "Select the folder to clone the repository into";
            _folderDialogue.ShowNewFolderButton = true;
            string _folderPath = _folderDialogue.ShowDialog() == DialogResult.OK ? _folderDialogue.SelectedPath : string.Empty;

            if (string.IsNullOrEmpty(_folderPath)) return;
            GitCloneProcess _gitCloneProcess = new GitCloneProcess(repositoryUrl, _folderPath, projectNameLabel.Text);
        }

        private void openNavigatorButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo _startInfo = new ProcessStartInfo
            {
                FileName = repositoryUrl,
                UseShellExecute = true // Use the default browser to open the URL
            };
            Process.Start(_startInfo);
        }
    }
}
