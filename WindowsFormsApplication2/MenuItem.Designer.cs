namespace GUI2
{
    partial class menuItem
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.leftBorderLineShape = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(174)))));
            this.titleLabel.Location = new System.Drawing.Point(39, 50);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(71, 16);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "label text";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.leftBorderLineShape});
            this.shapeContainer1.Size = new System.Drawing.Size(150, 84);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // leftBorderLineShape
            // 
            this.leftBorderLineShape.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(196)))), ((int)(((byte)(165)))));
            this.leftBorderLineShape.BorderWidth = 2;
            this.leftBorderLineShape.Name = "leftBorderLineShape";
            this.leftBorderLineShape.Visible = false;
            this.leftBorderLineShape.X1 = 0;
            this.leftBorderLineShape.X2 = 0;
            this.leftBorderLineShape.Y1 = 0;
            this.leftBorderLineShape.Y2 = 84;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            //this.iconPictureBox.Image = global::GUI2.Properties.Resources.register;
            this.iconPictureBox.Location = new System.Drawing.Point(61, 15);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // menuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.shapeContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "menuItem";
            this.Size = new System.Drawing.Size(150, 84);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label titleLabel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape leftBorderLineShape;
        public System.Windows.Forms.PictureBox iconPictureBox;
    }
}
