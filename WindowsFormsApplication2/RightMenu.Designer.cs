using System.Collections.Generic;
using System.Diagnostics;

namespace GUI2
{
    partial class RightMenu
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
            this.menuItem1 = new GUI2.MenuItem();
            this.SuspendLayout();
            // 
            // menuItem1
            // 
            this.menuItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuItem1.Location = new System.Drawing.Point(0, 0);
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(150, 84);
            this.menuItem1.TabIndex = 0;
            this.menuItem1.Click += new System.EventHandler(this.MenuItem_click);
            // 
            // rightMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.Controls.Add(this.menuItem1);
            this.Name = "rightMenu";
            this.Size = new System.Drawing.Size(150, 372);
            this.Load += new System.EventHandler(this.RightMenu_load);
            this.ResumeLayout(false);

        }

        #endregion

        internal MenuItem menuItem1;
    }
}
