﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class CreateGroups : UserControl
    {
        public event EventHandler ButtonGroupsCancel;
        public event EventHandler ButtonConfirmCreateGroups;

        public CreateGroups()
        {
            InitializeComponent();

            btnConfirmCreateGroup.Click += new EventHandler( btnConfirmCreateGroup_Click );
            btnGroupCancel.Click += new EventHandler( btnGroupCancel_Click );
        }
        private void btnConfirmCreateGroup_Click( object sender, EventArgs e )
        {
            if (tbGroupName.Text.Length == 0)
                MessageBox.Show( "Le nom du groupe ne doit pas être vide" );
            else if (tbGroupTag.Text.Length == 0)
                MessageBox.Show( "Le champ tag ne doit pas être vide" );
            else
                //bubble the event up to the parent
                if (ButtonConfirmCreateGroups != null)
                    ButtonConfirmCreateGroups( this, e );
        }

        private void btnGroupCancel_Click( object sender, EventArgs e )
        {
            Reset();
            //bubble the event up to the parent
            if (ButtonGroupsCancel != null)
                ButtonGroupsCancel( this, e );
        }
        public string GroupName
        {
            get { return tbGroupName.Text; }
        }
        public string GroupTag
        {
            get { return tbGroupTag.Text; }
        }
        private void Reset()
        {
            tbGroupName.ResetText();
            tbGroupTag.ResetText();
        }
    }
}
