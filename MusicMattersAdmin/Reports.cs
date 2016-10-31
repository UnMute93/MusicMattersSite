using MusicMattersAdmin.Classes;
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
                var uneditedResult = from flag in db.Flags
                                     join flaggable in db.Flaggables on flag.FlagID equals flaggable.FlagID
                                     join comment in db.Comments on flaggable.FlaggableID equals comment.CommentID
                                     //where flaggable.Time > comment.TimeEdited
                                     select new { flaggable.ID, flag.Name, comment.Content, flaggable.Time };

                var editedResult = from flag in db.Flags
                                   join flaggable in db.Flaggables on flag.FlagID equals flaggable.FlagID
                                   join commenthistory in db.CommentHistories on flaggable.FlaggableID equals commenthistory.CommentID
                                   //where flaggable.Time > commenthistory.Time
                                   select new { flaggable.ID, flag.Name, commenthistory.Content, flaggable.Time };

                BindingList<Report> list = new BindingList<Report>();

                foreach (var item in uneditedResult)
                {
                    Report r = new Report();
                    r.ReportID = item.ID;
                    r.Status = "Unedited";
                    r.FlagName = item.Name;
                    r.Content = item.Content;
                    r.Time = item.Time;
                    list.Add(r);
                }
                foreach (var item in editedResult)
                {
                    Report r = new Report();
                    r.ReportID = item.ID;
                    r.Status = "Edited";
                    r.FlagName = item.Name;
                    r.Content = item.Content;
                    r.Time = item.Time;
                    list.Add(r);
                }

                ReportGridView.DataSource = list;
            }
        }
    }
}
