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

namespace ProjectList.Widget.Modal
{
    public partial class GitCloneProcess : Form
    {

        string repositoryUrl = string.Empty;
        string folderPath = string.Empty;
        string projectName = string.Empty;

        public GitCloneProcess(string _repositoryUrl, string _folderPath, string _projectName)
        {
            InitializeComponent();
            repositoryUrl = _repositoryUrl;
            folderPath = _folderPath;
            projectName = _projectName;
            this.Load += new EventHandler(this.OnLoad);
            ShowDialog();
        }

        private async void OnLoad(object? _sender, EventArgs _e)
        {
            await Task.Run(() => Invoke(new Action(() => CloneRepository())));
            // Close the form after the process is done
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloneRepository()
        {
            if (string.IsNullOrEmpty(repositoryUrl)) return;
            // Do git clone
            string _gitCommand = $"git clone {repositoryUrl} \"{Path.Combine(folderPath, projectName)}\"";
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
            progressBar1.Value = 25;
            try
            {
                using Process _process = new Process();
                _process.StartInfo = _startInfo;
                progressBar1.Value = 50;
                _process.Start();
                // Lecture des sorties (optionnelle mais utile pour déboguer)
                string _output = _process.StandardOutput.ReadToEnd();
                string _error = _process.StandardError.ReadToEnd();

                _process.WaitForExit();
                progressBar1.Value = 100;
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
