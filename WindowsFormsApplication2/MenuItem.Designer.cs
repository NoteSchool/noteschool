namespace GUI2
{
    partial class MenuItem
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
            this.ItemText = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ItemLeftBorder = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.ItemIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemText
            // 
            this.ItemText.AutoSize = true;
            this.ItemText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(174)))));
            this.ItemText.Location = new System.Drawing.Point(39, 50);
            this.ItemText.Name = "ItemText";
            this.ItemText.Size = new System.Drawing.Size(71, 16);
            this.ItemText.TabIndex = 1;
            this.ItemText.Text = "label text";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ItemLeftBorder});
            this.shapeContainer1.Size = new System.Drawing.Size(150, 84);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // ItemLeftBorder
            // 
            this.ItemLeftBorder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(196)))), ((int)(((byte)(165)))));
            this.ItemLeftBorder.BorderWidth = 2;
            this.ItemLeftBorder.Name = "lineShape1";
            this.ItemLeftBorder.Visible = false;
            this.ItemLeftBorder.X1 = 0;
            this.ItemLeftBorder.X2 = 0;
            this.ItemLeftBorder.Y1 = 0;
            this.ItemLeftBorder.Y2 = 84;
            // 
            // ItemIcon
            // 
            this.ItemIcon.BackColor = System.Drawing.Color.Transparent;
            this.ItemIcon.Image = global::GUI2.Properties.Resources.register;
            this.ItemIcon.Location = new System.Drawing.Point(61, 15);
            this.ItemIcon.Name = "ItemIcon";
            this.ItemIcon.Size = new System.Drawing.Size(32, 32);
            this.ItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ItemIcon.TabIndex = 0;
            this.ItemIcon.TabStop = false;
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemText);
            this.Controls.Add(this.ItemIcon);
            this.Controls.Add(this.shapeContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(150, 84);
            ((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ItemIcon;
        public System.Windows.Forms.Label ItemText;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape ItemLeftBorder;
    }
}
