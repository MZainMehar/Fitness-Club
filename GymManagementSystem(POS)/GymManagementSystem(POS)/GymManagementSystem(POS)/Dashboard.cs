using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem_POS_
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void memberCount()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM MembersTb1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    guna2TextBox1.Text = count.ToString();
                }
            }
        }

        private void coachCount()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM CoachsTb1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    guna2TextBox2.Text = count.ToString();
                }
            }
        }

        private void receptionistCount()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM ReceptionistTb1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    guna2TextBox4.Text = count.ToString();
                }
            }
        }

        private void membershipsCount()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM MembershipsTb1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    guna2TextBox3.Text = count.ToString();
                }
            }
        }
        private void genRandom1()
        {
            Random random1 = new Random();
            int randomNumber1 = random1.Next(40, 93);
            guna2VProgressBar1.Value = randomNumber1;
            if (guna2VProgressBar1.Value >= 50)
            {
                guna2VProgressBar1.ProgressColor = Color.Green;
                guna2VProgressBar1.ProgressColor2 = Color.Green;
                guna2VProgressBar1.ForeColor = Color.Green;
            }
            else if (guna2VProgressBar1.Value < 50)
            {
                guna2VProgressBar1.ProgressColor = Color.Yellow;
                guna2VProgressBar1.ProgressColor2 = Color.Yellow;
                guna2VProgressBar1.ForeColor = Color.Yellow;
            }
        }

            private void genRandom2()
        {
            Random random2 = new Random();
            int randomNumber2 = random2.Next(40, 83);
            guna2VProgressBar2.Value = randomNumber2;
            if (guna2VProgressBar2.Value >= 50)
            {
                guna2VProgressBar2.ProgressColor = Color.Green;
                guna2VProgressBar2.ProgressColor2 = Color.Green;
                guna2VProgressBar2.ForeColor = Color.Green;
            }
            else if (guna2VProgressBar2.Value < 50)
            {
                guna2VProgressBar2.ProgressColor = Color.Yellow;
                guna2VProgressBar2.ProgressColor2 = Color.Yellow;
                guna2VProgressBar2.ForeColor = Color.Yellow;
            }
        }

        private void genRandom3()
        {
            Random random3 = new Random();
            int randomNumber3 = random3.Next(40, 88);
            guna2VProgressBar3.Value = randomNumber3;
            if (guna2VProgressBar3.Value >= 50)
            {
                guna2VProgressBar3.ProgressColor = Color.Green;
                guna2VProgressBar3.ProgressColor2 = Color.Green;
                guna2VProgressBar3.ForeColor = Color.Green;
            }
            else if (guna2VProgressBar4.Value < 50)
            {
                guna2VProgressBar3.ProgressColor = Color.Yellow;
                guna2VProgressBar3.ProgressColor2 = Color.Yellow;
                guna2VProgressBar3.ForeColor = Color.Yellow;
            }
        }

        private void genRandom4()
        {
            Random random4 = new Random();
            int randomNumber4 = random4.Next(30, 93);
            guna2VProgressBar4.Value = randomNumber4;
            if (guna2VProgressBar4.Value >= 50)
            {
                guna2VProgressBar4.ProgressColor = Color.Green;
                guna2VProgressBar4.ProgressColor2 = Color.Green;
                guna2VProgressBar4.ForeColor = Color.Green;
            }
            else if (guna2VProgressBar4.Value < 50)
            {
                guna2VProgressBar4.ProgressColor = Color.Yellow;
                guna2VProgressBar4.ProgressColor2 = Color.Yellow;
                guna2VProgressBar4.ForeColor = Color.Yellow;
            }
        }

        private void genRandom5()
        {
            Random random5 = new Random();
            int randomNumber5 = random5.Next(30, 99);
            guna2VProgressBar5.Value = randomNumber5;
            if (guna2VProgressBar5.Value >= 50)
            {
                guna2VProgressBar5.ProgressColor = Color.Green;
                guna2VProgressBar5.ProgressColor2 = Color.Green;
                guna2VProgressBar5.ForeColor = Color.Green;
            }
            else if (guna2VProgressBar5.Value < 50)
            {
                guna2VProgressBar5.ProgressColor = Color.Yellow;
                guna2VProgressBar5.ProgressColor2 = Color.Yellow;
                guna2VProgressBar5.ForeColor = Color.Yellow;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            guna2TextBox1.TabStop = false;
            guna2TextBox2.TabStop = false;
            guna2TextBox3.TabStop = false;
            guna2TextBox5.TabStop = false;
            guna2TextBox5.Text=Login.admin;
            memberCount();
            coachCount();
            receptionistCount();
            membershipsCount();
            genRandom1();
            genRandom2();
            genRandom3();
            genRandom4();
            genRandom5();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Coachlbl_Click(object sender, EventArgs e)
        {
            Coach obj = new Coach();
            obj.Show();
            this.Close();
        }

        private void Memberlbl_Click(object sender, EventArgs e)
        {
            Members obj = new Members();
            obj.Show();
            this.Close();
        }

        private void Membershipslbl_Click(object sender, EventArgs e)
        {
            Memberships obj = new Memberships();
            obj.Show();
            this.Close();
        }

        private void Receptionistlbl_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Close();
        }

        private void Billinglbl_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO LOGOUT ?", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Show();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Coach obj = new Coach();
            obj.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Members obj = new Members();
            obj.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Memberships obj = new Memberships();
            obj.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.Text = guna2TextBox5.Text.ToUpper();
        }
    }
}
