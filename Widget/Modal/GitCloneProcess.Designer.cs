namespace ProjectList.Widget.Modal
{
    partial class GitCloneProcess
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
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(55, 52);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(486, 23);
            progressBar1.TabIndex = 0;
            // 
            // GitCloneProcess
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 123);
            Controls.Add(progressBar1);
            Name = "GitCloneProcess";
            Text = "GitCloneProcess";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
    }
}