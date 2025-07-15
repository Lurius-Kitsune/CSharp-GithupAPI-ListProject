namespace ProjectList
{
    partial class LigneProjet
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            dowloadButton = new Button();
            projectNameLabel = new Label();
            openNavigatorButton = new Button();
            visibilityLabel = new Label();
            SuspendLayout();
            // 
            // dowloadButton
            // 
            dowloadButton.AutoSize = true;
            dowloadButton.Location = new Point(434, 116);
            dowloadButton.Name = "dowloadButton";
            dowloadButton.Size = new Size(105, 25);
            dowloadButton.TabIndex = 0;
            dowloadButton.Text = "Clonner le projet";
            dowloadButton.UseVisualStyleBackColor = true;
            dowloadButton.Click += dowloadButton_Click;
            // 
            // projectNameLabel
            // 
            projectNameLabel.AutoSize = true;
            projectNameLabel.Location = new Point(48, 36);
            projectNameLabel.Name = "projectNameLabel";
            projectNameLabel.Size = new Size(85, 15);
            projectNameLabel.TabIndex = 1;
            projectNameLabel.Text = "Nom du projet";
            // 
            // openNavigatorButton
            // 
            openNavigatorButton.Location = new Point(545, 116);
            openNavigatorButton.Name = "openNavigatorButton";
            openNavigatorButton.Size = new Size(75, 23);
            openNavigatorButton.TabIndex = 2;
            openNavigatorButton.Text = "button2";
            openNavigatorButton.UseVisualStyleBackColor = true;
            // 
            // visibilityLabel
            // 
            visibilityLabel.AutoSize = true;
            visibilityLabel.Location = new Point(48, 116);
            visibilityLabel.Name = "visibilityLabel";
            visibilityLabel.Size = new Size(43, 15);
            visibilityLabel.TabIndex = 3;
            visibilityLabel.Text = "Private";
            // 
            // LigneProjet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(visibilityLabel);
            Controls.Add(openNavigatorButton);
            Controls.Add(projectNameLabel);
            Controls.Add(dowloadButton);
            Name = "LigneProjet";
            Size = new Size(634, 150);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button dowloadButton;
        private Label projectNameLabel;
        private Button openNavigatorButton;
        private Label visibilityLabel;
    }
}
