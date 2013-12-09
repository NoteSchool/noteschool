namespace GUI2
{
    partial class Header
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
            this.Username = new System.Windows.Forms.Label();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.LogoSeparator = new Microsoft.VisualBasic.PowerPacks.LineShape();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username.AutoSize = true;
            this.Username.CausesValidation = false;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(628, 18);
            this.Username.Name = "label1";
            this.Username.Size = new System.Drawing.Size(72, 16);
            this.Username.TabIndex = 1;
            this.Username.Text = "text";
            this.Username.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.SearchInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchInput.BackColor = System.Drawing.Color.White;
            this.SearchInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchInput.ForeColor = System.Drawing.Color.Gray;
            this.SearchInput.Location = new System.Drawing.Point(309, 15);
            this.SearchInput.Name = "textBox1";
            this.SearchInput.Size = new System.Drawing.Size(165, 22);
            this.SearchInput.TabIndex = 2;
            this.SearchInput.Text = "Recherche";
            // 
            // pictureBox1
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logo.Image = global::GUI2.Properties.Resources.logo;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "pictureBox1";
            this.Logo.Size = new System.Drawing.Size(163, 52);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.LogoSeparator});
            this.shapeContainer1.Size = new System.Drawing.Size(725, 52);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.LogoSeparator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.LogoSeparator.BorderWidth = 5;
            this.LogoSeparator.Name = "lineShape1";
            this.LogoSeparator.X1 = 161;
            this.LogoSeparator.X2 = 161;
            this.LogoSeparator.Y1 = 1;
            this.LogoSeparator.Y2 = 52;
            // 
            // header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "header";
            this.Size = new System.Drawing.Size(725, 52);
            this.Load += new System.EventHandler(this.header_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label Username;
        public System.Windows.Forms.TextBox SearchInput;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape LogoSeparator;
    }
}
