namespace GUI2
{
    partial class RegisterPage
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
            this.button1 = new System.Windows.Forms.Button();
            this.inputNLabel2 = new GUI2.InputNLabel();
            this.inputNLabel1 = new GUI2.InputNLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(186)))), ((int)(((byte)(160)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(166, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputNLabel2
            // 
            this.inputNLabel2.Location = new System.Drawing.Point(18, 97);
            this.inputNLabel2.Name = "inputNLabel2";
            this.inputNLabel2.Size = new System.Drawing.Size(248, 56);
            this.inputNLabel2.TabIndex = 1;
            // 
            // inputNLabel1
            // 
            this.inputNLabel1.Location = new System.Drawing.Point(18, 15);
            this.inputNLabel1.Name = "inputNLabel1";
            this.inputNLabel1.Size = new System.Drawing.Size(248, 56);
            this.inputNLabel1.TabIndex = 0;
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputNLabel2);
            this.Controls.Add(this.inputNLabel1);
            this.Name = "RegisterPage";
            this.Size = new System.Drawing.Size(344, 401);
            this.Load += new System.EventHandler(this.RegisterPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InputNLabel inputNLabel1;
        private InputNLabel inputNLabel2;
        private System.Windows.Forms.Button button1;

    }
}
