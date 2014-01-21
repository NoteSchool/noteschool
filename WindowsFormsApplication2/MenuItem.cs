using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

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

        public menuItem(string id="")
        {
            InitializeComponent();

            Id = id;
            iconPictureBox.Image = getIcon();

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
                //this.SuspendLayout();


                iconPictureBox.Image = getIcon(true);
                titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(233)))));

                leftBorderLineShape.Visible = true;
                IsActive = true;
                //this.ResumeLayout();
            }
            else if (!sel && leftBorderLineShape.Visible)
            {
                //this.SuspendLayout();
                iconPictureBox.Image = getIcon();
                titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(174)))));

                leftBorderLineShape.Visible = false;
                IsActive = false;
                //this.ResumeLayout();
            }            
        }

        private System.Drawing.Bitmap getIcon(bool hover=false)
        {
            //default icon
            System.Drawing.Bitmap icon = global::GUI2.Properties.Resources.register;

             switch (Id)
                {
                    case "groups":
                        icon = !hover ? global::GUI2.Properties.Resources.groups : global::GUI2.Properties.Resources.groupsHover;
                        break;
                    case "help":
                        icon = !hover ? global::GUI2.Properties.Resources.help : global::GUI2.Properties.Resources.helpHover;
                        break;
                 case "register":
                        icon = !hover ? global::GUI2.Properties.Resources.register : global::GUI2.Properties.Resources.registerHover;
                        break;

                 case "noteEditor":
                        icon = !hover ? global::GUI2.Properties.Resources.noteEditor : global::GUI2.Properties.Resources.noteEditorHover;
                        break;

                }

             return icon;
        }
    }
}
