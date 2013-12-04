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
        private static IRepository _repo = new BinaryFileRepository(_path);
        private static ILocalAreaNetwork _lan = new LAN();
        private NSContext c;
        private NSContextServices cs = new NSContextServices( _repo, _lan );

        /*
        string _data;
        string _multicastAddress;
        */

        public MainForm()
        {
            InitializeComponent();

            if (!File.Exists(_path))
            {
                Controls.Add(_registerForm);
            }
            else
            {
                c = NSContext.Load(cs);

             DisplayGroups();
   
                CreateGroupsButton();
            }

            FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainFormClosing );

            _displayGroupsForm.ButtonCreateGroups += DisplayGroupsForm_ButtonCreateGroups;

            _createGroupsForm.ButtonGroupsCancel += CreateGroupsForm_ButtonGroupsCancel;
            _createGroupsForm.ButtonConfirmCreateGroups += CreateGroupsForm_ButtonConfirmCreateGroups;

            _noteTakingForm.ButtonLeaveGroups += NoteTakingForm_ButtonLeaveGroups;

            _registerForm.ButtonRegister += RegisterForm_ButtonRegister;

            _displayGroupsForm.TbSearchGroup += DisplayGroupsForm_TbSearchGroup;
        }
        
        private void DisplayGroups()
        {
            /*
            c.JoinGroup();
            _data = c.Receiver();
            
            if (_data != null)
            {
                string[] groupdata = _data.Split( '-' );
                
            }
            */
            if (!Controls.Contains(_displayGroupsForm))
            {
                _displayGroupsForm.welcomeBox.Text = "Bienvenue " + c.CurrentUser.FirstName;
                Controls.Add(_displayGroupsForm);
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

            c.CurrentUser = c.CreateUser( _registerForm.GetFirstName, _registerForm.GetLastName);

            c.Save();

            Controls.Remove( _registerForm );
            _registerForm.Dispose();

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

            c.FindOrCreateGroup( _createGroupsForm.GroupName, _createGroupsForm.GroupTag, c.SetMulticastAddress(), out created );

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

                NoteTaking();
            }
        }
        
        private void NoteTaking()
        {
            /*
            c.Timer( _noteTakingForm.NoteTakingtext );
            */
            //Note note = new Note();

            if (Controls.Contains(_noteTakingForm))
                _noteTakingForm.Show();
            else
                Controls.Add( _noteTakingForm );
        }

        /// <summary>
        /// Executed when clicked on the leave group button in notetaking's form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NoteTakingForm_ButtonLeaveGroups( object sender, EventArgs e )
        {
            /*
            c.LeaveGroup(_multicastAddress);
            c.JoinGroup();
            c.Receiver();
            */

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

        private void DisplayGroupsForm_TbSearchGroup(object sender, EventArgs e)
        {
            string keyword = _displayGroupsForm.getSearchText;
            CreateGroupsButton(keyword);

        }
        /// <summary>
        /// This method creates a Button control at runtime
        /// </summary>
        private void CreateGroupsButton(string keyword = null)
        {

            _displayGroupsForm.panel.Controls.Clear();

            // X & Y Location of each created button in the panel
            int x = 27;
            int y = 13;
            int button = 0;
            bool match;
            

            foreach (var groups in c.Groups)
	        {
                if (keyword != null)
                {
                    match = Regex.IsMatch(groups.Key, keyword, RegexOptions.IgnoreCase);
                }
                else {
                     match = true;
                }
                
                if (match || string.IsNullOrEmpty(keyword))
                {
                    // Create a Button object
                    Button btn = new Button();

                    // Set Button properties
                    btn.Name = groups.Key;
                    btn.Tag = groups.Value;
                    btn.Size = new Size(111, 48);
                    btn.Text = "Name :" + groups.Key + "\r\nTag :" + groups.Value.Tag + "\r\n" + groups.Value.MulticastAddress;
                    btn.Location = new Point(x, y);
                    button++;
                    x += 117;

                    if (button >= 6)
                    {
                        x = 27;
                        y += 54;
                        button = 0;
                    }

                    // Add a Button Click Event handler
                    btn.Click += new EventHandler(GroupsButton);

                    // Add Button to the Form. 
                    _displayGroupsForm.panel.Controls.Add(btn);
                }
            }
        }

        private void GroupsButton( object sender, EventArgs e )
        {
            // Use "Sender" to know which button was clicked ?
            Button btn = sender as Button;

            /*
            c.LeaveGroup();

            foreach (var groups in c.GetGroups)
            {
                if (groups.Key.Contains( btn.Name ))
                {
                    _multicastAddress = groups.Value.MulticastAddress;
                    c.JoinGroup( groups.Value.MulticastAddress );
                }
            }
            */

            Controls.Remove( _displayGroupsForm );
          //  _displayGroupsForm.Dispose();

            NoteTaking();

            /*
            PropertyInfo[] infos = btn.Tag.GetType().GetProperties();
            foreach (PropertyInfo info in infos)
            {
                Array j = info.GetAccessors();

                MessageBox.Show(j[0]);
            }
            */
        }
        private void MainFormClosing( object sender, FormClosingEventArgs e )
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?\r\nToutes les modifications effectuées seront enregistrées", "Fermeture", MessageBoxButtons.YesNo ) == DialogResult.Yes)
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
