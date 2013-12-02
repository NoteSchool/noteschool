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
        public event EventHandler TbSearchGroup;


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
        public Panel panel
        {
            get { return groupPanel; }
        }
        public string getSearchText
        {
            get { return tbSearchGroup.Text; }
        }

        private void tbSearchGroup_TextChanged(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (TbSearchGroup != null)
                TbSearchGroup(this, e);
        }


    }
}
