using CoreLibrary;
using LocalAreaNetwork;
using LocalStorage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        //path to determine
        private static string _path = @"data.ns";
        private static IRepository _repo = new BinaryFileRepository( _path );
        private static ILocalAreaNetwork _lan = new LAN();
        private NSContext c;
        private NSContextServices cs = new NSContextServices( _repo, _lan );
        delegate void ClearGroupsListInvoker();
        delegate void AddGroupInvoker( Button btn );

        public MainForm()
        {
            InitializeComponent();

            if (!File.Exists( _path ))
            {
                Controls.Add( _registerForm );
            }
            else
            {
                c = NSContext.Load( cs );

                c.Receiver();

                DisplayGroups();

                CreateGroupsButton();
            }

            FormClosing += new System.Windows.Forms.FormClosingEventHandler( MainFormClosing );

            _displayGroupsForm.ButtonCreateGroups += DisplayGroupsForm_ButtonCreateGroups;

            _createGroupsForm.ButtonGroupsCancel += CreateGroupsForm_ButtonGroupsCancel;
            _createGroupsForm.ButtonConfirmCreateGroups += CreateGroupsForm_ButtonConfirmCreateGroups;

            _noteTakingForm.ButtonLeaveGroups += NoteTakingForm_ButtonLeaveGroups;

            _registerForm.ButtonRegister += RegisterForm_ButtonRegister;

            _displayGroupsForm.TbSearchGroup += DisplayGroupsForm_TbSearchGroup;

            Timer();
        }

        public void Timer()
        {
            //Create a new timer
            System.Timers.Timer _syncTimer = new System.Timers.Timer();

            _syncTimer.Elapsed += SyncTimer;

            //Interval in milliseconds
            _syncTimer.Interval = 2000;
            _syncTimer.Enabled = true;
            _syncTimer.Start();
        }

        private void SyncTimer( object sender, ElapsedEventArgs e )
        {
            System.Diagnostics.Debug.WriteLine( "Timer firing -------------------------------------------" );

            if (c != null)
            {
                c.Sender();
                Object receiveData = c.ReceivedData();

                if (receiveData != null)
                {
                    System.Diagnostics.Debug.WriteLine("Data received");

                    if (receiveData is CoreLibrary.Group)
                    {
                        System.Diagnostics.Debug.WriteLine("Data is a group");

                        CoreLibrary.Group g = (CoreLibrary.Group)receiveData;

                        if (!c.Groups.ContainsKey(g.MulticastAddress))
                        {
                            c.Groups.Add(g.MulticastAddress, g);
                            CreateGroupsButton();
                            System.Diagnostics.Debug.WriteLine("Group is created");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Group " + g.Name + " already exist");
                        }
                    }
                    /*
                else
                {
                    //merge groups
                    System.Diagnostics.Debug.WriteLine("Timer receive all groups");

                    Dictionary<string, CoreLibrary.Group> newGroups = (Dictionary<string, CoreLibrary.Group>)receiveData;
                    int oldCount = c.Groups.Count;

                    foreach (var ng in newGroups)
                    {
                        System.Diagnostics.Debug.WriteLine("Timer received group: " + ng.Value.Name);
                    }

                    c.Groups = c.Groups.Union(newGroups).GroupBy(d => d.Key)
                        .ToDictionary(d => d.Key, d => d.First().Value);

                    int newCount = c.Groups.Count;
                    if (newCount - oldCount > 0)
                    {
                        CreateGroupsButton();
                        //SetTextCallback d = new SetTextCallback(CreateGroupsButton);
                        //this.Invoke(d);
                        //this.backgroundWorker1.RunWorkerAsync();
                    }

                    System.Diagnostics.Debug.WriteLine("Timer receive " + (newCount - oldCount) + "/"+newGroups.Count+" groups");
                }
                     * */
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No data received");
                }
            }
        }
        private void DisplayGroups()
        {
            c.CurrentGroup = c.FindGroup( "224.0.1.0" );

            c.JoinGroup( c.CurrentGroup.MulticastAddress );

            System.Diagnostics.Debug.WriteLine( "The default group 224.0.1.0 was joined" );

            if (!Controls.Contains( _displayGroupsForm ))
            {
                _displayGroupsForm.lbWelcome.Text = "Bienvenue " + c.CurrentUser.FirstName + "\r\n Current Group:" + c.CurrentGroup.MulticastAddress;
                Controls.Add( _displayGroupsForm );
            }

            _displayGroupsForm.Show();
        }

        /// <summary>
        /// Executed when clicked on the register button in the register form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RegisterForm_ButtonRegister( object sender, EventArgs e )
        {
            c = new NSContext();

            c.Initialize( cs );

            c.CurrentUser = c.CreateUser( _registerForm.GetFirstName, _registerForm.GetLastName );

            c.Save();

            Controls.Remove( _registerForm );
            _registerForm.Dispose();

            bool created;

            c.CurrentGroup = c.FindOrCreateGroup( "waitingroom", "displaygroups", "224.0.1.0", out created );

            c.Receiver();

            DisplayGroups();
        }

        /// <summary>
        /// Executed when clicked on the create group button in display groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayGroupsForm_ButtonCreateGroups( object sender, EventArgs e )
        {
            _displayGroupsForm.Hide();

            if (Controls.Contains( _createGroupsForm ))
                _createGroupsForm.Show();
            else
                Controls.Add( _createGroupsForm );
        }

        /// <summary>
        /// Executed when clicked on the confirm button to create a group in create groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateGroupsForm_ButtonConfirmCreateGroups( object sender, EventArgs e )
        {
            bool created;

            CoreLibrary.Group g = c.FindOrCreateGroup( _createGroupsForm.GroupName, _createGroupsForm.GroupTag, c.SetMulticastAddress(), out created );

            if (!created)
                MessageBox.Show( "Le nom du groupe existe déjà" );
            else
            {
                c.Save();
                CreateGroupsButton();

                Controls.Remove( _displayGroupsForm );
                //   _displayGroupsForm.Dispose();

                Controls.Remove( _createGroupsForm );
                //   _createGroupsForm.Dispose();

                c.LeaveGroup( c.CurrentGroup.MulticastAddress );
                c.CurrentGroup = g;

                NoteTaking();
            }
        }

        private void NoteTaking()
        {
            c.JoinGroup( c.CurrentGroup.MulticastAddress );

            if (Controls.Contains( _noteTakingForm ))
                _noteTakingForm.Show();
            else
                Controls.Add( _noteTakingForm );

            _noteTakingForm.groupNameTitle.Text = "Groupe: " + c.CurrentGroup.Name;
            _noteTakingForm.lbCurrentGroupAddress.Text = c.CurrentGroup.MulticastAddress;
        }

        /// <summary>
        /// Executed when clicked on the leave group button in notetaking's form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NoteTakingForm_ButtonLeaveGroups( object sender, EventArgs e )
        {
            c.LeaveGroup( c.CurrentGroup.MulticastAddress );
            c.CurrentGroup = c.FindGroup( "224.0.1.0" );
            Controls.Remove( _noteTakingForm );
            //  _noteTakingForm.Dispose();

            DisplayGroups();
        }

        /// <summary>
        /// Executed when clicked on the cancel button in create groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateGroupsForm_ButtonGroupsCancel( object sender, EventArgs e )
        {
            //    _createGroupsForm.Dispose();
            _createGroupsForm.Hide();
            _displayGroupsForm.Show();
        }

        private void DisplayGroupsForm_TbSearchGroup( object sender, EventArgs e )
        {
            string keyword = _displayGroupsForm.getSearchText;
            CreateGroupsButton( keyword );

        }

        private void ClearGroupsList()
        {
            _displayGroupsForm.panel.Controls.Clear();
        }

        private void AddGroup( Button btn )
        {
            _displayGroupsForm.panel.Controls.Add( btn );
        }
        /// <summary>
        /// This method creates a Button control at runtime
        /// </summary>
        private void CreateGroupsButton( string keyword = null )
        {

            //_displayGroupsForm.panel.Controls.Clear();

            if (_displayGroupsForm.InvokeRequired)
            {
                this.Invoke( new ClearGroupsListInvoker( ClearGroupsList ) );
            }
            else
            {
                ClearGroupsList();
            }

            // X & Y Location of each created button in the panel
            int x = 27;
            int y = 13;
            int button = 0;
            bool match;


            foreach (var group in c.Groups)
            {
                if (keyword != null)
                {
                    match = Regex.IsMatch( group.Key, keyword, RegexOptions.IgnoreCase );
                }
                else
                {
                    match = true;
                }

                if ((match || string.IsNullOrEmpty( keyword )) && group.Key != "224.0.1.0")
                {
                    // Create a Button object
                    Button btn = new Button();

                    // Set Button properties
                    btn.Name = group.Key;
                    btn.Size = new Size( 111, 48 );
                    btn.Text = "Name :" + group.Value.Name + "\r\nTag :" + group.Value.Tag + "\r\n" + group.Value.MulticastAddress;
                    btn.Location = new Point( x, y );
                    button++;
                    x += 117;

                    if (button >= 6)
                    {
                        x = 27;
                        y += 54;
                        button = 0;
                    }

                    // Add a Button Click Event handler
                    btn.Click += new EventHandler( GroupsButton );

                    // Add Button to the Form. 


                    if (_displayGroupsForm.InvokeRequired)
                    {
                        this.Invoke( new AddGroupInvoker( AddGroup ), btn );
                    }
                    else
                    {
                        _displayGroupsForm.panel.Controls.Add( btn );
                    }

                }
            }
        }

        private void GroupsButton( object sender, EventArgs e )
        {
            // Use "Sender" to know which button was clicked ?
            Button btn = sender as Button;

            c.LeaveGroup( c.CurrentGroup.MulticastAddress );
            c.CurrentGroup = c.FindGroup( btn.Name );

            Controls.Remove( _displayGroupsForm );
            //  _displayGroupsForm.Dispose();

            NoteTaking();
        }
        private void MainFormClosing( object sender, FormClosingEventArgs e )
        {
            if (MessageBox.Show( "Voulez-vous vraiment quitter l'application ?\r\nToutes les modifications effectuées seront enregistrées", "Fermeture", MessageBoxButtons.YesNo ) == DialogResult.Yes)
            {
                if (File.Exists( _path ))
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
