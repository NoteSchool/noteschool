using NoteSchool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GUI
{
    public partial class MainForm : Form
    {
        private Register _registerForm;
        private DisplayGroups _displayGroups;
        private CreateGroups _createGroups;
        private NotetakingMainPage _notetakingMainPage;

        public MainForm()
        {
            InitializeComponent();
            
            bool registered = true;

            if (registered == false)
            {
                _registerForm = new Register();
                //Add register's form and user control
                Register();
            }
            else
            {
                if (_displayGroups == null)
                {
                    _displayGroups = new DisplayGroups();
                    //Add groups's form and user control
                    groups();
                }

                _displayGroups.ButtonCreateGroups += DisplayGroups_ButtonCreateGroups;
            }      
        }

        //when clicked on the create group button in display groups' form
        public void DisplayGroups_ButtonCreateGroups(object sender, EventArgs e)
        {
            _displayGroups.Hide();

            if (_createGroups == null)
            {
                _createGroups = new CreateGroups();
                //Add create groups's form and user control
                CreateGroups();

                //add group to list and create its folder
               // Database.AddGroup();
            }
            else
                _createGroups.Show();

            _createGroups.ButtonGroupsCancel += CreateGroups_ButtonGroupsCancel;
            _createGroups.ButtonConfirmCreateGroups += CreateGroups_ButtonConfirmCreateGroups;

        }

        //when clicked on the confirm button to create a group in create groups' form
        void CreateGroups_ButtonConfirmCreateGroups(object sender, EventArgs e)
        {
            _createGroups.Hide();
            if (_notetakingMainPage == null)
            {
                _notetakingMainPage = new NotetakingMainPage();
                //Add create groups's form and user control
                NoteTaking();
            }
            else
                _notetakingMainPage.Show();

            _notetakingMainPage.ButtonLeaveGroups += NotetakingMainPage_ButtonLeaveGroups;
        }

        //when clicked on the leave group button in notetaking main page's form
        void NotetakingMainPage_ButtonLeaveGroups(object sender, EventArgs e)
        {
            _notetakingMainPage.Dispose();
            _displayGroups.Show();
        }

        //when clicked on the cancel button in create groups' form
        void CreateGroups_ButtonGroupsCancel(object sender, EventArgs e)
        {
            _createGroups.Hide();
            _displayGroups.Show();
        }

 
    }
}
