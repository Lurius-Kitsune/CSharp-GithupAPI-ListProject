using ProjectList.Github;
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
            CloneRepository(_folderPath);
        }

        private void CloneRepository(string _folderPath)
        {
            if (string.IsNullOrEmpty(repositoryUrl)) return;
            // Do git clone

            string _gitCommand = $"git clone {repositoryUrl} \"{Path.Combine(_folderPath, projectNameLabel.Text)}\"";
            ProcessStartInfo _startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {_gitCommand}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            _startInfo.RedirectStandardOutput = true;
            // launch commandline

            try
            {
                using Process _process = new Process();
                _process.StartInfo = _startInfo;
                _process.Start();

                // Lecture des sorties (optionnelle mais utile pour déboguer)
                string _output = _process.StandardOutput.ReadToEnd();
                string _error = _process.StandardError.ReadToEnd();

                _process.WaitForExit();

                // Vérification du résultat
                if (_process.ExitCode == 0)
                {
                    MessageBox.Show("Clonage réussi !");
                }
                else
                {
                    MessageBox.Show($"Erreur lors du clonage :\n{_error}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception lors du clonage : {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
