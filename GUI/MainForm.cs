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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private Register _registerForm;
        private DisplayGroups _displayGroupsForm;
        private CreateGroups _createGroupsForm;
        private NoteTaking _noteTakingForm;

        //path to determine
        private static string _path = @"data.ns";
        private static IRepository _repo = new BinaryFileRepository(_path);
        private static ILocalAreaNetwork _lan = new LAN();
        private NSContext c;
        private NSContextServices cs = new NSContextServices( _repo, _lan );

        public MainForm()
        {
            InitializeComponent();

            if (!File.Exists(_path))
            {
                _registerForm = new Register();

                //Add register's user control
                RegisterControl();

                _registerForm.ButtonRegister += RegisterForm_ButtonRegister;
            }
            else
            {
                c = NSContext.Load(cs);

                DisplayGroups();
                
                //create groups button
                CreateGroupsButton();
            }

            FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainFormClosing );
        }

        private void DisplayGroups()
        {
            string data = c.Receiver();

            if (data != null)
            {
                string[] groupdata = data.Split( '-' );
                c.FindOrCreateGroup( groupdata[0], groupdata[1], groupdata[2] );
            }

            _displayGroupsForm = new DisplayGroups();

            //Add groups's form and user control
            DisplayGroupsControl();

            _displayGroupsForm.ButtonCreateGroups += DisplayGroupsForm_ButtonCreateGroups;
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

            c.CreateUser( _registerForm.GetFirstName, _registerForm.GetLastName);

            c.Save();

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
            _createGroupsForm = new CreateGroups();

            //Add create groups's form and user control
            CreateGroupsControl();

            _createGroupsForm.ButtonGroupsCancel += CreateGroupsForm_ButtonGroupsCancel;
            _createGroupsForm.ButtonConfirmCreateGroups += CreateGroupsForm_ButtonConfirmCreateGroups;
        }
        
        /// <summary>
        /// Executed when clicked on the confirm button to create a group in create groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateGroupsForm_ButtonConfirmCreateGroups( object sender, EventArgs e )
        {
            bool created;

            c.FindOrCreateGroup( _createGroupsForm.GroupName, _createGroupsForm.GroupTag, out created );

            if (!created)
                MessageBox.Show( "Le nom du groupe existe déjà" );
            else
            {
                c.Save();
                CreateGroupsButton();
                _createGroupsForm.Hide();
                NoteTaking();
            }
        }
        private void NoteTaking()
        {
            _noteTakingForm = new NoteTaking();

            //Add create groups's form and user control
            NoteTakingControl();

            _noteTakingForm.ButtonLeaveGroups += NoteTakingForm_ButtonLeaveGroups;
        }

        /// <summary>
        /// Executed when clicked on the leave group button in notetaking's form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NoteTakingForm_ButtonLeaveGroups( object sender, EventArgs e )
        {
            _noteTakingForm.Dispose();
            _displayGroupsForm.Show();
        }

        /// <summary>
        /// Executed when clicked on the cancel button in create groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateGroupsForm_ButtonGroupsCancel( object sender, EventArgs e )
        {
            _createGroupsForm.Hide();
            _displayGroupsForm.Show();
        }

        /// <summary>
        /// This method creates a Button control at runtime
        /// </summary>
        private void CreateGroupsButton()
        {    
            // X & Y Location of each created button in the panel
            int x = 27;
            int y = 13;
            int button = 0;

            foreach (var groups in c.GetGroups)
	        {
                // Create a Button object
                Button btn = new Button();

                // Set Button properties
                btn.Name = groups.Key;
                btn.Tag = groups;
                btn.Size = new Size(111, 48 );
                btn.Text = "Name :" + groups.Key + "\r\nTag :" + groups.Value.Tag + "\r\n" + groups.Value.MulticastAddress;
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
                _displayGroupsForm.panel.Controls.Add( btn );
            }
        }

        private void GroupsButton( object sender, EventArgs e )
        {
            // Use "Sender" to know which button was clicked ?
            Button btn = sender as Button;

            _displayGroupsForm.Hide();
            NoteTaking();
             
            /*
            Button dynamicButton = sender as Button;
            MessageBox.Show( dynamicButton.Name );
             * */
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
