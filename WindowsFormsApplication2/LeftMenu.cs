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
    public partial class leftMenu : UserControl
    {
        private List<menuItem> _menuItems = new List<menuItem>();

        private menuItem _selectedItem;
        internal menuItem SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                if (_selectedItem != null)
                {
                    _selectedItem.Active(false);
                }
                value.Active(true); 
                _selectedItem = value; 
            }
        }

        private readonly int _itemHeight = 83;

        internal EventHandler ItemClick;

        public leftMenu()
        {
            InitializeComponent();
        }

        public menuItem createItem(string label, string icon = "register", bool disable = false, int pos = -1, string id="")
        {
            menuItem menuItem = new GUI2.menuItem();

            menuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            menuItem.Name = label;
            menuItem.Size = new System.Drawing.Size(150, 84);
            menuItem.IsDisabled = disable;
            menuItem.Text = label;
            menuItem.Id = id;
            menuItem.Click += new System.EventHandler(this.MenuItem_click);

            if (pos != -1)
            {
                _menuItems.Insert(pos, menuItem);
                
                ReposItems();
            }
            else
            {
                menuItem.Location = new System.Drawing.Point(0, _menuItems.Count * _itemHeight);
                _menuItems.Add(menuItem);
            }

            Controls.Add(menuItem);
            return menuItem;
        }

        public void RemoveItem(menuItem item)
        {
            this.Controls.Remove(item);
            _menuItems.Remove(item);

            ReposItems();
        }

        private void MenuItem_click(object sender, EventArgs e)
        {
            menuItem item = sender as menuItem;

            if (!item.IsActive && !item.IsDisabled)
             {
                   SelectedItem.Active(false);
                    item.Active(true);
                    SelectedItem = item;

                    ItemClick(SelectedItem, e);   
            }
        }

        private void ReposItems()
        {
            
            this.SuspendLayout();
            int i = 0;
            foreach (Control m in Controls)
            {
                m.Location = new System.Drawing.Point(0, _menuItems.IndexOf(m as menuItem) * _itemHeight);
                i++;
            }
            this.ResumeLayout();

            System.Diagnostics.Debug.WriteLine(Controls.Count + " " + _menuItems.Count);
        }
    }
}
