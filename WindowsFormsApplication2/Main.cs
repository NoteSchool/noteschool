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

        private bool LoggedIn = false;

        public Main()
        {
            if (File.Exists(_path))
            {
                LoggedIn = true;
                c = NSContext.Load(cs);
            }

            InitializeComponent();
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
            }
        }

        private void header1_Load(object sender, EventArgs e)
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

        }

        private void rightMenu1_Load(object sender, EventArgs e)
        {
            RightMenu menu = sender as RightMenu;

            menu.SuspendLayout();


            MenuItem users = menu.createItem("Utilisateurs");
            MenuItem about = menu.createItem("A Propos");

            if (!LoggedIn)
            {
                //Set first item
                menu.menuItem1.LabelText = "Identification";
                //menu.menuItem1.LabelIcon = "login";

                //add another item
                MenuItem groups = menu.createItem(label: "Groupes", disable: !LoggedIn, icon: "register");

                groups.IsDisabled = true;
                users.IsDisabled = true;
                about.IsDisabled = true;

                menu.Controls.Add(groups);
            }
            else
            {
                //Set first item
                menu.menuItem1.LabelText = "Groupes";
                menu.menuItem1.IsActive = true;
            }

            menu.ItemClick += (s, ev) =>
                {
                    var item = s as MenuItem;
            
                    switch (item.LabelText)
                    {
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
                GroupsPageControl.Location = new System.Drawing.Point(20, 40);
                GroupsPageControl.Name = "groupsPage1";
                GroupsPageControl.Size = new System.Drawing.Size(500, 259);
                GroupsPageControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                GroupsPageControl.TabIndex = 5;
                GroupsPageControl.AutoSize = true;
                GroupsPageControl.GroupButtonClick += (s, e) =>
                    {
                        Button btn = s as Button;

                        c.CurrentGroup = c.FindGroup(btn.Name);

                        Controls.Remove(GroupsPageControl);
                        GroupsPageControl.Dispose();

                        //open taking note
                    };

                GroupsPageControl.CreateGroupButtonClick += (s, e) =>
                    {
                        Button btn = s as Button;

                        Controls.Remove(GroupsPageControl);
                        GroupsPageControl.Dispose();

                        //open create group form
                        GroupCreatePage();
                    };
            }

            GroupsPageControl.CreateGroupButtons(c);

            content1.TitleText = "Choisissez votre classe de travail";
            content1.Controls.Add(GroupsPageControl);

        }

        private void GroupCreatePage()
        {
            if (CreateGroupPageControl == null)
            {
                CreateGroupPageControl = new GUI2.CreateGroupPage();
                CreateGroupPageControl.BackColor = System.Drawing.Color.White;
                CreateGroupPageControl.Location = new System.Drawing.Point(20, 40);
                CreateGroupPageControl.Name = "groupsPage1";
                CreateGroupPageControl.Size = new System.Drawing.Size(300, 259);
                CreateGroupPageControl.TabIndex = 5;
                CreateGroupPageControl.CancelButtonClick += (s, e) =>
                {
                    Button btn = s as Button;

                    Controls.Remove(CreateGroupPageControl);
                    CreateGroupPageControl.Dispose();

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
                        Controls.Remove(CreateGroupPageControl);
                        CreateGroupPageControl.Dispose();

                        GroupsPage();
                    }
                };

            }

            content1.TitleText = "Ajouter un nouveau groupe";
            content1.Controls.Add(CreateGroupPageControl);
        }


        private void RegisterPage()
        {
            //this.SuspendLayout();

            if (RegisterPageControl == null)
            {
                RegisterPageControl = new GUI2.RegisterPage();
                RegisterPageControl.BackColor = System.Drawing.Color.White;
                RegisterPageControl.Location = new System.Drawing.Point(20, 40);
                RegisterPageControl.Name = "groupsPage1";
                RegisterPageControl.Size = new System.Drawing.Size(344, 259);
                RegisterPageControl.TabIndex = 5;

                RegisterPageControl.SaveButtonClick += (s, e) =>
                    {
                        c = new NSContext();

                        c.Initialize(cs);

                        c.CurrentUser = c.CreateUser(RegisterPageControl.FirstName, RegisterPageControl.LastName);

                        c.Save();

                        this.content1.Controls.Remove(RegisterPageControl);
                        RegisterPageControl.Dispose();

                        GroupsPage();
                    };
            }

            content1.TitleText = "Identifiez-vous pour accéder au savoir !";
            content1.Controls.Add(RegisterPageControl);

            //this.ResumeLayout();
        }

        private void NoteEditorPage()
        {
            if (NoteEditorControl == null)
            {
                NoteEditorControl = new NoteEditor();

            }

            content1.TitleText = c.CurrentGroup.Name + ": Note";
            content1.Controls.Add(NoteEditorControl);
        }

        private void AboutPage()
        {
            if (AboutPageControl == null)
            {
                AboutPageControl = new GUI2.AboutPage();
                AboutPageControl.BackColor = System.Drawing.Color.White;
                AboutPageControl.Location = new System.Drawing.Point(20, 40);
                AboutPageControl.Name = "groupsPage1";
                AboutPageControl.Size = new System.Drawing.Size(344, 259);
                AboutPageControl.TabIndex = 5;
                AboutPageControl.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "+Environment.NewLine
                +"Mauris consequat quam vel ullamcorper varius. Phasellus vulputate quam in fermentum ultricies. "+Environment.NewLine
                +"Sed consectetur elementum quam at posuere. Nulla sem felis, lobortis vestibulum eros sit amet, dictum "+Environment.NewLine
                +"dictum ante. Nullam facilisis euismod ligula a egestas. Donec nec diam nulla. Pellentesque pulvinar ut arcu "+Environment.NewLine
                + "quis malesuada. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas." + Environment.NewLine 
                +"Sed venenatis euismod tortor. Pellentesque vel est ut sem tincidunt dictum vel auctor odio.";
            }

            content1.TitleText = "Qui somme nous ?";

            content1.Controls.Add(AboutPageControl);
        }

        private void UsersPage()
        {
            if (UsersPageControl == null)
            {
                UsersPageControl = new GUI2.UsersPage();
                UsersPageControl.BackColor = System.Drawing.Color.White;
                UsersPageControl.Location = new System.Drawing.Point(20, 40);
                UsersPageControl.Name = "groupsPage1";
                UsersPageControl.Size = new System.Drawing.Size(344, 259);
                UsersPageControl.TabIndex = 5;
            }

            content1.TitleText = "Retrouver vos amis";

            content1.Controls.Add(UsersPageControl);
        }

        private void ChangePage()
        {

        }

        private void RemovePage()
        {

            content1.Controls.RemoveAt(1);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?\r\nToutes les modifications effectuées seront enregistrées", "Fermeture", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            } 
        }
    }
}
