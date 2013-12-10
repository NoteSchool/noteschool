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
    public partial class AboutPage : UserControl
    {
        public override string Text { set { this.label1.Text = value; } }

        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
