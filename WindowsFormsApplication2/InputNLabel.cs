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
    public partial class inputNLabel : UserControl
    {
        public string LabelText { set { this.titleLabel.Text = value; } }
        public string Value { get { return this.inputTextBox.Text; } }

        public inputNLabel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
