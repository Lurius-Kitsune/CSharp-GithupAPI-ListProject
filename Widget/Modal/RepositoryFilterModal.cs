using ProjectList.Github;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectList.Widget.Modal
{
    partial class RepositoryFilterModal : Form
    {
        RepositoryFilter repositoryFilter = new RepositoryFilter();
        public RepositoryFilterModal()
        {
            InitializeComponent();
            repoVisibilityComboBox.DataSource = Enum.GetValues(typeof(RepositoryType));
            reposAffiliationComboBox.DataSource = Enum.GetValues(typeof(RepositoryAffiliation));
            reposSortComboBox.DataSource = Enum.GetValues(typeof(RepositorySort));
        }

        public RepositoryFilter RepositoryFilter { get => repositoryFilter; private set => repositoryFilter = value; }

        private void repositoryFilterModal_Load(object sender, EventArgs e)
        {
            // bind the repository filter properties to the controls
            repoVisibilityComboBox.SelectedItem = RepositoryFilter.RepositoryType;
            reposAffiliationComboBox.SelectedItem = RepositoryFilter.RepositoryAffiliation;
            reposSortComboBox.SelectedItem = RepositoryFilter.RepositorySort;
            isArchivedCheckbox.Checked = RepositoryFilter.IsArchived;
            forkedCheckbox.Checked = RepositoryFilter.IsForked;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // update the repository filter properties based on the controls
            RepositoryFilter.RepositoryType = (RepositoryType)repoVisibilityComboBox.SelectedItem;
            RepositoryFilter.RepositoryAffiliation = (RepositoryAffiliation)reposAffiliationComboBox.SelectedItem;
            RepositoryFilter.RepositorySort = (RepositorySort)reposSortComboBox.SelectedItem;
            RepositoryFilter.IsArchived = isArchivedCheckbox.Checked;
            RepositoryFilter.IsForked = forkedCheckbox.Checked;
            // close the modal and return the filter
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
