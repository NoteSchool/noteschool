using CoreLibrary;
using LocalStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        //NEED TO GRAND PERMISSIONS
        /*
        private static string _path = @"D:\";
        private static IRepository _repo = new BinaryFileRepository(_path);
        private NSContext c;
        private NSContextServices cs = new NSContextServices( _repo );
        */
        NSContext cs2;

        public MainForm()
        {
            InitializeComponent();

            if (cs2 == null)
            {
                _registerForm = new Register();

                //Add register's user control
                RegisterControl();

                _registerForm.ButtonRegister += _registerForm_ButtonRegister;
            }
            else
            {
               // c = NSContext.Load( cs);

                DisplayGroups();
            }
        }

        private void DisplayGroups()
        {
            _displayGroupsForm = new DisplayGroups();

            //Add groups's form and user control
            DisplayGroupsControl();

            _displayGroupsForm.ButtonCreateGroups += _displayGroupsForm_ButtonCreateGroups;
        }

        /// <summary>
        /// Executed when clicked on the register button in the register form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _registerForm_ButtonRegister( object sender, EventArgs e )
        {
            string _path = @"D:\";
            IRepository _repo = new BinaryFileRepository( _path );
            NSContext c;
            NSContextServices cs = new NSContextServices( _repo );

            c = new NSContext();

            c.Initialize( cs );

            c.CreateUser( _registerForm.GetFirstName, _registerForm.GetLastName );

            //c.Save();

            _registerForm.Dispose();

            DisplayGroups();
        }

        /// <summary>
        /// Executed when clicked on the create group button in display groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _displayGroupsForm_ButtonCreateGroups( object sender, EventArgs e )
        {
            _displayGroupsForm.Hide();
            _createGroupsForm = new CreateGroups();

            //Add create groups's form and user control
            CreateGroupsControl();

            _createGroupsForm.ButtonGroupsCancel += _createGroupsForm_ButtonGroupsCancel;
            _createGroupsForm.ButtonConfirmCreateGroups += _createGroupsForm_ButtonConfirmCreateGroups;
        }

        /// <summary>
        /// Executed when clicked on the confirm button to create a group in create groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _createGroupsForm_ButtonConfirmCreateGroups( object sender, EventArgs e )
        {
            _createGroupsForm.Hide();
            _noteTakingForm = new NoteTaking();

            //Add create groups's form and user control
            NoteTakingControl();

            _noteTakingForm.ButtonLeaveGroups += _noteTakingForm_ButtonLeaveGroups;
        }

        /// <summary>
        /// Executed when clicked on the leave group button in notetaking's form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _noteTakingForm_ButtonLeaveGroups( object sender, EventArgs e )
        {
            _noteTakingForm.Dispose();
            _displayGroupsForm.Show();
        }

        /// <summary>
        /// Executed when clicked on the cancel button in create groups' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _createGroupsForm_ButtonGroupsCancel( object sender, EventArgs e )
        {
            _createGroupsForm.Hide();
            _displayGroupsForm.Show();
        }
    }
}
