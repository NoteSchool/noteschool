namespace GUI
{
    partial class CreateGroups
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
            this.lbGroupName = new System.Windows.Forms.Label();
            this.lbGroupTag = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.TbGroupTag = new System.Windows.Forms.TextBox();
            this.btnConfirmCreateGroup = new System.Windows.Forms.Button();
            this.btnGroupCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbGroupName
            // 
            this.lbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.Location = new System.Drawing.Point(384, 85);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(80, 13);
            this.lbGroupName.TabIndex = 0;
            this.lbGroupName.Text = "Nom du groupe";
            // 
            // lbGroupTag
            // 
            this.lbGroupTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGroupTag.AutoSize = true;
            this.lbGroupTag.Location = new System.Drawing.Point(408, 169);
            this.lbGroupTag.Name = "lbGroupTag";
            this.lbGroupTag.Size = new System.Drawing.Size(31, 13);
            this.lbGroupTag.TabIndex = 1;
            this.lbGroupTag.Text = "Tags";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGroupName.Location = new System.Drawing.Point(374, 116);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(100, 20);
            this.tbGroupName.TabIndex = 2;
            // 
            // TbGroupTag
            // 
            this.TbGroupTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbGroupTag.Location = new System.Drawing.Point(374, 215);
            this.TbGroupTag.Name = "TbGroupTag";
            this.TbGroupTag.Size = new System.Drawing.Size(100, 20);
            this.TbGroupTag.TabIndex = 3;
            // 
            // btnConfirmCreateGroup
            // 
            this.btnConfirmCreateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmCreateGroup.Location = new System.Drawing.Point(320, 317);
            this.btnConfirmCreateGroup.Name = "btnConfirmCreateGroup";
            this.btnConfirmCreateGroup.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmCreateGroup.TabIndex = 4;
            this.btnConfirmCreateGroup.Text = "Créer";
            this.btnConfirmCreateGroup.UseVisualStyleBackColor = true;
            // 
            // btnGroupCancel
            // 
            this.btnGroupCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupCancel.Location = new System.Drawing.Point(468, 317);
            this.btnGroupCancel.Name = "btnGroupCancel";
            this.btnGroupCancel.Size = new System.Drawing.Size(75, 23);
            this.btnGroupCancel.TabIndex = 5;
            this.btnGroupCancel.Text = "Annuler";
            this.btnGroupCancel.UseVisualStyleBackColor = true;
            // 
            // CreateGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGroupCancel);
            this.Controls.Add(this.btnConfirmCreateGroup);
            this.Controls.Add(this.TbGroupTag);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.lbGroupTag);
            this.Controls.Add(this.lbGroupName);
            this.Name = "CreateGroups";
            this.Size = new System.Drawing.Size(844, 467);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGroupName;
        private System.Windows.Forms.Label lbGroupTag;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.TextBox TbGroupTag;
        private System.Windows.Forms.Button btnConfirmCreateGroup;
        private System.Windows.Forms.Button btnGroupCancel;
    }
}
