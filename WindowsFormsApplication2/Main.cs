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

        private bool LoggedIn = false;

        public Main()
        {
            if (File.Exists(_path))
            {
                LoggedIn = true;
            }

            InitializeComponent();
        }

        private void content1_Load(object sender, EventArgs e)
        {
            Content content = sender as Content;

            content.TitleText = "Identifiez-vous pour accéder au savoir !";

            if (!LoggedIn)
            {
                RegisterPage();
            }
            else
            {
                c = NSContext.Load(cs);

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

            //Set first item
            menu.menuItem1.LabelText = "Identification";
            //menu.menuItem1.LabelIcon = "login";

            //add another item
            MenuItem groups = menu.createItem(label: "Groupes", disable: !LoggedIn, icon: "register");
            MenuItem users = menu.createItem("Utilisateurs");
            MenuItem about = menu.createItem("A Propos");

            if (!LoggedIn)
            {
                groups.IsDisabled = true;
                users.IsDisabled = true;
                about.IsDisabled = true;
            }

            menu.Controls.Add(groups);
            menu.Controls.Add(users);
            menu.Controls.Add(about);

            menu.ResumeLayout();
        }

        private void GroupsPage(bool show = true)
        {
            this.SuspendLayout();

            if (GroupsPageControl == null)
            {
                GroupsPageControl = new GUI2.GroupsPage();
                GroupsPageControl.BackColor = System.Drawing.Color.White;
                GroupsPageControl.Location = new System.Drawing.Point(183, 92);
                GroupsPageControl.Name = "groupsPage1";
                GroupsPageControl.Size = new System.Drawing.Size(544, 359);
                GroupsPageControl.TabIndex = 5;
            }

            content1.TitleText = "Choisissez votre classe de travail";
            this.Controls.Add(GroupsPageControl);

            this.ResumeLayout(false);
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
                
                /*RegisterPageControl.ButtonClick += (s, e) =>
                {
                    MessageBox.Show("test");
                };*/

                RegisterPageControl.SaveButtonClick += (s, e) =>
                {
                    MessageBox.Show("test");
                };
            }

            content1.TitleText = "Identifiez-vous pour accéder au savoir !";
            content1.Controls.Add(RegisterPageControl);

            //this.ResumeLayout();
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
