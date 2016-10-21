using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public async Task<bool> VerifyUserNamePassword(string userName, string password)
        {
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));
            return await usermanager.FindAsync(userName, password) != null;
        }

        private void aspNetUsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aspNetUsersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.musicMattersDbDataSet);

        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'musicMattersDbDataSet.AspNetUsers' table. You can move, or remove it, as needed.
            this.aspNetUsersTableAdapter.Fill(this.musicMattersDbDataSet.AspNetUsers);

        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            bool loginResult = await VerifyUserNamePassword(userNameTextBox.Text, passwordTextBox.Text);
            if (loginResult)
            {
                var nextForm = new MainForm();
                nextForm.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.");
            }
        }
    }
}
