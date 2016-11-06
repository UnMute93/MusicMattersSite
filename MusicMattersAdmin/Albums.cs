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
    public partial class Albums : Form
    {
        public Albums()
        {
            InitializeComponent();
        }

        private void Albums_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'musicMattersDbDataSet.Albums' table. You can move, or remove it, as needed.
            this.albumsTableAdapter.Fill(this.musicMattersDbDataSet.Albums);
        }
    }
}
