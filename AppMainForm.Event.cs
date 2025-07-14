using ProjectList.Github;

namespace ProjectList
{
    partial class AppMainForm : Form
    {
        private void RefreshRepositoryList(object? _sender, EventArgs _e)
        {
            if (DesignMode) return;
            tableLayoutPanel3.Controls.Clear();
            tableLayoutPanel3.RowStyles.Clear();
            tableLayoutPanel3.RowCount = 0;
            if (InvokeRequired)
            {
                Invoke(new Action(() => RefreshRepositoryList(_sender, _e)));
                return;
            }
            Task.Run(async () =>
            {
                if (githubApi.UserInfo is not null)
                {
                    await githubApi.UserInfo.FetchRepositoriesAsync();
                }
            });
        }

        private void OnRepositoryFetched(object? _sender, List<Repository> _repositories)
        {
            foreach (Repository _repo in _repositories)
            {
                // insert a LigneProject in the tableLayoutPanel3
                LigneProjet _ligneProject = new LigneProjet(_repo);
                if(tableLayoutPanel3.InvokeRequired)
                {
                    tableLayoutPanel3.Invoke(new Action(() => tableLayoutPanel3.Controls.Add(_ligneProject)));
                }
                else
                {
                    tableLayoutPanel3.Controls.Add(_ligneProject);
                }
            }

            projectCountLabel.Invoke(new Action(() => 
            {
                projectCountLabel.Text = $"Nombre de projets : {_repositories.Count}";
            }));
        }
    }
}