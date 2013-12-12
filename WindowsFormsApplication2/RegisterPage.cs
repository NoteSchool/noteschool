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
    public partial class RegisterPage : UserControl
    {
        public EventHandler SaveButtonClick;

        public string FirstName { get { return this.inputNLabel1.Value.Trim(); } }
        public string LastName { get { return this.inputNLabel2.Value.Trim(); } }

        public RegisterPage()
        {
            InitializeComponent();

            Tag = "page";

            this.inputNLabel1.KeyUp += OnKeyEnter;
            this.inputNLabel2.KeyUp += OnKeyEnter;
        }

        private void OnKeyEnter(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Enter) == Keys.Enter)
            {
                SaveButtonClick(this, e);
            }   
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

        internal bool Validation(out List<string> inputs)
        {
            inputs = new List<string>();

            if (!String.IsNullOrWhiteSpace(FirstName)
                            && !String.IsNullOrWhiteSpace(LastName))
            {
                if (Regex.IsMatch(FirstName, @"^[\p{L}\p{M}' \.\-]+$")
                    && Regex.IsMatch(LastName, @"^[\p{L}\p{M}' \.\-]+$"))
                {
                    inputs.Add(FirstName);
                    inputs.Add(LastName);

                    return true;
                }
            }

            return false;
        }
    }
}
