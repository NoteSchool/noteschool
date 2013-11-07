namespace GUI
{
    partial class NotetakingMainPage
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
            this.rtbNoteTaking = new System.Windows.Forms.RichTextBox();
            this.btnLeaveGroup = new System.Windows.Forms.Button();
            this.rtbReadOnly = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbNoteTaking
            // 
            this.rtbNoteTaking.Location = new System.Drawing.Point(18, 37);
            this.rtbNoteTaking.Name = "rtbNoteTaking";
            this.rtbNoteTaking.Size = new System.Drawing.Size(305, 404);
            this.rtbNoteTaking.TabIndex = 0;
            this.rtbNoteTaking.Text = "";
            // 
            // btnLeaveGroup
            // 
            this.btnLeaveGroup.Location = new System.Drawing.Point(300, 462);
            this.btnLeaveGroup.Name = "btnLeaveGroup";
            this.btnLeaveGroup.Size = new System.Drawing.Size(127, 23);
            this.btnLeaveGroup.TabIndex = 1;
            this.btnLeaveGroup.Text = "Quitter le groupe";
            this.btnLeaveGroup.UseVisualStyleBackColor = true;
            // 
            // rtbReadOnly
            // 
            this.rtbReadOnly.Location = new System.Drawing.Point(346, 37);
            this.rtbReadOnly.Name = "rtbReadOnly";
            this.rtbReadOnly.ReadOnly = true;
            this.rtbReadOnly.Size = new System.Drawing.Size(319, 404);
            this.rtbReadOnly.TabIndex = 2;
            this.rtbReadOnly.Text = "";
            // 
            // NotetakingMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbReadOnly);
            this.Controls.Add(this.btnLeaveGroup);
            this.Controls.Add(this.rtbNoteTaking);
            this.Name = "NotetakingMainPage";
            this.Size = new System.Drawing.Size(705, 524);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNoteTaking;
        private System.Windows.Forms.Button btnLeaveGroup;
        private System.Windows.Forms.RichTextBox rtbReadOnly;

    }
}
