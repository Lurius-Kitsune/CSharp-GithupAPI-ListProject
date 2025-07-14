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

namespace ProjectList
{
    public partial class LigneProjet : UserControl
    {
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

        }
    }
}
