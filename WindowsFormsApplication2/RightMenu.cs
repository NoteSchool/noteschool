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
    public partial class RightMenu : UserControl
    {
        internal int ItemCount = 1;
        internal MenuItem SelectedItem;
        internal const int menuItemHeight = 83;
        public EventHandler ItemClick;

        public RightMenu()
        {
            InitializeComponent();

        }

        public MenuItem createItem(string label, string icon = "register", bool disable = false)
        {
            MenuItem menuItem = new GUI2.MenuItem();

            menuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            menuItem.Location = new System.Drawing.Point(0, ItemCount * menuItemHeight);
            menuItem.Name = label;
            menuItem.Size = new System.Drawing.Size(150, 84);
            menuItem.IsDisabled = disable;
            menuItem.LabelText = label;

            menuItem.Click += new System.EventHandler(this.MenuItem_click);

            ItemCount++;
 
            return menuItem;
        }

        public void RemoveItem(MenuItem item)
        {
            this.SuspendLayout();

            this.Controls.Remove(item);

            int count = 0;
            foreach (Control C in Controls)
            {
                if (C.GetType() == typeof(MenuItem))
                {
                    C.Location = new System.Drawing.Point(0, count * menuItemHeight);
                    count++;
                }
            }

            if (item.IsActive)
            {
                //active an another
            }

            this.ResumeLayout();
        }

        private void MenuItem_click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;

            if (!item.IsActive && !item.IsDisabled)
             {
                   SelectedItem.Active(false);
                    item.Active(true);
                    SelectedItem = item;

                    ItemClick(SelectedItem, e);   
            }
        }

        private void RightMenu_load(object sender, EventArgs e)
        {
            //store default selected item
            SelectedItem = this.menuItem1;
            SelectedItem.Active(true);
        }
    }
}
