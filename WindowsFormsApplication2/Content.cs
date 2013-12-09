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
    public partial class Content : UserControl
    {
        internal string TitleText { set { this.Title.Text = value; } }
        internal string TitleIcon = "dummy";

        public Content()
        {
            InitializeComponent();
        }
    }
}
