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
    public partial class NoteEditor : UserControl
    {
        public NoteEditor()
        {
            InitializeComponent();

            Tag = "page";

            this.tableLayoutPanel1.CellPaint += tableLayoutPanel1_CellPaint;
            //this.editorContainerPanel.Size = new System.Drawing.Size(this.editorContainerPanel.Control. , 393);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //MessageBox.Show("test");
            //if (e.Column == 1 && e.Row == 0)
                e.Graphics.DrawRectangle(new Pen(Color.Blue), e.CellBounds);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
        }
    }
}
