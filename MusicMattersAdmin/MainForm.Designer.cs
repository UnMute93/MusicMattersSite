namespace MusicMattersAdmin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReportButton = new System.Windows.Forms.Button();
            this.ContentButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.albumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userArtistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flaggablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentHistoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aspNetUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportButton
            // 
            this.ReportButton.Location = new System.Drawing.Point(23, 19);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(146, 23);
            this.ReportButton.TabIndex = 0;
            this.ReportButton.Text = "Reports";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // ContentButton
            // 
            this.ContentButton.Enabled = false;
            this.ContentButton.Location = new System.Drawing.Point(23, 61);
            this.ContentButton.Name = "ContentButton";
            this.ContentButton.Size = new System.Drawing.Size(146, 23);
            this.ContentButton.TabIndex = 1;
            this.ContentButton.Text = "Content";
            this.ContentButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReportButton);
            this.groupBox1.Controls.Add(this.ContentButton);
            this.groupBox1.Location = new System.Drawing.Point(40, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Review submissions";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.albumsToolStripMenuItem,
            this.artistsToolStripMenuItem,
            this.aspNetUsersToolStripMenuItem,
            this.commentHistoriesToolStripMenuItem,
            this.commentsToolStripMenuItem,
            this.flaggablesToolStripMenuItem,
            this.flagsToolStripMenuItem,
            this.songsToolStripMenuItem,
            this.userArtistsToolStripMenuItem,
            this.userProfilesToolStripMenuItem});
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tablesToolStripMenuItem.Text = "Tables";
            // 
            // albumsToolStripMenuItem
            // 
            this.albumsToolStripMenuItem.Name = "albumsToolStripMenuItem";
            this.albumsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.albumsToolStripMenuItem.Text = "Albums";
            this.albumsToolStripMenuItem.Click += new System.EventHandler(this.albumsToolStripMenuItem_Click);
            // 
            // userProfilesToolStripMenuItem
            // 
            this.userProfilesToolStripMenuItem.Name = "userProfilesToolStripMenuItem";
            this.userProfilesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.userProfilesToolStripMenuItem.Text = "UserProfiles";
            // 
            // userArtistsToolStripMenuItem
            // 
            this.userArtistsToolStripMenuItem.Name = "userArtistsToolStripMenuItem";
            this.userArtistsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.userArtistsToolStripMenuItem.Text = "UserArtists";
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.songsToolStripMenuItem.Text = "Songs";
            // 
            // flagsToolStripMenuItem
            // 
            this.flagsToolStripMenuItem.Name = "flagsToolStripMenuItem";
            this.flagsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.flagsToolStripMenuItem.Text = "Flags";
            // 
            // flaggablesToolStripMenuItem
            // 
            this.flaggablesToolStripMenuItem.Name = "flaggablesToolStripMenuItem";
            this.flaggablesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.flaggablesToolStripMenuItem.Text = "Flaggables";
            // 
            // commentsToolStripMenuItem
            // 
            this.commentsToolStripMenuItem.Name = "commentsToolStripMenuItem";
            this.commentsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.commentsToolStripMenuItem.Text = "Comments";
            // 
            // commentHistoriesToolStripMenuItem
            // 
            this.commentHistoriesToolStripMenuItem.Name = "commentHistoriesToolStripMenuItem";
            this.commentHistoriesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.commentHistoriesToolStripMenuItem.Text = "CommentHistories";
            // 
            // aspNetUsersToolStripMenuItem
            // 
            this.aspNetUsersToolStripMenuItem.Name = "aspNetUsersToolStripMenuItem";
            this.aspNetUsersToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aspNetUsersToolStripMenuItem.Text = "AspNetUsers";
            // 
            // artistsToolStripMenuItem
            // 
            this.artistsToolStripMenuItem.Name = "artistsToolStripMenuItem";
            this.artistsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.artistsToolStripMenuItem.Text = "Artists";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Button ContentButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem albumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aspNetUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentHistoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flaggablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userArtistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userProfilesToolStripMenuItem;
    }
}