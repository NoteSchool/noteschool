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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private HelpPage HelpPageControl;
        private Panel NoteEditorControl;
        private NoteEditor2 NoteEditorControl2;

        private bool LoggedIn = false;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Main()
        {      
            AllocConsole();
            if (File.Exists(_path))
            {
                LoggedIn = true;
                c = NSContext.Load(cs);
                c.Receiver();
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

            SendTimer();
            ReceiveTimer();
        }
        public void SendTimer()
        {
            System.Timers.Timer _syncTimer = new System.Timers.Timer();
            _syncTimer.Elapsed += SendSyncTimer;
            _syncTimer.Interval = 3000;
            _syncTimer.Enabled = true;
            _syncTimer.Start();
        }
        public void ReceiveTimer()
        {
            System.Timers.Timer _syncTimer = new System.Timers.Timer();
            _syncTimer.Elapsed += ReceiveSyncTimer;
            _syncTimer.Interval = 1000;
            _syncTimer.Enabled = true;
            _syncTimer.Start();
        }

        private void ReceiveSyncTimer( object sender, ElapsedEventArgs e )
        {
            //Helper.dd( "Receive Timer firing -------------------------------------------" );
            if (c == null) return;


            /* +----------------------------------------+
             * |    NOTES                               |
             * |    List of the current group notes     |
             * |                                        |
             * +----------------------------------------+ */
            Object notesReceived = c.GroupData();

            if (notesReceived != null)
            {
                Helper.dd( "Full Group received" );

                CoreLibrary.GroupFullPacket group = (CoreLibrary.GroupFullPacket)notesReceived;
                    
                    bool updated = false;
                    CoreLibrary.Group Group = c.CreateGroupFromPacket( group, out updated );

                    Helper.dd( group.Name );


                    Helper.dd( Group.Notes.Count.ToString() );
                    //notes count has changed
                    if (updated)
                    {
                        //NoteEditorControl2.Group = c.CurrentGroup;
                        NoteEditorControl2.UpdateMe();
                    }

                    /*if (group.Users.Count > NoteEditorControl2.Users.Count)
                        NoteEditorControl2.Users = Group.Users;*/

                    //c.CurrentGroup = Group;
            }
            /* +----------------------------------------+
             * |    GROUP                               |
             * |    group just created in the current   |
             * |    network                             |
             * +----------------------------------------+ */

            Object receiveData = c.ReceivedData();

            if (receiveData != null)
            {
                Helper.dd( "Light Group received" );

                CoreLibrary.GroupLightPacket group = (CoreLibrary.GroupLightPacket)receiveData;

                    Helper.dd( group.Name );

                    if (!c.Groups.ContainsKey( group.MulticastAddress ))
                    {
                        c.CreateGroupFromPacket( group );
                        GroupsPageControl.CreateGroupButtons( c.Groups );

                        Helper.dd( "Group added" );
                    }
            }

            /*if (notesReceived == null && receiveData == null)
                Helper.dd( "No data received" );*/
        }
        
        private void SendSyncTimer(object sender, ElapsedEventArgs e)
        {
            //Helper.dd("Send Timer firing -------------------------------------------");
            if (c == null) return;

            //send current group to others
            c.Sender();
        }
        
        private void content1_Load(object sender, EventArgs e)
        {
            if (!LoggedIn) { RegisterPage(); }
            else { GroupsPage(); }
        }

        private void header_Load(object sender, EventArgs e)
        {
            header header = sender as header;
            header.UsernameText = LoggedIn ? "Bienvenue " + c.CurrentUser.FirstName : "Bienvenue";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //header_Load() by header1.Load not fire anymore!
            header_Load(this.header1, e);
        }

        private void rightMenu1_Load(object sender, EventArgs e)
        {
            leftMenu menu = sender as leftMenu;

            menuItem groups = menu.createItem(label: "Accueil", id: "groups");
            menuItem about = menu.createItem(label: "Aide", id: "help");

            if (!LoggedIn)
            {
                menuItem register = menu.createItem(label: "Identification", id: "register", pos: 0);

                menu.SelectedItem = register;

                groups.IsDisabled = true;

                menu.Controls.Add(register);
            }
            else
            {
                menu.SelectedItem = groups;
            }

            menu.ItemClick += (s, ev) =>
                {
                    var item = s as menuItem;


                    this.Text = item.Text;

                    switch (item.Id)
                    {
                        case "noteEditor":
                            NoteEditor(c.CurrentGroup);
                            break;
                        case "help":
                            HelpPage();
                            break;
                        case "groups":
                            GroupsPage();
                            break;
                        case "register":
                            RegisterPage();
                            break;
                    }
                };
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
                        //open taking note
                        NoteEditor(c.FindGroup(btn.Name));
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

            content1.Title = "Choisissez votre groupe de travail";
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

            GroupCreatePageControl.GroupTitle = "";
            GroupCreatePageControl.GroupTag = "";

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
                        List<string> results;
                        if (RegisterPageControl.Validation(out results))
                        {
                            c = new NSContext();
                            c.Initialize(cs);
                            c.CurrentUser = c.CreateUser(results[0], results[1]);
                            c.Save();

                            header1.UsernameText = "Bienvenue " + c.CurrentUser.FirstName;
                            leftMenu1.RemoveItem(leftMenu1.SelectedItem);
                            leftMenu1.SelectedItem = leftMenu1.Controls[0] as menuItem;
                            leftMenu1.SelectedItem.IsDisabled = false;

                            GroupsPage();
                            c.Receiver();
                        }
                        else
                        {
                            MessageBox.Show("Tous les champs doivent être remplis avec des caractères normaux");
                        }
                    };
            }

            content1.Title = "Rejoignez nous pour accéder au savoir !";
            content1.NewPage(RegisterPageControl);
        }

        private void NoteEditor(Group group)
        {
            this.content1.Visible = false;
            this.SuspendLayout();

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

                this.NoteEditorControl2 = new NoteEditor2();
                /*_NoteEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));*/
                this.NoteEditorControl2.Dock = DockStyle.Fill;
                this.NoteEditorControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
                this.NoteEditorControl2.Location = new System.Drawing.Point(0, 0);
                //_NoteEditorControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.NoteEditorControl2.Size = new System.Drawing.Size(631, 427);
                //_NoteEditorControl.TabIndex = 4;
                NoteEditorControl2.UserId = c.CurrentUser.Id;

                //add some friends

                NoteEditorControl.Controls.Add(NoteEditorControl2);

                var menuItem = this.leftMenu1.createItem(label: "Note Editor", pos: 1, id: "noteEditor");
                this.leftMenu1.SelectedItem = menuItem;

                //No friend note is show
                NoteEditorControl2.ViewType(1);
            }
            else
            {
                this.leftMenu1.SelectedItem = (menuItem)this.leftMenu1.Controls[2];
            }

            //MessageBox.Show(group.Notes.Count.ToString());
            /*if( group.Notes.Count == 1)
              DummyUsers(group);*/

            //group.ReInialize(c);
            group.CreateNote();
            c.CurrentGroup = group;


            //textbox will be setted
            //group.Users[c.CurrentUser.Id] = c.CurrentUser;
            this.NoteEditorControl2.Reset(group.Notes[c.CurrentUser.Id].EditedAt);
            this.NoteEditorControl2.Group = group;


            this.leftMenu1.SelectedItem.Text = group.Name;
            this.header1.textItemLabel.Text = " " + group.Name + " - " + string.Format("{0:m}", group.createdAt) + " - " + (group.Users.Count) + " participant(s)";
            this.header1.textItemLabel.Visible = true;

            this.Controls.Add(NoteEditorControl);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void HelpPage()
        {
            if (HelpPageControl == null)
            {
                HelpPageControl = new GUI2.HelpPage();
                HelpPageControl.BackColor = System.Drawing.Color.White;
                HelpPageControl.Name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                HelpPageControl.Dock = DockStyle.Fill;
                HelpPageControl.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " + Environment.NewLine
                + "Mauris consequat quam vel ullamcorper varius. Phasellus vulputate quam in fermentum ultricies. " + Environment.NewLine
                + "Sed consectetur elementum quam at posuere. Nulla sem felis, lobortis vestibulum eros sit amet, dictum " + Environment.NewLine
                + "dictum ante. Nullam facilisis euismod ligula a egestas. Donec nec diam nulla. Pellentesque pulvinar ut arcu " + Environment.NewLine
                + "quis malesuada. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas." + Environment.NewLine
                + "Sed venenatis euismod tortor. Pellentesque vel est ut sem tincidunt dictum vel auctor odio.";
            }

            content1.Title = "Tous va bien, on se calme ;)";
            content1.NewPage(HelpPageControl);
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
