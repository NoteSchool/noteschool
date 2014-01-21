namespace GUI2
{
    partial class NoteEditorList
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.borderLeftLineShape = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.searchContainerPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.itemContainerPanel = new System.Windows.Forms.Panel();
            this.searchContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.borderLeftLineShape});
            this.shapeContainer1.Size = new System.Drawing.Size(169, 396);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // borderLeftLineShape
            // 
            this.borderLeftLineShape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.borderLeftLineShape.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(212)))), ((int)(((byte)(215)))));
            this.borderLeftLineShape.Name = "borderLeftLineShape";
            this.borderLeftLineShape.X1 = 1;
            this.borderLeftLineShape.X2 = 1;
            this.borderLeftLineShape.Y1 = 0;
            this.borderLeftLineShape.Y2 = 396;
            // 
            // searchContainerPanel
            // 
            this.searchContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchContainerPanel.BackColor = System.Drawing.Color.White;
            this.searchContainerPanel.Controls.Add(this.searchTextBox);
            this.searchContainerPanel.Location = new System.Drawing.Point(2, 372);
            this.searchContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.searchContainerPanel.Name = "searchContainerPanel";
            this.searchContainerPanel.Padding = new System.Windows.Forms.Padding(3);
            this.searchContainerPanel.Size = new System.Drawing.Size(166, 24);
            this.searchContainerPanel.TabIndex = 2;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.searchTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(160, 14);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Recherche..";
            // 
            // itemContainerPanel
            // 
            this.itemContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemContainerPanel.AutoScroll = true;
            this.itemContainerPanel.Location = new System.Drawing.Point(2, 0);
            this.itemContainerPanel.Name = "itemContainerPanel";
            this.itemContainerPanel.Size = new System.Drawing.Size(167, 369);
            this.itemContainerPanel.TabIndex = 3;
            // 
            // NoteEditorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.itemContainerPanel);
            this.Controls.Add(this.searchContainerPanel);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "NoteEditorList";
            this.Size = new System.Drawing.Size(169, 396);
            this.searchContainerPanel.ResumeLayout(false);
            this.searchContainerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape borderLeftLineShape;
        private System.Windows.Forms.Panel searchContainerPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel itemContainerPanel;
    }
}
