using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI2
{
    public partial class Header : UserControl
    {
        public string UsernameText { set { this.Username.Text = value; } }

        public Header()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void header_Load(object sender, EventArgs e)
        {

        }
    }
}
