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

        public NoteEditorList()
        {
            InitializeComponent();
        }

        internal NoteEditorListItem CreateItem(string title, DateTime lastUpdate, int likes = 0, bool isConnected=true)
        {
            NoteEditorListItem item = new NoteEditorListItem();

            item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            item.Cursor = System.Windows.Forms.Cursors.Hand;
            item.Name = title;
            item.Size = new System.Drawing.Size(167, _itemHeight);

            item.Title = title;
            item.LastUpdate = lastUpdate;
            item.Likes = likes;
            item.IsConnected = isConnected;

            return item;
        }

        internal void InsertItems(List<NoteEditorListItem> items, string keyword="")
        {
            bool match;
            int c = 0;
            foreach (var i in items)
            {
                match = string.IsNullOrEmpty(keyword) ? true :
                    Regex.IsMatch(i.Title, keyword, RegexOptions.IgnoreCase);

                if (match)
                {
                    i.Location = new System.Drawing.Point(0, c * _itemHeight);
                    this.itemContainerPanel.Controls.Add(i);

                    c++;
                }
            }
        }
    }
}
