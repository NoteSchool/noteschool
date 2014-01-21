namespace GUI2
{
    partial class NoteEditorToolBox
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
            this.police = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.Label();
            this.export = new System.Windows.Forms.Label();
            this.likes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.police.AutoSize = true;
            this.police.Location = new System.Drawing.Point(4, 21);
            this.police.Name = "label1";
            this.police.Size = new System.Drawing.Size(35, 13);
            this.police.TabIndex = 0;
            this.police.Text = "[police]";
            // 
            // label2
            // 
            this.color.AutoSize = true;
            this.color.Location = new System.Drawing.Point(57, 21);
            this.color.Name = "label2";
            this.color.Size = new System.Drawing.Size(35, 13);
            this.color.TabIndex = 1;
            this.color.Text = "[color]";
            // 
            // label3
            // 
            this.export.AutoSize = true;
            this.export.Location = new System.Drawing.Point(112, 21);
            this.export.Name = "label3";
            this.export.Size = new System.Drawing.Size(35, 13);
            this.export.TabIndex = 2;
            this.export.Text = "[export]";
            // 
            // label4
            // 
            this.likes.AutoSize = true;
            this.likes.Location = new System.Drawing.Point(170, 21);
            this.likes.Name = "label4";
            this.likes.Size = new System.Drawing.Size(35, 13);
            this.likes.TabIndex = 3;
            this.likes.Text = "0 J'aime";
            // 
            // NoteEditorToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.likes);
            this.Controls.Add(this.export);
            this.Controls.Add(this.color);
            this.Controls.Add(this.police);
            this.Name = "NoteEditorToolBox";
            this.Size = new System.Drawing.Size(229, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label police;
        private System.Windows.Forms.Label color;
        private System.Windows.Forms.Label export;
        private System.Windows.Forms.Label likes;
    }
}
