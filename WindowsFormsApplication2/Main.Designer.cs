namespace GUI2
{
    partial class Main
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftMenu1 = new GUI2.leftMenu();
            this.header1 = new GUI2.header();
            this.content1 = new GUI2.content();
            this.SuspendLayout();
            // 
            // leftMenu1
            // 
            this.leftMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.leftMenu1.Location = new System.Drawing.Point(0, 51);
            this.leftMenu1.Name = "leftMenu1";
            this.leftMenu1.Size = new System.Drawing.Size(164, 435);
            this.leftMenu1.TabIndex = 1;
            this.leftMenu1.Load += new System.EventHandler(this.rightMenu1_Load);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.White;
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(795, 52);
            this.header1.TabIndex = 0;
            this.header1.Load += new System.EventHandler(this.header_Load);
            // 
            // content1
            // 
            this.content1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.content1.AutoSize = true;
            this.content1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.content1.Location = new System.Drawing.Point(164, 52);
            this.content1.Name = "content1";
            this.content1.Size = new System.Drawing.Size(631, 427);
            this.content1.TabIndex = 4;
            this.content1.Load += new System.EventHandler(this.content1_Load);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 480);
            this.Controls.Add(this.leftMenu1);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.content1);
            this.MinimumSize = new System.Drawing.Size(748, 471);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoteSchool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private header header1;
        private leftMenu leftMenu1;
        private content content1;
    }
}

