using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymManagementSystem_POS_
{
    public partial class Login : Form
    {
        dbConncetion Con;
        public Login()
        {
            InitializeComponent();
            Con= new dbConncetion();
            
        }
        public static int Id;
        public static string admin;
        private void guestlbl_Click(object sender, EventArgs e)
        {
            admin = "Guest User!";
            Dashboard obj= new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            passwordtb.UseSystemPasswordChar = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO LEAVE ?", "LEAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                passwordtb.UseSystemPasswordChar = false;
            }
            else
            {
                passwordtb.UseSystemPasswordChar = true;
            }
        }

        private void usernametb_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(usernametb.Text))
            {
                e.Cancel = true;
                usernametb.Focus();
                errorProvider1.SetError(usernametb, "This field is required.");
            }
            else
            {
                e.Cancel=false;
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (usernametb.Text == "" && passwordtb.Text == "")
            {
                {
                    DialogResult dialogResult = MessageBox.Show("USER NAME & PASSWORD CAN'T BE EMPTY", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

            else if (usernametb.Text == String.Empty )
            {
                DialogResult dialogResult = MessageBox.Show("USER NAME CAN'T BE EMPTY", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if(passwordtb.Text == "")
            {
                {
                    DialogResult dialogResult = MessageBox.Show("PASSWORD CAN'T BE EMPTY", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            
            else
            {
                try
                {
                    string Query = "Select * from ReceptionistTb1 where RecepName='{0}' and RecepPass='{1}'";
                    Query = string.Format(Query, usernametb.Text, passwordtb.Text);
                    DataTable dt = Con.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("INVALID CREDENTIALS", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (dialogResult == DialogResult.Retry)
                        {
                            usernametb.Text = "";
                            passwordtb.Text = "";
                            this.Show();
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                        admin = dt.Rows[0][1].ToString();
                        Dashboard obj = new Dashboard();
                        obj.Show();
                        this.Hide();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
