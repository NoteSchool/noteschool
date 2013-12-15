using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI2
{
    public partial class NoteEditorList : UserControl
    {
        private readonly int _itemHeight = 56;
        private NoteEditorListItem _activeItem;
        public EventHandler OnItemClick;
        public EventHandler OnSearch;
        private Color _itemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        private Size _itemSize;
        private EventHandler _itemClick;

        public NoteEditorList()
        {
            InitializeComponent();

            _itemSize = new System.Drawing.Size(167, _itemHeight);
            _itemClick = new EventHandler(itemClick);

            searchTextBox.TextChanged += (s, e) =>
                {
                    if (searchTextBox.Text != "Recherche..")
                    OnSearch(s, e);
                };

            searchTextBox.GotFocus += (s, e) =>
            {
                if (searchTextBox.Text == "Recherche..")
                    searchTextBox.Text = "";
            };
            searchTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                    searchTextBox.Text = "Recherche..";
            };
        }

        internal void BuildList(Dictionary<string, CoreLibrary.User> users, string keyword = "")
        {
            if (users != null)
            {
                List<NoteEditorListItem> items = new List<NoteEditorListItem>();
                bool match;

                foreach (var u in users)
                {
                    match = string.IsNullOrEmpty(keyword) ? true :
                        Regex.IsMatch(u.Value.FirstName+u.Value.LastName, keyword, RegexOptions.IgnoreCase);

                    if (match)
                    {
                        items.Add(CreateItem(id: u.Value.Id, title: u.Value.FirstName + " " + u.Value.LastName));
                    }
                }

                InsertItems(items);
            }
        }

        internal NoteEditorListItem CreateItem(string id, string title, /*DateTime lastUpdate,*/ int likes = 0, bool isConnected=true)
        {
            NoteEditorListItem item = new NoteEditorListItem();

            item.BackColor = _itemBackColor;
            item.Cursor = System.Windows.Forms.Cursors.Hand;
            item.Name = title;
            item.Size = _itemSize;

            item.Title = title;
            //item.LastUpdate = lastUpdate;
            item.Likes = likes;
            item.IsConnected = isConnected;
            item.Id = id;
            item.Click += _itemClick;

            return item;
        }

        internal void InsertItems(List<NoteEditorListItem> items)
        {
            this.itemContainerPanel.SuspendLayout();
            this.itemContainerPanel.Controls.Clear();
            int c = 0;
            var tItems = new List<Control>();
            foreach (var i in items)
            {
                    i.Location = new System.Drawing.Point(0, c * _itemHeight);
                    tItems.Add(i);

                    c++;
            }
            this.itemContainerPanel.Controls.AddRange(tItems.ToArray());
            this.itemContainerPanel.ResumeLayout(false);
            this.itemContainerPanel.PerformLayout();
        }

        void itemClick(Object s, EventArgs e)
        {
            NoteEditorListItem it = s as NoteEditorListItem;

            if (_activeItem != it)
            {
                _activeItem = it;

                OnItemClick(it, e);
            }
        }
    }
}
