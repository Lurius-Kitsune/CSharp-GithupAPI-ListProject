using ProjectList.Widget.Buttons;

namespace ProjectList
{
    partial class AppMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the accessToken editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            usernameInfo = new Label();
            connectionButton = new ConnectionButton();
            githubTab = new TabControl();
            userInfoPage = new TabPage();
            projectListPage = new TabPage();
            panel1 = new Panel();
            ligneProjet1 = new LigneProjet();
            ligneProjet2 = new LigneProjet();
            ligneProjet3 = new LigneProjet();
            ligneProjet4 = new LigneProjet();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            githubTab.SuspendLayout();
            userInfoPage.SuspendLayout();
            projectListPage.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AccessibleName = "Token";
            textBox1.Anchor = AnchorStyles.Bottom;
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(358, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "tzersqd";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.InitialImage = Properties.Resources.image;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 139);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(usernameInfo);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(connectionButton);
            flowLayoutPanel1.Location = new Point(3, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(787, 280);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // usernameInfo
            // 
            usernameInfo.AutoSize = true;
            usernameInfo.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameInfo.Location = new Point(145, 0);
            usernameInfo.Margin = new Padding(0);
            usernameInfo.Name = "usernameInfo";
            usernameInfo.Size = new Size(210, 23);
            usernameInfo.TabIndex = 3;
            usernameInfo.Text = "Username and information";
            // 
            // connectionButton
            // 
            connectionButton.Location = new Point(675, 3);
            connectionButton.Name = "connectionButton";
            connectionButton.Size = new Size(75, 23);
            connectionButton.TabIndex = 4;
            connectionButton.Text = "connectionButton1";
            connectionButton.UseVisualStyleBackColor = true;
            // 
            // githubTab
            // 
            githubTab.Controls.Add(userInfoPage);
            githubTab.Controls.Add(projectListPage);
            githubTab.Dock = DockStyle.Fill;
            githubTab.Location = new Point(0, 0);
            githubTab.Multiline = true;
            githubTab.Name = "githubTab";
            githubTab.SelectedIndex = 0;
            githubTab.Size = new Size(789, 447);
            githubTab.TabIndex = 4;
            // 
            // userInfoPage
            // 
            userInfoPage.Controls.Add(flowLayoutPanel1);
            userInfoPage.Location = new Point(4, 24);
            userInfoPage.Name = "userInfoPage";
            userInfoPage.Padding = new Padding(3);
            userInfoPage.Size = new Size(781, 419);
            userInfoPage.TabIndex = 0;
            userInfoPage.Text = "User Info";
            userInfoPage.UseVisualStyleBackColor = true;
            // 
            // projectListPage
            // 
            projectListPage.Controls.Add(panel1);
            projectListPage.Location = new Point(4, 24);
            projectListPage.Name = "projectListPage";
            projectListPage.Padding = new Padding(3);
            projectListPage.Size = new Size(781, 419);
            projectListPage.TabIndex = 1;
            projectListPage.Text = "Project List";
            projectListPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(ligneProjet4);
            panel1.Controls.Add(ligneProjet3);
            panel1.Controls.Add(ligneProjet2);
            panel1.Controls.Add(ligneProjet1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(775, 413);
            panel1.TabIndex = 0;
            // 
            // ligneProjet1
            // 
            ligneProjet1.AutoScroll = true;
            ligneProjet1.AutoSize = true;
            ligneProjet1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ligneProjet1.Dock = DockStyle.Top;
            ligneProjet1.Location = new Point(0, 0);
            ligneProjet1.Name = "ligneProjet1";
            ligneProjet1.Size = new Size(758, 142);
            ligneProjet1.TabIndex = 0;
            // 
            // ligneProjet2
            // 
            ligneProjet2.AutoScroll = true;
            ligneProjet2.AutoSize = true;
            ligneProjet2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ligneProjet2.Dock = DockStyle.Top;
            ligneProjet2.Location = new Point(0, 142);
            ligneProjet2.Name = "ligneProjet2";
            ligneProjet2.Size = new Size(758, 142);
            ligneProjet2.TabIndex = 1;
            // 
            // ligneProjet3
            // 
            ligneProjet3.AutoScroll = true;
            ligneProjet3.AutoSize = true;
            ligneProjet3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ligneProjet3.Dock = DockStyle.Top;
            ligneProjet3.Location = new Point(0, 284);
            ligneProjet3.Name = "ligneProjet3";
            ligneProjet3.Size = new Size(758, 142);
            ligneProjet3.TabIndex = 2;
            // 
            // ligneProjet4
            // 
            ligneProjet4.AutoScroll = true;
            ligneProjet4.AutoSize = true;
            ligneProjet4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ligneProjet4.Dock = DockStyle.Top;
            ligneProjet4.Location = new Point(0, 426);
            ligneProjet4.Name = "ligneProjet4";
            ligneProjet4.Size = new Size(758, 142);
            ligneProjet4.TabIndex = 3;
            // 
            // AppMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(789, 447);
            Controls.Add(githubTab);
            Name = "AppMainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            githubTab.ResumeLayout(false);
            userInfoPage.ResumeLayout(false);
            userInfoPage.PerformLayout();
            projectListPage.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label usernameInfo;
        private TabControl githubTab;
        private TabPage userInfoPage;
        private TabPage projectListPage;
        private Panel panel1;
        private ConnectionButton connectionButton;
        private LigneProjet ligneProjet1;
        private LigneProjet ligneProjet4;
        private LigneProjet ligneProjet3;
        private LigneProjet ligneProjet2;
    }
}
