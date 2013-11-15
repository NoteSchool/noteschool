using System;
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
    public partial class NoteTaking : UserControl
    {
        public event EventHandler ButtonLeaveGroups;

        public NoteTaking()
        {
            InitializeComponent();

            btnLeaveGroup.Click += new EventHandler( btnLeaveGroup_Click );
        }

        //when user leaves the group
        private void btnLeaveGroup_Click( object sender, EventArgs e )
        {
            //bubble the event up to the parent
            if (ButtonLeaveGroups != null)
                ButtonLeaveGroups( this, e );
        }
    }
}
