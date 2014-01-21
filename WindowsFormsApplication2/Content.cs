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
    

    public partial class content : UserControl
    {
        internal string Title { set { this.titleLabel.Text = value; } }
        internal string TitleIcon = "dummy";

        internal delegate void RemoveNoteEditorPage();
        internal RemoveNoteEditorPage RemoveNoteEditorPageFunc;

        public content()
        {
            InitializeComponent();
        }

        internal void NewPage(Control ctrl)
        {
            RemoveNoteEditorPageFunc();
            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(ctrl);
        }
    }
}
