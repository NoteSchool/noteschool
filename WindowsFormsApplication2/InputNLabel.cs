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
    public partial class InputNLabel : UserControl
    {
        public string LabelText { set { this.label1.Text = value; } }
        public string Value { get { return this.textBox1.Text; } }

        public InputNLabel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
