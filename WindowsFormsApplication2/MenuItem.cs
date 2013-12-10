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
    public partial class MenuItem : UserControl
    {
        public bool IsDisabled = false;
        public bool IsActive = false;
        public string ID;

        public string LabelText 
        {
            get { return this.ItemText.Text; }
            set 
            { 
                this.ItemText.Text = value;
                //center text within the item
                this.ItemText.Left = (this.Width - this.ItemText.Size.Width) / 2;
            } 
        }

        public MenuItem()
        {
            InitializeComponent();
        }

        public void Active(bool sel = true)
        {       
            if (sel && !ItemLeftBorder.Visible)
            {
                this.SuspendLayout();
                ItemIcon.Image = global::GUI2.Properties.Resources.registerHover;
                ItemText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(233)))));

                ItemLeftBorder.Visible = true;
                IsActive = true;
                this.ResumeLayout();
            }
            else if (!sel && ItemLeftBorder.Visible)
            {
                this.SuspendLayout();
                ItemIcon.Image = global::GUI2.Properties.Resources.register;
                ItemText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(174)))));

                ItemLeftBorder.Visible = false;
                IsActive = false;
                this.ResumeLayout();
            }            
        }

        public void rectangleShape1_MouseEnter(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("enter");
            /*
            if (!IsDisabled)
            {
                ItemIcon.Image = global::GUI2.Properties.Resources.registerHover;
                ItemText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(233)))));
            }
             * */
        }

        public void rectangleShape1_MouseLeave(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("leave");
            /*
            if (!IsActive)
            {
                ItemIcon.Image = global::GUI2.Properties.Resources.register;
                ItemText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(174)))));
            }
             * */
        }
    }
}
