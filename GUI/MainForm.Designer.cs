﻿namespace GUI
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        private void Register()
        {
            this.SuspendLayout();
            // 
            // RegisterForm1
            //
            this.RegisterForm1.Location = new System.Drawing.Point( 1, 1 );
            this.RegisterForm1.Name = "registerForm1";
            this.RegisterForm1.Size = new System.Drawing.Size( 272, 250 );
            this.RegisterForm1.TabIndex = 0;
            this.Controls.Add( this.RegisterForm1 );
            this.ResumeLayout( false );
        }

        #endregion
    }
}

