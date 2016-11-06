using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicMattersAdmin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            Form nextForm = new Reports();
            nextForm.Show();
        }

        private void albumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nextForm = new Albums();
            nextForm.Show();
        }
    }
}
