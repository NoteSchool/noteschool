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
        public Register()
        {
            InitializeComponent();
            btnRegister.Click += new EventHandler(btnRegister_Click);
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            string userLastName = tbLastName.Text.Trim();
            string userFirstName = tbFirstName.Text.Trim();

            User user1 = new User(userLastName, userFirstName );

            MessageBox.Show( user1.FirstName );
        }
    }
}
