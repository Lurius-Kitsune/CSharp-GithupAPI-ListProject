﻿using ProjectList.Widget.Buttons;

namespace ProjectList
{
    partial class Form1
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
            connectionButton = new ConnectionButton();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            usernameInfo = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cancelAuthButton = new Button();
            connectionCode = new Label();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AccessibleName = "Token";
            textBox1.Anchor = AnchorStyles.Bottom;
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(3, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "tzersqd";
            // 
            // connectionButton
            // 
            connectionButton.Anchor = AnchorStyles.Bottom;
            connectionButton.AutoSize = true;
            connectionButton.BackColor = Color.Red;
            connectionButton.Location = new Point(320, 3);
            connectionButton.Name = "connectionButton";
            connectionButton.Size = new Size(87, 25);
            connectionButton.TabIndex = 1;
            connectionButton.Text = "Connecter";
            connectionButton.UseVisualStyleBackColor = false;
            connectionButton.Click += connectionButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.InitialImage = Properties.Resources.image;
            pictureBox1.Location = new Point(6, 6);
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
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(connectionButton);
            flowLayoutPanel1.Location = new Point(152, 97);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(638, 31);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // usernameInfo
            // 
            usernameInfo.AutoSize = true;
            usernameInfo.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameInfo.Location = new Point(148, 6);
            usernameInfo.Margin = new Padding(0);
            usernameInfo.Name = "usernameInfo";
            usernameInfo.Size = new Size(210, 23);
            usernameInfo.TabIndex = 3;
            usernameInfo.Text = "Username and information";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-1, -1);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(801, 450);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flowLayoutPanel2);
            tabPage1.Controls.Add(flowLayoutPanel1);
            tabPage1.Controls.Add(usernameInfo);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(793, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(cancelAuthButton);
            flowLayoutPanel2.Controls.Add(connectionCode);
            flowLayoutPanel2.Location = new Point(152, 66);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(638, 31);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // cancelAuthButton
            // 
            cancelAuthButton.Location = new Point(3, 3);
            cancelAuthButton.Name = "cancelAuthButton";
            cancelAuthButton.Size = new Size(75, 23);
            cancelAuthButton.TabIndex = 5;
            cancelAuthButton.Text = "Annuler";
            cancelAuthButton.UseVisualStyleBackColor = true;
            // 
            // connectionCode
            // 
            connectionCode.AutoSize = true;
            connectionCode.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectionCode.Location = new Point(81, 0);
            connectionCode.Margin = new Padding(0);
            connectionCode.Name = "connectionCode";
            connectionCode.Size = new Size(169, 23);
            connectionCode.TabIndex = 4;
            connectionCode.Text = "Code de connexion : ";
            connectionCode.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(793, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 350);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private ConnectionButton connectionButton;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label usernameInfo;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label connectionCode;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button cancelAuthButton;
    }
}
