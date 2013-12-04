namespace GUI
{
    partial class DisplayGroups
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateGroups = new System.Windows.Forms.Button();
            this.groupPanel = new System.Windows.Forms.Panel();
            this.tbSearchGroup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreateGroups
            // 
            this.btnCreateGroups.Location = new System.Drawing.Point(617, 16);
            this.btnCreateGroups.Name = "btnCreateGroups";
            this.btnCreateGroups.Size = new System.Drawing.Size(119, 23);
            this.btnCreateGroups.TabIndex = 0;
            this.btnCreateGroups.Text = "Créer un groupe";
            this.btnCreateGroups.UseVisualStyleBackColor = true;
            // 
            // groupPanel
            // 
            this.groupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel.AutoScroll = true;
            this.groupPanel.Location = new System.Drawing.Point(-12, 60);
            this.groupPanel.Name = "groupPanel";
            this.groupPanel.Size = new System.Drawing.Size(759, 505);
            this.groupPanel.TabIndex = 1;
            // 
            // tbSearchGroup
            // 
            this.tbSearchGroup.Location = new System.Drawing.Point(140, 18);
            this.tbSearchGroup.Name = "tbSearchGroup";
            this.tbSearchGroup.Size = new System.Drawing.Size(100, 20);
            this.tbSearchGroup.TabIndex = 2;
            this.tbSearchGroup.TextChanged += new System.EventHandler(this.tbSearchGroup_TextChanged);
            // 
            // DisplayGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tbSearchGroup);
            this.Controls.Add(this.groupPanel);
            this.Controls.Add(this.btnCreateGroups);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DisplayGroups";
            this.Size = new System.Drawing.Size(739, 568);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGroups;
        private System.Windows.Forms.Panel groupPanel;
        private System.Windows.Forms.TextBox tbSearchGroup;
    }
}
