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
    public partial class NoteEditorListItem : UserControl
    {
        internal string Id;
        internal string Title 
        {
            get { return this.titleLabel.Text; }
            set { this.titleLabel.Text = value; }
        }

        private int _likes = 0;
        internal int Likes
        {
            get { return _likes; }
            set { _likes = value; this.likesLabel.Text = value.ToString(); }
        }

        internal DateTime _lastUpdate;
        internal DateTime LastUpdate
        {
            get { return _lastUpdate;  }
            set 
            { 
                _lastUpdate = value; 
                this.lastTimeLabel.Text = CoreLibrary.Helper.TimeSince(value);           
            }
        }

        internal bool IsConnected;

        public NoteEditorListItem()
        {
            InitializeComponent();

            titleLabel.Click += Item_Click;
            lastTimeLabel.Click += Item_Click;
            likesLabel.Click += Item_Click;
        }

        void Item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
