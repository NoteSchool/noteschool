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
        private CreateGroupPage CreateGroupPageControl;
        private AboutPage AboutPageControl;
        private UsersPage UsersPageControl;
        private NoteEditor NoteEditorControl;

        private Control _currentPage;

        private bool LoggedIn = false;

        public Main()
        {
            if (File.Exists(_path))
            {
                LoggedIn = true;
                c = NSContext.Load(cs);
            }

            InitializeComponent();

            //how to change the page size
            //when a control added
            this.content1.ControlAddedEvent += (s, e) =>
                {
                    /**var cont = content1.panel1.Controls[0];
                    //MessageBox.Show(cont.Name);
                    if ((string)cont.Tag == "page")
                    {
                        _currentPage = cont;
                        System.Diagnostics.Debug.WriteLine(cont.Name + " page lunched");
                    }*/
                };
        }

        private void content1_Load(object sender, EventArgs e)
        {
            Content content = sender as Content;

            if (!LoggedIn)
            {
                RegisterPage();
            }
            else
            {          
               GroupsPage();
                //NoteEditor();
            }
        }

        private void header_Load(object sender, EventArgs e)
        {
            Header header = sender as Header;
         
            if (LoggedIn)
            {
                header.UsernameText = c.CurrentUser.FirstName;
            }
            else
            {
                header.UsernameText = "Bienvenue";
            }

            header.SearchInput.Visible = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //header_Load() by header1.Load not fire anymore!
            header_Load(this.header1, e);
        }

        private void rightMenu1_Load(object sender, EventArgs e)
        {
            RightMenu menu = sender as RightMenu;

            menu.SuspendLayout();

            //add another item
            MenuItem groups = menu.createItem("Groupes");
            MenuItem users = menu.createItem("Utilisateurs");
            MenuItem about = menu.createItem("A Propos");

            if (!LoggedIn)
            {
                //Set first item
                menu.menuItem1.LabelText = "Identification";
                //menu.menuItem1.LabelIcon = "login";

                groups.IsDisabled = true;
                users.IsDisabled = true;
                about.IsDisabled = true;

                
            }
            else
            {
                //Set first item
                menu.menuItem1.LabelText = "Note Editor";
                menu.menuItem1.IsActive = true;
            }

            menu.ItemClick += (s, ev) =>
                {
                    var item = s as MenuItem;

                    System.Diagnostics.Debug.WriteLine(item.LabelText + " menu clicked");

                    switch (item.LabelText)
                    {
                        case "Note Editor":
                            RemovePage();
                            NoteEditor();
                            break;
                        case "A Propos":                        
                            RemovePage();
                            AboutPage();
                            break;
                        case "Groupes":
                            RemovePage();
                            GroupsPage();
                            break;
                        case "Utilisateurs":
                            RemovePage();
                            UsersPage();
                            break;
                    }
                };

            menu.Controls.Add(groups);
            menu.Controls.Add(users);
            menu.Controls.Add(about);
            menu.ResumeLayout();
        }

        private void GroupsPage()
        {
            if (GroupsPageControl == null)
            {
                GroupsPageControl = new GUI2.GroupsPage();
                GroupsPageControl.BackColor = System.Drawing.Color.White;
                GroupsPageControl.Location = new System.Drawing.Point(0, 50);
                GroupsPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                GroupsPageControl.Size = new System.Drawing.Size(this.content1.Size.Width, 427);
                GroupsPageControl.Dock = DockStyle.Fill;
                
                GroupsPageControl.GroupButtonClick += (s, e) =>
                    {
                        Button btn = s as Button;

                        c.CurrentGroup = c.FindGroup(btn.Name);

                        RemovePage();

                        //open taking note
                    };

                GroupsPageControl.CreateGroupButtonClick += (s, e) =>
                    {
                        Button btn = s as Button;

                        RemovePage();

                        //open create group form
                        GroupCreatePage();
                    };

                GroupsPageControl.SearchTextChange += (s, e) =>
                    {
                        var input = s as TextBox;

                        GroupsPageControl.CreateGroupButtons(c, input.Text);
                    };
            }

            GroupsPageControl.CreateGroupButtons(c);

            content1.TitleText = "Choisissez votre classe de travail";
            this.content1.panel1.Controls.Add(GroupsPageControl);

        }

        private void GroupCreatePage()
        {
            if (CreateGroupPageControl == null)
            {
                CreateGroupPageControl = new GUI2.CreateGroupPage();
                CreateGroupPageControl.BackColor = System.Drawing.Color.White;
                CreateGroupPageControl.Location = new System.Drawing.Point(0, 50);
                CreateGroupPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                CreateGroupPageControl.Size = new System.Drawing.Size(this.content1.Size.Width, 427);
                CreateGroupPageControl.Dock = DockStyle.Fill;
                CreateGroupPageControl.TabIndex = 5;
                CreateGroupPageControl.CancelButtonClick += (s, e) =>
                {
                    Button btn = s as Button;
                    RemovePage();
                    //open page
                    GroupsPage();
                };

                CreateGroupPageControl.SaveButtonClick += (s, e) =>
                {
                    //Button btn = s as Button;

                    bool created;

                    c.CurrentGroup = c.FindOrCreateGroup(CreateGroupPageControl.GroupTitle, CreateGroupPageControl.GroupTag, 
                        c.SetMulticastAddress(), out created);

                    if (!created)
                        MessageBox.Show("Le nom du groupe existe déjà");
                    else
                    {
                        c.Save();
                        RemovePage();
                        GroupsPage();
                    }
                };

            }

            content1.TitleText = "Ajouter un nouveau groupe";
            content1.panel1.Controls.Add(CreateGroupPageControl);
        }


        private void RegisterPage()
        {
            if (RegisterPageControl == null)
            {
                RegisterPageControl = new GUI2.RegisterPage();
                RegisterPageControl.BackColor = System.Drawing.Color.White;
                RegisterPageControl.Location = new System.Drawing.Point(0, 50);
                RegisterPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                RegisterPageControl.Size = new System.Drawing.Size(this.content1.Size.Width, 427);
                RegisterPageControl.Dock = DockStyle.Fill;
                RegisterPageControl.TabIndex = 5;

                RegisterPageControl.SaveButtonClick += (s, e) =>
                    {
                        c = new NSContext();
                        c.Initialize(cs);
                        c.CurrentUser = c.CreateUser(RegisterPageControl.FirstName, RegisterPageControl.LastName);                     
                        c.Save();
                        RemovePage();
                        GroupsPage();
                    };
            }

            content1.TitleText = "Identifiez-vous pour accéder au savoir !";
            content1.panel1.Controls.Add(RegisterPageControl);
        }

        private void NoteEditor()
        {
            this.content1.Visible = false;

            if (NoteEditorControl == null)
            {
                NoteEditorControl = new NoteEditor();
                NoteEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
                NoteEditorControl.AutoSize = false;
                NoteEditorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
                NoteEditorControl.Location = new System.Drawing.Point(164, 52);
                NoteEditorControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                NoteEditorControl.Size = new System.Drawing.Size(631, 427);
                NoteEditorControl.TabIndex = 4;
            }

            this.Controls.Add(NoteEditorControl);
        }

        private void AboutPage()
        {
            if (AboutPageControl == null)
            {
                AboutPageControl = new GUI2.AboutPage();
                AboutPageControl.BackColor = System.Drawing.Color.White;
                AboutPageControl.Location = new System.Drawing.Point(0, 50);
                AboutPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                AboutPageControl.Size = new System.Drawing.Size(this.content1.Size.Width, 427);
                AboutPageControl.Dock = DockStyle.Fill;
  
                AboutPageControl.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "+Environment.NewLine
                +"Mauris consequat quam vel ullamcorper varius. Phasellus vulputate quam in fermentum ultricies. "+Environment.NewLine
                +"Sed consectetur elementum quam at posuere. Nulla sem felis, lobortis vestibulum eros sit amet, dictum "+Environment.NewLine
                +"dictum ante. Nullam facilisis euismod ligula a egestas. Donec nec diam nulla. Pellentesque pulvinar ut arcu "+Environment.NewLine
                + "quis malesuada. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas." + Environment.NewLine 
                +"Sed venenatis euismod tortor. Pellentesque vel est ut sem tincidunt dictum vel auctor odio.";
            }

            content1.TitleText = "Qui somme nous ?";

            content1.panel1.Controls.Add(AboutPageControl);
        }

        private void UsersPage()
        {
            if (UsersPageControl == null)
            {
                UsersPageControl = new GUI2.UsersPage();
                UsersPageControl.BackColor = System.Drawing.Color.White;
                UsersPageControl.Location = new System.Drawing.Point(0, 50);
                UsersPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                UsersPageControl.Size = new System.Drawing.Size(this.content1.Size.Width, 427);
                UsersPageControl.Dock = DockStyle.Fill;
            }

            content1.TitleText = "Retrouver vos amis";

            content1.panel1.Controls.Add(UsersPageControl);
        }

        private void ChangePage()
        {

        }

        private void RemovePage()
        {
            if (this.content1.Visible == false)
            {
                this.Controls.Remove(NoteEditorControl);
                this.content1.Visible = true;
            }
            else
            {
                content1.panel1.Controls.Clear();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?\r\nToutes les modifications effectuées seront enregistrées", "Fermeture", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (File.Exists(_path))
                {
                    c.Save();
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            } */
        }
    }
}
