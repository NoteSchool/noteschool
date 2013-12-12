using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI2
{
    public partial class NoteEditor2 : UserControl
    {
        private Panel panel;
        internal string Keyword;
        internal string UserId;

        private Dictionary<string, CoreLibrary.User> _users;
        internal Dictionary<string, CoreLibrary.User> Users 
        {
            set
            {
                _users = value;
                this.noteEditorList1.BuildList(value, Keyword);
            }
        }

        internal string Note { set { this.noteTextBox.Text = value; } }

        private CoreLibrary.Group _group;
        internal CoreLibrary.Group Group
        {
            //when group is set
            //update users Dict for right menu
            //update textbox text by Note field
            set 
            { 
                Users = value.Users; 
                _group = value;
                Note = value.Notes[UserId].Text;
            }
            get { return _group; }
        }

        public NoteEditor2()
        {
            InitializeComponent();

            //when text change, update the field in the Group
            noteTextBox.TextChanged += (s, e) =>
                {
                    TextBox textBox = s as TextBox;

                    Group.Notes[UserId].Text = textBox.Text;
                    Group.Notes[UserId].EditedAt = DateTime.Now;
                };

            noteEditorList1.OnItemClick += (s, e) =>
                {
                    var item = s as NoteEditorListItem;

                    var user = Group.Users[item.Id];
                    ViewType(2);
                    friendUsernameLabel.Text = user.FirstName + " " + user.LastName;
                    friendNoteTextBox.Text = Group.Notes[user.Id].Text;
                };

            //Users = Group.Users;
            noteEditorList1.OnSearch += (s, e) =>
                {
                    var textBox = s as TextBox;
                    Keyword = textBox.Text;

                    DoSearch();
                };

            noteTextBox.GotFocus += (s, e) =>
            {
                if (noteTextBox.Text == "Ma note")
                    noteTextBox.Text = "";
            };
            noteTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(noteTextBox.Text))
                    noteTextBox.Text = "Ma note";
            };

            linkLabel1.Click += (s, e) =>
                {
                    this.SuspendLayout();
                    ViewType(1);
                    this.ResumeLayout();
                };
        }

        internal void DoSearch()
        {
            noteEditorList1.BuildList(
                _users.Where(i => i.Key != UserId)
                .ToDictionary(i => i.Key, i => i.Value)
               , Keyword);
            
        }

        internal void ViewType(int type = 1)
        {
            if (type == 1)
            {
                if (panel == null)
                {
                    panel = new Panel();
                    panel.Dock = System.Windows.Forms.DockStyle.Left;
                    panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                        System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right
                        | System.Windows.Forms.AnchorStyles.Bottom))));
                    panel.Location = new System.Drawing.Point(0, 0);
                    panel.Margin = new System.Windows.Forms.Padding(0);
                    panel.Padding = new System.Windows.Forms.Padding(5);
                    panel.BackColor = System.Drawing.Color.White;
                    panel.Size = new System.Drawing.Size(438, 428);
                    
                    Controls.Add(panel);
                }

                if (panel.Controls.Count == 0)
                {
                    panel.Controls.Add(noteTextBox);
                }

                panel.Visible = true;
                splitContainer1.Visible = false;
            }
            else
            {
                if (splitContainer1.Panel1.Controls.Count == 0)
                {
                    splitContainer1.Panel1.Controls.Add(noteTextBox);
                }
                //MessageBox.Show(splitContainer1.Panel1.Controls.Count.ToString());
                panel.Visible = false;
                splitContainer1.Visible = true;
            }
        }
    }
}
