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
    public partial class NoteEditorToolBox : UserControl
    {
        internal EventHandler ExportClickEvent;

        public NoteEditorToolBox()
        {
            InitializeComponent();

            export.Click += (s, e) =>
                {
                    ExportClickEvent(s, e);
                };
        }
    }
}
