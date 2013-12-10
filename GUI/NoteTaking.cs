using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class NoteTaking : UserControl
    {
        public event EventHandler ButtonLeaveGroups;

        public NoteTaking()
        {
            InitializeComponent();

            btnLeaveGroup.Click += new EventHandler( btnLeaveGroup_Click );
        }

        //when user leaves the group
        private void btnLeaveGroup_Click( object sender, EventArgs e )
        {
            //bubble the event up to the parent
            if (ButtonLeaveGroups != null)
                ButtonLeaveGroups( this, e );
        }

        public string NoteTakingtext
        {
            get { return rtbNoteTaking.Text; }
        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                    File.WriteAllText(saveFileDialog1.FileName, NoteTakingtext);
                }
                else
                {
                    MessageBox.Show("Impossible d'écrire dans le fichier");
                }
            }
        }

        private void FontButton_Click_1(object sender, EventArgs e)
        {
            DialogResult r = fontDialog1.ShowDialog(this);
            rtbNoteTaking.SelectionFont = fontDialog1.Font;
        }

        private void ColorButton_Click_1(object sender, EventArgs e)
        {
            DialogResult i = colorDialog1.ShowDialog(this);
            rtbNoteTaking.SelectionColor = colorDialog1.Color;
        }

        private void rtbNoteTaking_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}
