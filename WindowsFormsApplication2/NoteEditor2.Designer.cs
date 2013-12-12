namespace GUI2
{
    partial class NoteEditor2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteEditor2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.friendNoteContainerPanel = new System.Windows.Forms.Panel();
            this.friendNoteTextBox = new System.Windows.Forms.TextBox();
            this.friendContainerPanel = new System.Windows.Forms.Panel();
            this.friendUsernameLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.noteEditorList1 = new GUI2.NoteEditorList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.friendNoteContainerPanel.SuspendLayout();
            this.friendContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.noteTextBox);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.friendNoteContainerPanel);
            this.splitContainer1.Panel2.Controls.Add(this.friendContainerPanel);
            this.splitContainer1.Size = new System.Drawing.Size(548, 450);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 1;
            // 
            // noteTextBox
            // 
            this.noteTextBox.AcceptsReturn = true;
            this.noteTextBox.AcceptsTab = true;
            this.noteTextBox.AllowDrop = true;
            this.noteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.noteTextBox.Location = new System.Drawing.Point(5, 5);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.noteTextBox.Size = new System.Drawing.Size(183, 440);
            this.noteTextBox.TabIndex = 0;
            this.noteTextBox.Text = "Ma note";
            // 
            // friendNoteContainerPanel
            // 
            this.friendNoteContainerPanel.Controls.Add(this.friendNoteTextBox);
            this.friendNoteContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendNoteContainerPanel.Location = new System.Drawing.Point(0, 37);
            this.friendNoteContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.friendNoteContainerPanel.Name = "friendNoteContainerPanel";
            this.friendNoteContainerPanel.Padding = new System.Windows.Forms.Padding(3);
            this.friendNoteContainerPanel.Size = new System.Drawing.Size(351, 413);
            this.friendNoteContainerPanel.TabIndex = 1;
            // 
            // friendNoteTextBox
            // 
            this.friendNoteTextBox.AcceptsReturn = true;
            this.friendNoteTextBox.AcceptsTab = true;
            this.friendNoteTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.friendNoteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendNoteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendNoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendNoteTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.friendNoteTextBox.Location = new System.Drawing.Point(3, 3);
            this.friendNoteTextBox.Multiline = true;
            this.friendNoteTextBox.Name = "friendNoteTextBox";
            this.friendNoteTextBox.ReadOnly = true;
            this.friendNoteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.friendNoteTextBox.Size = new System.Drawing.Size(345, 407);
            this.friendNoteTextBox.TabIndex = 0;
            this.friendNoteTextBox.Text = resources.GetString("friendNoteTextBox.Text");
            // 
            // friendContainerPanel
            // 
            this.friendContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(196)))), ((int)(((byte)(165)))));
            this.friendContainerPanel.Controls.Add(this.linkLabel1);
            this.friendContainerPanel.Controls.Add(this.friendUsernameLabel);
            this.friendContainerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.friendContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.friendContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.friendContainerPanel.Name = "friendContainerPanel";
            this.friendContainerPanel.Padding = new System.Windows.Forms.Padding(3);
            this.friendContainerPanel.Size = new System.Drawing.Size(351, 37);
            this.friendContainerPanel.TabIndex = 0;
            // 
            // friendUsernameLabel
            // 
            this.friendUsernameLabel.AutoSize = true;
            this.friendUsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendUsernameLabel.ForeColor = System.Drawing.Color.White;
            this.friendUsernameLabel.Location = new System.Drawing.Point(3, 3);
            this.friendUsernameLabel.Name = "friendUsernameLabel";
            this.friendUsernameLabel.Size = new System.Drawing.Size(114, 24);
            this.friendUsernameLabel.TabIndex = 0;
            this.friendUsernameLabel.Text = "André Paul";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(293, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(39, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Fermer";
            // 
            // noteEditorList1
            // 
            this.noteEditorList1.AutoScroll = true;
            this.noteEditorList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.noteEditorList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.noteEditorList1.Location = new System.Drawing.Point(548, 0);
            this.noteEditorList1.Name = "noteEditorList1";
            this.noteEditorList1.Size = new System.Drawing.Size(195, 450);
            this.noteEditorList1.TabIndex = 0;
            // 
            // NoteEditor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.noteEditorList1);
            this.Name = "NoteEditor2";
            this.Size = new System.Drawing.Size(743, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.friendNoteContainerPanel.ResumeLayout(false);
            this.friendNoteContainerPanel.PerformLayout();
            this.friendContainerPanel.ResumeLayout(false);
            this.friendContainerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NoteEditorList noteEditorList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Panel friendContainerPanel;
        private System.Windows.Forms.Label friendUsernameLabel;
        private System.Windows.Forms.Panel friendNoteContainerPanel;
        private System.Windows.Forms.TextBox friendNoteTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
