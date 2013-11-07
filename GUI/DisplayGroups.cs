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
    public partial class DisplayGroups : UserControl
    {
        public event EventHandler ButtonCreateGroups;
           
        public DisplayGroups()
        {
            InitializeComponent();
            btnCreateGroups.Click += new EventHandler(btnCreateGroups_Click);
        }

        public void btnCreateGroups_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (ButtonCreateGroups != null)
                ButtonCreateGroups(this, e);  
        }
    }
}
