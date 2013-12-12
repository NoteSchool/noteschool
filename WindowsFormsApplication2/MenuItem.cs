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
    public partial class menuItem : UserControl
    {
        internal bool IsDisabled = false;
        internal bool IsActive = false;
        internal string Id;

        internal new string Text 
        {
            get { return this.titleLabel.Text; }
            set 
            { 
                this.titleLabel.Text = value;
                //center text within the item
                this.titleLabel.Left = (this.Width - this.titleLabel.Size.Width) / 2;
            } 
        }

        public menuItem()
        {
            InitializeComponent();

            iconPictureBox.Click += Item_Click;
            titleLabel.Click += Item_Click;
        }

        void Item_Click(object sender, EventArgs e)
        {
            OnClick( e );
        }

        public void Active(bool sel = true)
        {       
            if (sel && !leftBorderLineShape.Visible)
            {
                this.SuspendLayout();
                iconPictureBox.Image = global::GUI2.Properties.Resources.registerHover;
                titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(233)))));

                leftBorderLineShape.Visible = true;
                IsActive = true;
                this.ResumeLayout();
            }
            else if (!sel && leftBorderLineShape.Visible)
            {
                this.SuspendLayout();
                iconPictureBox.Image = global::GUI2.Properties.Resources.register;
                titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(174)))));

                leftBorderLineShape.Visible = false;
                IsActive = false;
                this.ResumeLayout();
            }            
        }
    }
}
