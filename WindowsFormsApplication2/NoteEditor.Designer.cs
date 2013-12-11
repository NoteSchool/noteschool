namespace GUI2
{
    partial class NoteEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteEditor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.friendLayout = new System.Windows.Forms.TableLayoutPanel();
            this.friendNameLabel = new System.Windows.Forms.Label();
            this.friendTextBoxContainer = new System.Windows.Forms.Panel();
            this.friendTextBox = new System.Windows.Forms.TextBox();
            this.editorContainerPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listComponent2 = new GUI2.NoteEditorList();
            this.tableLayoutPanel1.SuspendLayout();
            this.friendLayout.SuspendLayout();
            this.friendTextBoxContainer.SuspendLayout();
            this.editorContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.friendLayout, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.editorContainerPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listComponent2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 488);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // friendLayout
            // 
            this.friendLayout.ColumnCount = 1;
            this.friendLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.friendLayout.Controls.Add(this.friendNameLabel, 0, 0);
            this.friendLayout.Controls.Add(this.friendTextBoxContainer, 0, 1);
            this.friendLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendLayout.Location = new System.Drawing.Point(316, 0);
            this.friendLayout.Margin = new System.Windows.Forms.Padding(0);
            this.friendLayout.Name = "friendLayout";
            this.friendLayout.RowCount = 2;
            this.friendLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.friendLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 322F));
            this.friendLayout.Size = new System.Drawing.Size(316, 488);
            this.friendLayout.TabIndex = 2;
            // 
            // friendNameLabel
            // 
            this.friendNameLabel.AutoSize = true;
            this.friendNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(196)))), ((int)(((byte)(165)))));
            this.friendNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendNameLabel.ForeColor = System.Drawing.Color.White;
            this.friendNameLabel.Location = new System.Drawing.Point(0, 0);
            this.friendNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.friendNameLabel.Name = "friendNameLabel";
            this.friendNameLabel.Padding = new System.Windows.Forms.Padding(5, 10, 0, 10);
            this.friendNameLabel.Size = new System.Drawing.Size(316, 45);
            this.friendNameLabel.TabIndex = 1;
            this.friendNameLabel.Text = "Paul André";
            // 
            // friendTextBoxContainer
            // 
            this.friendTextBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendTextBoxContainer.BackColor = System.Drawing.Color.White;
            this.friendTextBoxContainer.Controls.Add(this.friendTextBox);
            this.friendTextBoxContainer.Location = new System.Drawing.Point(0, 45);
            this.friendTextBoxContainer.Margin = new System.Windows.Forms.Padding(0);
            this.friendTextBoxContainer.Name = "friendTextBoxContainer";
            this.friendTextBoxContainer.Padding = new System.Windows.Forms.Padding(5);
            this.friendTextBoxContainer.Size = new System.Drawing.Size(316, 443);
            this.friendTextBoxContainer.TabIndex = 2;
            // 
            // friendTextBox
            // 
            this.friendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.friendTextBox.Location = new System.Drawing.Point(5, 5);
            this.friendTextBox.Multiline = true;
            this.friendTextBox.Name = "friendTextBox";
            this.friendTextBox.Size = new System.Drawing.Size(306, 433);
            this.friendTextBox.TabIndex = 0;
            this.friendTextBox.Text = resources.GetString("friendTextBox.Text");
            // 
            // editorContainerPanel
            // 
            this.editorContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorContainerPanel.AutoSize = true;
            this.editorContainerPanel.BackColor = System.Drawing.Color.White;
            this.editorContainerPanel.Controls.Add(this.textBox1);
            this.editorContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.editorContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.editorContainerPanel.Name = "editorContainerPanel";
            this.editorContainerPanel.Padding = new System.Windows.Forms.Padding(5);
            this.editorContainerPanel.Size = new System.Drawing.Size(316, 488);
            this.editorContainerPanel.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 478);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            this.textBox1.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
            // 
            // listComponent2
            // 
            this.listComponent2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listComponent2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.listComponent2.Location = new System.Drawing.Point(635, 3);
            this.listComponent2.Name = "listComponent2";
            this.listComponent2.Size = new System.Drawing.Size(172, 482);
            this.listComponent2.TabIndex = 5;
            // 
            // NoteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NoteEditor";
            this.Size = new System.Drawing.Size(810, 488);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.friendLayout.ResumeLayout(false);
            this.friendLayout.PerformLayout();
            this.friendTextBoxContainer.ResumeLayout(false);
            this.friendTextBoxContainer.PerformLayout();
            this.editorContainerPanel.ResumeLayout(false);
            this.editorContainerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label friendNameLabel;
        private System.Windows.Forms.TableLayoutPanel friendLayout;
        private System.Windows.Forms.Panel editorContainerPanel;
        private System.Windows.Forms.Panel friendTextBoxContainer;
        private System.Windows.Forms.TextBox friendTextBox;
        private NoteEditorList listComponent2;

    }
}
