﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI2
{
    public partial class NoteEditor2 : UserControl
    {
        private Panel panel;
        internal string Keyword;
        internal string UserId;

        private string _watchUserNote;
        internal string WatchUserId;
        internal string WatchUserNote
        {
            get { return _watchUserNote; }
            set 
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new SetFriendNoteInvoker(_setFriendNote), value);
                }
                else
                {
                    _setFriendNote(value);
                }
                _watchUserNote = value;
            }
        }

        delegate void BuildUserListInvoker(Dictionary<string, CoreLibrary.User> users);
        delegate void SetFriendNoteInvoker(string text);

        private Dictionary<string, CoreLibrary.User> _users;
        internal Dictionary<string, CoreLibrary.User> Users 
        {
            set
            {
                _buildUserList(value.Where(i => i.Key != UserId)
                    .ToDictionary(i => i.Key, i => i.Value)
                   );

                _users = value;          
            }
            get { return _users; }
        }

        internal string Note { set { this.noteTextBox.Text = !string.IsNullOrEmpty(value) ? value : "Ma note"; } }

        private CoreLibrary.Group _group;
        internal CoreLibrary.Group Group
        {
            //when group is set
            //update users Dict for right menu
            //update textbox text by Note field
            set 
            {
                if( Users != value.Users)
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

                    using (StreamWriter writer = new StreamWriter("note.ns", false))
                    {
                        writer.WriteLine(textBox.Text);
                    }

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
                    WatchUserId = item.Id;
                    _watchUserNote = friendNoteTextBox.Text;
                };

            //Users = Group.Users;
            noteEditorList1.OnSearch += (s, e) =>
                {
                    var textBox = s as TextBox;

                    noteEditorList1.BuildList(
                    _users.Where(i => i.Key != UserId)
                    .ToDictionary(i => i.Key, i => i.Value)
                   , textBox.Text);
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
                    noteEditorList1.ResetActive();
                    ViewType(1);
                    this.ResumeLayout();
                };

            this.Load += (s, e) =>
                {
                    //var toolBox = new NoteEditorToolBox();
                    //this.likes.Location = new System.Drawing.Point(170, 21);
                    //noteTextBox.Controls.Add(
                };
        }

        public void Reset(DateTime date)
        {
            WatchUserNote = "";
            WatchUserId = "";
            Keyword = "";
            _buildUserList(null);
            _users = null;
            ViewType(1);
            
            
            using (StreamWriter writer = new StreamWriter("note.ns", false))
            {
                writer.WriteLine("");
            }

            System.IO.FileInfo file1 = new System.IO.FileInfo("note.ns");
            file1.LastWriteTime = date;

        }

        public void UpdateMe()
        {
            if (WatchUserId != null && _group.Notes.ContainsKey(WatchUserId)
                //&& group.Notes[WatchUserId].EditedAt > c.CurrentGroup.Notes[WatchUserId].EditedAt
                //&& group.Notes[WatchUserId].Text != c.CurrentGroup.Notes[WatchUserId].Text
            )
            {
                WatchUserNote = _group.Notes[WatchUserId].Text;
            }

            _buildUserList(_users.Where(i => i.Key != UserId)
                    .ToDictionary(i => i.Key, i => i.Value)
                   );
        }

        void _setFriendNote(string msg)
        {
            friendNoteTextBox.Text = msg;
        }

        void _buildUserList(Dictionary<string, CoreLibrary.User> users)
        {
            if( this.noteEditorList1.InvokeRequired)
            {
                this.Invoke(new BuildUserListInvoker(_buildUserList), users);
            }
            else
            {
                this.noteEditorList1.BuildList(users, Keyword);
            }
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
