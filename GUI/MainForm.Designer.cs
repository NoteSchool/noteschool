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
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        private void NoteTakingControl()
        {
            this.SuspendLayout();
            // 
            // NoteTaking main page
            //
            this._noteTakingForm.Location = new System.Drawing.Point( 0, 0 );
            this._noteTakingForm.Name = "notetakingMainPage1";
            this._noteTakingForm.Size = new System.Drawing.Size( 705, 524 );
            this._noteTakingForm.TabIndex = 0;
            this.Controls.Add( this._noteTakingForm );
            this.ResumeLayout( false );
        }
        private void CreateGroupsControl()
        {
            this.SuspendLayout();
            // 
            // CreateGroups
            //
            this._createGroupsForm.Location = new System.Drawing.Point( 109, 60 );
            this._createGroupsForm.Name = "createGroups1";
            this._createGroupsForm.Size = new System.Drawing.Size( 510, 389 );
            this._createGroupsForm.TabIndex = 0;
            this.Controls.Add( this._createGroupsForm );
            this.ResumeLayout( false );
        }
        private void RegisterControl()
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
        private void DisplayGroupsControl()
        {
            this.SuspendLayout();
            // 
            // groups
            //
            this._displayGroupsForm.Location = new System.Drawing.Point( 79, 38 );
            this._displayGroupsForm.Name = "displayAndCreateGroups2";
            this._displayGroupsForm.Size = new System.Drawing.Size( 573, 432 );
            this._displayGroupsForm.TabIndex = 1;
            this.Controls.Add( this._displayGroupsForm );
            this.ResumeLayout( false );
        }

        #endregion
    }
}

