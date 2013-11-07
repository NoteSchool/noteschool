namespace GUI
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
            this.ClientSize = new System.Drawing.Size(713, 535);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        private void NoteTaking()
        {
            this.SuspendLayout();
            // 
            // NoteTaking main page
            //
            this._notetakingMainPage.Location = new System.Drawing.Point(0, 0);
            this._notetakingMainPage.Name = "notetakingMainPage1";
            this._notetakingMainPage.Size = new System.Drawing.Size(705, 524);
            this._notetakingMainPage.TabIndex = 0;
            this.Controls.Add(this._notetakingMainPage);
            this.ResumeLayout(false);
        }
        private void CreateGroups()
        {
            this.SuspendLayout();
            // 
            // CreateGroups
            //
            this._createGroups.Location = new System.Drawing.Point(109, 60);
            this._createGroups.Name = "createGroups1";
            this._createGroups.Size = new System.Drawing.Size(510, 389);
            this._createGroups.TabIndex = 0;
            this.Controls.Add(this._createGroups);
            this.ResumeLayout(false);
        }
        private void Register()
        {
            this.SuspendLayout();
            // 
            // RegisterForm1
            //
            this._registerForm.Location = new System.Drawing.Point( 1, 1 );
            this._registerForm.Name = "registerForm1";
            this._registerForm.Size = new System.Drawing.Size( 272, 250 );
            this._registerForm.TabIndex = 0;
            this.Controls.Add( this._registerForm );
            this.ResumeLayout( false );
        }
        private void groups()
        {
            this.SuspendLayout();
            // 
            // groups
            //
            this._displayGroups.Location = new System.Drawing.Point(79, 38);
            this._displayGroups.Name = "displayAndCreateGroups2";
            this._displayGroups.Size = new System.Drawing.Size(573, 432);
            this._displayGroups.TabIndex = 1;
            this.Controls.Add(this._displayGroups);
            this.ResumeLayout(false);
        }

        #endregion
    }
}

