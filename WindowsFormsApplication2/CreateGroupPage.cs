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
    public partial class CreateGroupPage : UserControl
    {
        public EventHandler SaveButtonClick;
        public EventHandler CancelButtonClick;

        public string GroupTitle { get { return this.inputNLabel1.Value; } }
        public string GroupTag { get { return this.inputNLabel2.Value; } }

        public CreateGroupPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveButtonClick(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelButtonClick(this, e);
        }

        private void CreateGroupPage_Load(object sender, EventArgs e)
        {
            this.inputNLabel1.LabelText = "Titre";
            this.inputNLabel2.LabelText = "Tag";
        }
    }
}
