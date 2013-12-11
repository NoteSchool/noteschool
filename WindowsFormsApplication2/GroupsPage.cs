using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreLibrary;
using System.Text.RegularExpressions;

namespace GUI2
{
    public partial class GroupsPage : UserControl
    {
        public EventHandler GroupButtonClick;
        public EventHandler CreateGroupButtonClick;
        public EventHandler SearchTextChange;

        public GroupsPage()
        {
            InitializeComponent();

            Tag = "page";
        }

        public void CreateGroupButtons(Dictionary<string, CoreLibrary.Group> groups, string keyword = null)
        {
            this.containerPanel.Controls.Clear();

            bool match;
            Button btn;

            foreach (var group in groups)
            {
                match = string.IsNullOrEmpty(keyword) ? true :
                    (Regex.IsMatch(group.Value.Name, keyword, RegexOptions.IgnoreCase)
                        || Regex.IsMatch(group.Value.Tag, keyword, RegexOptions.IgnoreCase));

                if (match)
                {
                    // Create a Button object
                    btn = new Button();
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.Name = group.Key;
                    btn.AutoSize = true;
                    btn.Text = "Name :" + group.Value.Name + "\r\nTag :" + group.Value.Tag + "\r\n" + group.Value.MulticastAddress;
                    btn.Click += new EventHandler(GroupClick);

                    // Add Button to the Form. 
                    containerPanel.Controls.Add(btn);
                }
            }
        }

        private void GroupClick(object sender, EventArgs e)
        {
            GroupButtonClick(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateGroupButtonClick(this, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchTextChange(sender, e);
        }
    }
}
