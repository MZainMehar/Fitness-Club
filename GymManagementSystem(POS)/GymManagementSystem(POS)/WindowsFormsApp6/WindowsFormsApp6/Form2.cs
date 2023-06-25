using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            passwordtb.UseSystemPasswordChar = true;
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (usernametb.Text == "" || passwordtb.Text == "")
            {
                MessageBox.Show("PLEASE ENTER USERNAME OR PASSWORD");
            }
            else if(usernametb.Text=="admin"&&passwordtb.Text == "pass") {
                Form1 obj= new Form1();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("INVALID USER");
            }
        }

        private void usernametb_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(usernametb.Text))
            {
                e.Cancel = true;
                usernametb.Focus();
                errorProvider1.SetError(usernametb, "This field is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(usernametb, null);
            }
        }

        private void passwordtb_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordtb.Text))
            {
                e.Cancel = true;
                passwordtb.Focus();
                errorProvider1.SetError(passwordtb, "This field is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(passwordtb, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordtb.UseSystemPasswordChar = false;
            }
            else
            {
                passwordtb.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
