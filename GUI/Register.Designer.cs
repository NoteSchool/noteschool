﻿namespace GUI
{
    partial class Register
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
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.labFirstname = new System.Windows.Forms.Label();
            this.labLastname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(22, 52);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 20);
            this.tbFirstName.TabIndex = 0;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(22, 133);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(100, 20);
            this.tbLastName.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(35, 192);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 25);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "S\'enregistrer";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // labFirstname
            // 
            this.labFirstname.AutoSize = true;
            this.labFirstname.Location = new System.Drawing.Point(19, 20);
            this.labFirstname.Name = "labFirstname";
            this.labFirstname.Size = new System.Drawing.Size(106, 13);
            this.labFirstname.TabIndex = 3;
            this.labFirstname.Text = "Entrer votre prénom :";
            // 
            // labLastname
            // 
            this.labLastname.AutoSize = true;
            this.labLastname.Location = new System.Drawing.Point(19, 100);
            this.labLastname.Name = "labLastname";
            this.labLastname.Size = new System.Drawing.Size(91, 13);
            this.labLastname.TabIndex = 4;
            this.labLastname.Text = "Entrer votre nom :";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labLastname);
            this.Controls.Add(this.labFirstname);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Location = new System.Drawing.Point(300, 450);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(145, 232);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label labFirstname;
        private System.Windows.Forms.Label labLastname;
    }
}