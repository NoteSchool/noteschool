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
        private string _keyword;

        public GroupsPage()
        {
            InitializeComponent();

            Tag = "page";

            searchTextBox.GotFocus += (s, e) =>
                {
                    if(searchTextBox.Text == "Recherche")
                        searchTextBox.Text = "";
                };
            searchTextBox.LostFocus += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                        searchTextBox.Text = "Recherche";
                };
        }

        public void CreateGroupButtons(Dictionary<string, CoreLibrary.Group> groups, string keyword = null)
        {
            keyword = keyword != null ? keyword : _keyword;
            _keyword = keyword;

            this.containerPanel.SuspendLayout();
            this.containerPanel.Controls.Clear();
               
            bool match;
            Button btn;
            var btns = new List<Control>();

            var btnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            var btnFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            var BtnEvent = new EventHandler(GroupClick);

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
                    btn.BackColor = btnBackColor;
                    btn.Font = btnFont;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.Name = group.Key;
                    btn.AutoSize = true;
                    btn.Text = "Name :" + group.Value.Name + "\r\nTag :" + group.Value.Tag + "\r\n" + group.Value.MulticastAddress;
                    btn.Click += BtnEvent;

                    // Add Button to the Form. 
                    btns.Add(btn);
                }
            }

            containerPanel.Controls.AddRange(btns.ToArray());
            this.containerPanel.ResumeLayout();
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
            if (searchTextBox.Text != "Recherche")
           SearchTextChange(sender, e);
        }
    }
}
