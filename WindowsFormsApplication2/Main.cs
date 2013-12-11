using CoreLibrary;
using LocalAreaNetwork;
using LocalStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI2
{
    public partial class Main : Form
    {
        private static string _path = @"data.ns";
        private static IRepository _repo = new BinaryFileRepository(_path);
        private static ILocalAreaNetwork _lan = new LAN();
        private NSContext c;
        private NSContextServices cs = new NSContextServices(_repo, _lan);

        private GroupsPage GroupsPageControl;
        private RegisterPage RegisterPageControl;
        private CreateGroupPage GroupCreatePageControl;
        private AboutPage AboutPageControl;
        private Panel NoteEditorControl;

        private bool LoggedIn = false;

        public Main()
        {
            if (File.Exists(_path))
            {
                LoggedIn = true;
                c = NSContext.Load(cs);
            }

            InitializeComponent();

            content1.RemoveNoteEditorPageFunc = delegate()
            {
                if (this.content1.Visible == false)
                {
                    this.header1.textItemLabel.Visible = false;
                    this.Controls.Remove(NoteEditorControl);
                    this.content1.Visible = true;
                }
            };
        }

        private void content1_Load(object sender, EventArgs e)
        {
            if (!LoggedIn) {  RegisterPage(); }
            else { GroupsPage(); }
        }

        private void header_Load(object sender, EventArgs e)
        {
            header header = sender as header;
            header.UsernameText = LoggedIn ? c.CurrentUser.FirstName : "Bienvenue";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //header_Load() by header1.Load not fire anymore!
            header_Load(this.header1, e);
        }

        private void rightMenu1_Load(object sender, EventArgs e)
        {
            leftMenu menu = sender as leftMenu;

            menuItem groups = menu.createItem(label:"Groupes", id:"groups");
            menuItem about = menu.createItem(label:"A Propos", id:"about");

            if (!LoggedIn)
            {
                menuItem register = menu.createItem(label:"Identification", id:"register");

                menu.SelectedItem = register;

                groups.IsDisabled = true;
                about.IsDisabled = true;

                menu.Controls.Add(register);
            }
            else
            {
                menu.SelectedItem = groups;
            }

            menu.ItemClick += (s, ev) =>
                {
                    var item = s as menuItem;

                    System.Diagnostics.Debug.WriteLine(item.Text + " menu clicked");

                    switch (item.Id)
                    {
                        case "noteEditor":
                            NoteEditor(c.CurrentGroup);
                            break;
                        case "about":                        
                            AboutPage();
                            break;
                        case "groups":
                            GroupsPage();
                            break;
                    }
                };

            menu.Controls.Add(groups);
            menu.Controls.Add(about);
        }

        private void GroupsPage()
        {
            if (GroupsPageControl == null)
            {
                GroupsPageControl = new GUI2.GroupsPage();
                GroupsPageControl.BackColor = System.Drawing.Color.White;
                GroupsPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                GroupsPageControl.Dock = DockStyle.Fill;               
                GroupsPageControl.GroupButtonClick += (s, e) =>
                    {
                        Button btn = s as Button;
                        c.CurrentGroup = c.FindGroup(btn.Name);
                        //open taking note
                        NoteEditor(c.CurrentGroup);
                    };
                GroupsPageControl.CreateGroupButtonClick += (s, e) =>
                    {
                        Button btn = s as Button;
                        //open create group form
                        GroupCreatePage();
                    };
                GroupsPageControl.SearchTextChange += (s, e) =>
                    {
                        var input = s as TextBox;
                        GroupsPageControl.CreateGroupButtons(c.Groups, input.Text);
                    };
            }

            GroupsPageControl.CreateGroupButtons(c.Groups);
         
            content1.Title = "Choisissez votre classe de travail";
            content1.NewPage(GroupsPageControl);

        }

        private void GroupCreatePage()
        {
            if (GroupCreatePageControl == null)
            {
                GroupCreatePageControl = new GUI2.CreateGroupPage();
                GroupCreatePageControl.BackColor = System.Drawing.Color.White;
                GroupCreatePageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                GroupCreatePageControl.Dock = DockStyle.Fill;
                GroupCreatePageControl.CancelButtonClick += (s, e) =>
                {
                    Button btn = s as Button;
                    //open page
                    GroupsPage();
                };
                GroupCreatePageControl.SaveButtonClick += (s, e) =>
                {
                    bool created;
                    c.CurrentGroup = c.FindOrCreateGroup(GroupCreatePageControl.GroupTitle, 
                        GroupCreatePageControl.GroupTag, c.SetMulticastAddress(), out created);

                    if (!created)
                        MessageBox.Show("Le nom du groupe existe déjà");
                    else
                    {
                        c.Save();
                        NoteEditor(c.CurrentGroup);
                    }
                };
            }

            content1.Title = "Ajouter un nouveau groupe";
            content1.NewPage(GroupCreatePageControl);
        }


        private void RegisterPage()
        {
            if (RegisterPageControl == null)
            {
                RegisterPageControl = new GUI2.RegisterPage();
                RegisterPageControl.BackColor = System.Drawing.Color.White;
                RegisterPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                RegisterPageControl.Dock = DockStyle.Fill;
                RegisterPageControl.SaveButtonClick += (s, e) =>
                    {
                        c = new NSContext();
                        c.Initialize(cs);
                        c.CurrentUser = c.CreateUser(RegisterPageControl.FirstName, RegisterPageControl.LastName);                     
                        c.Save();
                        GroupsPage();
                    };
            }

            content1.Title = "Identifiez-vous pour accéder au savoir !";
            content1.NewPage(RegisterPageControl);
        }

        private void NoteEditor(Group group = null)
        {
              this.content1.Visible = false;

              if (NoteEditorControl == null)
              {
                  NoteEditorControl = new System.Windows.Forms.Panel();
                  NoteEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
              | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right)));
                  NoteEditorControl.AutoSize = true;
                  //NoteEditorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
                  NoteEditorControl.Location = new System.Drawing.Point(164, 52);
                  NoteEditorControl.Name = "content1";
                  NoteEditorControl.Size = new System.Drawing.Size(631, 427);

                  NoteEditor2 _NoteEditorControl = new NoteEditor2();
                  /*_NoteEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
  | System.Windows.Forms.AnchorStyles.Left)
  | System.Windows.Forms.AnchorStyles.Right)));*/
                  _NoteEditorControl.Dock = DockStyle.Fill;
                  _NoteEditorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
                  _NoteEditorControl.Location = new System.Drawing.Point(0, 0);
                  //_NoteEditorControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                  _NoteEditorControl.Size = new System.Drawing.Size(631, 427);
                  //_NoteEditorControl.TabIndex = 4;

                  NoteEditorControl.Controls.Add(_NoteEditorControl);

                  var menuItem = this.rightMenu1.createItem(label: "Note Editor", pos: 0, id:"noteEditor");
                  rightMenu1.Controls.Add(menuItem);
                  this.rightMenu1.SelectedItem = menuItem;

              }
              else
              {
                  this.rightMenu1.SelectedItem = (menuItem) this.rightMenu1.Controls[2] ;
              }

            this.rightMenu1.SelectedItem.Text = group.Name;
            this.header1.textItemLabel.Text = group.Name+"   8 participants";
            this.header1.textItemLabel.Visible = true;

            this.Controls.Add(NoteEditorControl);
        }

        private void AboutPage()
        {
            if (AboutPageControl == null)
            {
                AboutPageControl = new GUI2.AboutPage();
                AboutPageControl.BackColor = System.Drawing.Color.White;
                AboutPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                AboutPageControl.Dock = DockStyle.Fill; 
                AboutPageControl.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "+Environment.NewLine
                +"Mauris consequat quam vel ullamcorper varius. Phasellus vulputate quam in fermentum ultricies. "+Environment.NewLine
                +"Sed consectetur elementum quam at posuere. Nulla sem felis, lobortis vestibulum eros sit amet, dictum "+Environment.NewLine
                +"dictum ante. Nullam facilisis euismod ligula a egestas. Donec nec diam nulla. Pellentesque pulvinar ut arcu "+Environment.NewLine
                + "quis malesuada. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas." + Environment.NewLine 
                +"Sed venenatis euismod tortor. Pellentesque vel est ut sem tincidunt dictum vel auctor odio.";
            }

            content1.Title = "Qui somme nous ?";
            content1.NewPage(AboutPageControl);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoggedIn)
            {
                if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?",
                  "Fermeture", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    c.Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
