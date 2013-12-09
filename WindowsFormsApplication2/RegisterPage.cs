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
    public partial class RegisterPage : UserControl
    {
        public EventHandler SaveButtonClick;

        public string FirstName { get { return this.inputNLabel1.Value; } }
        public string LastName { get { return this.inputNLabel2.Value; } }

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {
            var page = sender as RegisterPage;

            page.inputNLabel1.LabelText = "Prénom";
            page.inputNLabel2.LabelText = "Nom";
            page.button1.Text = "Enregistrer";

        }

        private void button1_Click(object sender, EventArgs e)
        {
           SaveButtonClick(this, e);
        }


    }
}
