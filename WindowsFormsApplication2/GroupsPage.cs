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

        public void CreateGroupButtons(NSContext c, string keyword = null)
        {
            this.panel1.Controls.Clear();

            // X & Y Location of each created button in the panel
            int x = 27;
            int y = 13;
            int button = 0;
            bool match;

            foreach (var group in c.Groups)
            {
                if (keyword != null)
                {
                    match = Regex.IsMatch(group.Value.Name, keyword, RegexOptions.IgnoreCase)
                        || Regex.IsMatch(group.Value.Tag, keyword, RegexOptions.IgnoreCase);
                }
                else
                {
                    match = true;
                }

                if (match || string.IsNullOrEmpty(keyword))
                {
                    // Create a Button object
                    Button btn = new Button();

                    // Set Button properties
                    btn.Name = group.Key;
                    btn.Size = new Size(111, 48);
                    btn.Text = "Name :" + group.Value.Name + "\r\nTag :" + group.Value.Tag + "\r\n" + group.Value.MulticastAddress;
                    btn.Location = new Point(x, y);
                    button++;
                    x += 117;

                    if (button >= 6)
                    {
                        x = 27;
                        y += 54;
                        button = 0;
                    }

                    // Add a Button Click Event handler
                    btn.Click += new EventHandler(GroupClick);

                    // Add Button to the Form. 
                    panel1.Controls.Add(btn);
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
