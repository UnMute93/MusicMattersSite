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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            using (var db = new MusicMattersDbDataSet())
            {
                /*var resportResult = from flag in db.Flags
                                    join flaggable in db.Flaggables on flag.FlagID equals flaggable.FlagID
                                    join comment in db.Comments on flaggable.FlaggableID equals comment.CommentID
                                    where flaggable.Time */
            }
        }
    }
}
