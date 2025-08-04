namespace ProjectList.Widget.Modal
{
    partial class RepositoryFilterModal
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label4 = new Label();
            isArchivedCheckbox = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            reposSortComboBox = new ComboBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label2 = new Label();
            reposAffiliationComboBox = new ComboBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            labelIsForked = new Label();
            forkedCheckbox = new CheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            repoVisibilityComboBox = new ComboBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            searchButton = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 197);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel6, 0, 4);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel5, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel7, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(425, 197);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel6.Controls.Add(label4);
            flowLayoutPanel6.Controls.Add(isArchivedCheckbox);
            flowLayoutPanel6.Location = new Point(158, 140);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(109, 20);
            flowLayoutPanel6.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 1;
            label4.Text = "Sont des fork :";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // isArchivedCheckbox
            // 
            isArchivedCheckbox.AutoSize = true;
            isArchivedCheckbox.Dock = DockStyle.Fill;
            isArchivedCheckbox.Location = new Point(91, 3);
            isArchivedCheckbox.Name = "isArchivedCheckbox";
            isArchivedCheckbox.Size = new Size(15, 14);
            isArchivedCheckbox.TabIndex = 2;
            isArchivedCheckbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(reposSortComboBox);
            flowLayoutPanel1.Location = new Point(101, 79);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(223, 29);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 29);
            label3.TabIndex = 1;
            label3.Text = "Type du repos : ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reposSortComboBox
            // 
            reposSortComboBox.FormattingEnabled = true;
            reposSortComboBox.Location = new Point(99, 3);
            reposSortComboBox.Name = "reposSortComboBox";
            reposSortComboBox.Size = new Size(121, 23);
            reposSortComboBox.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel3.Location = new Point(98, 38);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(229, 35);
            flowLayoutPanel3.TabIndex = 2;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(label2);
            flowLayoutPanel4.Controls.Add(reposAffiliationComboBox);
            flowLayoutPanel4.Location = new Point(3, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(223, 29);
            flowLayoutPanel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 29);
            label2.TabIndex = 1;
            label2.Text = "Type du repos : ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reposAffiliationComboBox
            // 
            reposAffiliationComboBox.FormattingEnabled = true;
            reposAffiliationComboBox.Location = new Point(99, 3);
            reposAffiliationComboBox.Name = "reposAffiliationComboBox";
            reposAffiliationComboBox.Size = new Size(121, 23);
            reposAffiliationComboBox.TabIndex = 0;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel5.Controls.Add(labelIsForked);
            flowLayoutPanel5.Controls.Add(forkedCheckbox);
            flowLayoutPanel5.Location = new Point(158, 114);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(109, 20);
            flowLayoutPanel5.TabIndex = 4;
            // 
            // labelIsForked
            // 
            labelIsForked.AutoSize = true;
            labelIsForked.Dock = DockStyle.Fill;
            labelIsForked.Location = new Point(3, 0);
            labelIsForked.Name = "labelIsForked";
            labelIsForked.Size = new Size(82, 20);
            labelIsForked.TabIndex = 1;
            labelIsForked.Text = "Sont des fork :";
            labelIsForked.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // forkedCheckbox
            // 
            forkedCheckbox.AutoSize = true;
            forkedCheckbox.Dock = DockStyle.Fill;
            forkedCheckbox.Location = new Point(91, 3);
            forkedCheckbox.Name = "forkedCheckbox";
            forkedCheckbox.Size = new Size(15, 14);
            forkedCheckbox.TabIndex = 2;
            forkedCheckbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(repoVisibilityComboBox);
            flowLayoutPanel2.Location = new Point(101, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(223, 29);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 29);
            label1.TabIndex = 1;
            label1.Text = "Type du repos : ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // repoVisibilityComboBox
            // 
            repoVisibilityComboBox.FormattingEnabled = true;
            repoVisibilityComboBox.Location = new Point(99, 3);
            repoVisibilityComboBox.Name = "repoVisibilityComboBox";
            repoVisibilityComboBox.Size = new Size(121, 23);
            repoVisibilityComboBox.TabIndex = 0;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel7.AutoSize = true;
            flowLayoutPanel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel7.Controls.Add(searchButton);
            flowLayoutPanel7.Location = new Point(172, 166);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(81, 29);
            flowLayoutPanel7.TabIndex = 6;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(3, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 0;
            searchButton.Text = "Rechercher";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // RepositoryFilterModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(425, 197);
            Controls.Add(panel1);
            Name = "RepositoryFilterModal";
            Text = "RepositoryFilterModal";
            Load += repositoryFilterModal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label2;
        private ComboBox reposAffiliationComboBox;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private ComboBox repoVisibilityComboBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private ComboBox reposSortComboBox;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label labelIsForked;
        private CheckBox forkedCheckbox;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label label4;
        private CheckBox isArchivedCheckbox;
        private FlowLayoutPanel flowLayoutPanel7;
        private Button searchButton;
    }
}