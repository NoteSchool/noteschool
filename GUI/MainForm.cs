using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private RegisterForm RegisterForm1;

        public MainForm()
        {
            InitializeComponent();

            RegisterForm1 = new GUI.RegisterForm();

            //Add register's user control
            Register();

        }
    }
}
