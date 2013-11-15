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
            this.SuspendLayout();
            // 
            // btnCreateGroups
            // 
            this.btnCreateGroups.Location = new System.Drawing.Point(674, 25);
            this.btnCreateGroups.Name = "btnCreateGroups";
            this.btnCreateGroups.Size = new System.Drawing.Size(119, 23);
            this.btnCreateGroups.TabIndex = 0;
            this.btnCreateGroups.Text = "Créer un groupe";
            this.btnCreateGroups.UseVisualStyleBackColor = true;
            // 
            // DisplayGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreateGroups);
            this.Name = "DisplayGroups";
            this.Size = new System.Drawing.Size(844, 467);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGroups;
    }
}
