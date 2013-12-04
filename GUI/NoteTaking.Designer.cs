namespace GUI
{
    partial class NoteTaking
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
            this.rtbNoteTaking = new System.Windows.Forms.RichTextBox();
            this.btnLeaveGroup = new System.Windows.Forms.Button();
            this.rtbReadOnly = new System.Windows.Forms.RichTextBox();
            this.btnexport = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.FontButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.rating1 = new GUI.Rating();
            this.groupNameTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbNoteTaking
            // 
            this.rtbNoteTaking.Location = new System.Drawing.Point(15, 62);
            this.rtbNoteTaking.Name = "rtbNoteTaking";
            this.rtbNoteTaking.Size = new System.Drawing.Size(305, 356);
            this.rtbNoteTaking.TabIndex = 0;
            this.rtbNoteTaking.Text = "";
            this.rtbNoteTaking.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbNoteTaking_KeyUp);
            // 
            // btnLeaveGroup
            // 
            this.btnLeaveGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLeaveGroup.Location = new System.Drawing.Point(193, 429);
            this.btnLeaveGroup.Name = "btnLeaveGroup";
            this.btnLeaveGroup.Size = new System.Drawing.Size(127, 45);
            this.btnLeaveGroup.TabIndex = 1;
            this.btnLeaveGroup.Text = "Quitter le groupe";
            this.btnLeaveGroup.UseVisualStyleBackColor = false;
            // 
            // rtbReadOnly
            // 
            this.rtbReadOnly.Location = new System.Drawing.Point(349, 62);
            this.rtbReadOnly.Name = "rtbReadOnly";
            this.rtbReadOnly.ReadOnly = true;
            this.rtbReadOnly.Size = new System.Drawing.Size(319, 356);
            this.rtbReadOnly.TabIndex = 2;
            this.rtbReadOnly.Text = "";
            // 
            // btnexport
            // 
            this.btnexport.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnexport.Location = new System.Drawing.Point(15, 429);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 45);
            this.btnexport.TabIndex = 3;
            this.btnexport.Text = "Exporter";
            this.btnexport.UseVisualStyleBackColor = false;
            this.btnexport.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // FontButton
            // 
            this.FontButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FontButton.Location = new System.Drawing.Point(15, 14);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(143, 42);
            this.FontButton.TabIndex = 5;
            this.FontButton.Text = "Modifier la police...";
            this.FontButton.UseVisualStyleBackColor = false;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click_1);
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ColorButton.Location = new System.Drawing.Point(176, 14);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(144, 42);
            this.ColorButton.TabIndex = 6;
            this.ColorButton.Text = "Modifier la couleur...";
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click_1);
            // 
            // rating1
            // 
            this.rating1.BackColor = System.Drawing.Color.Transparent;
            this.rating1.Location = new System.Drawing.Point(467, 429);
            this.rating1.Name = "rating1";
            this.rating1.Size = new System.Drawing.Size(121, 34);
            this.rating1.TabIndex = 4;
            // 
            // groupNameTitle
            // 
            this.groupNameTitle.AutoSize = true;
            this.groupNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.groupNameTitle.Location = new System.Drawing.Point(506, 14);
            this.groupNameTitle.Name = "groupNameTitle";
            this.groupNameTitle.Size = new System.Drawing.Size(150, 31);
            this.groupNameTitle.TabIndex = 7;
            this.groupNameTitle.Text = "Groupe xxx";
            // 
            // NoteTaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.groupNameTitle);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.FontButton);
            this.Controls.Add(this.rating1);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.rtbReadOnly);
            this.Controls.Add(this.btnLeaveGroup);
            this.Controls.Add(this.rtbNoteTaking);
            this.Name = "NoteTaking";
            this.Size = new System.Drawing.Size(686, 492);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNoteTaking;
        private System.Windows.Forms.Button btnLeaveGroup;
        private System.Windows.Forms.RichTextBox rtbReadOnly;
        private System.Windows.Forms.Button btnexport;
        private Rating rating1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Button ColorButton;
        public System.Windows.Forms.Label groupNameTitle;
    }
}
