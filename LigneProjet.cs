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

        public LigneProjet(string _projectLink)
        {
            InitializeComponent();
        }
    }
}
