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
        public EventHandler ControlAddedEvent;

        public Content()
        {
            InitializeComponent();
        }

        private void Content_Resize(object sender, EventArgs e)
        {
            /*foreach (Control cont in Controls)
            {
                cont.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - 50);   
            }*/
        }

        private void Content_ControlAdded(object sender, ControlEventArgs e)
        {
            ControlAddedEvent(sender, e);
        }
    }
}
