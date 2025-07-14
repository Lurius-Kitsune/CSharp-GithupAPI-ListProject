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
            connectionButton = new ConnectionButton();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            usernameInfo = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cancelAuthButton = new Button();
            connectionCode = new Label();
            panel1 = new Panel();
            tabPage2 = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button1 = new Button();
            projectCountLabel = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
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
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.InitialImage = Properties.Resources.image;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
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
            flowLayoutPanel1.Location = new Point(0, 119);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(410, 31);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // usernameInfo
            // 
            usernameInfo.AutoSize = true;
            usernameInfo.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameInfo.Location = new Point(0, 0);
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
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(726, 516);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(718, 488);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(712, 482);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel2.Controls.Add(usernameInfo, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(159, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(550, 150);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(cancelAuthButton);
            flowLayoutPanel2.Controls.Add(connectionCode);
            flowLayoutPanel2.Location = new Point(0, 90);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(250, 29);
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
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(712, 0);
            panel1.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(718, 488);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(712, 482);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(button1);
            flowLayoutPanel3.Controls.Add(projectCountLabel);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(706, 29);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(628, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // projectCountLabel
            // 
            projectCountLabel.AutoSize = true;
            projectCountLabel.Location = new Point(478, 0);
            projectCountLabel.Name = "projectCountLabel";
            projectCountLabel.Size = new Size(144, 15);
            projectCountLabel.TabIndex = 1;
            projectCountLabel.Text = "Nombre de repos Github :";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 38);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(706, 441);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // AppMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 516);
            Controls.Add(tabControl1);
            Name = "AppMainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button1;
        private Label projectCountLabel;
        private TableLayoutPanel tableLayoutPanel4;
    }
}
