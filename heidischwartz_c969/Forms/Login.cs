using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heidischwartz_c969.Forms
{
    public partial class Login : Form
    {

        private TextBox txtBox = new TextBox();

        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            //hardcoded values for evaluation just for fun :)
            MessageBox.Show("Username: test\nPassword: test");
        }
    }
}
