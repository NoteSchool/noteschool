using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreLibrary;

namespace GUI
{
    public partial class Register : UserControl
    {
        public event EventHandler ButtonRegister;

        public Register()
        {
            InitializeComponent();
            btnRegister.Click += new EventHandler( btnRegister_Click );
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            if (tbFirstName.Text.Length == 0)
                MessageBox.Show( "Le champ prénom ne doit pas être vide" );
            else if (tbLastName.Text.Length == 0)
                MessageBox.Show( "Le champ nom ne doit pas être vide" );
            else
            //bubble the event up to the parent
            if (ButtonRegister != null)
                ButtonRegister( this, e );
        }

        public string GetLastName
        {
            get { return tbLastName.Text; }
        }

        public string GetFirstName
        {
            get { return tbFirstName.Text; }
        }
    }
}
