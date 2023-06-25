using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;

namespace GymManagementSystem_POS_
{
    public partial class Billing : Form
    {
        dbConncetion Con;
        public Billing()
        {
            InitializeComponent();
            Con = new dbConncetion();
            displayBillings();
            getMembers();
            reset();
        }
        private void displayBillings()
        {
            string Query = "Select * from FinanceTb1";
            dataGridView1.DataSource = Con.GetData(Query);
        }
        private void Receptionistlbl_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void Membershipslbl_Click(object sender, EventArgs e)
        {
            Memberships obj = new Memberships();
            obj.Show();
            this.Hide();
        }

        private void Memberlbl_Click(object sender, EventArgs e)
        {
            Members obj = new Members();
            obj.Show();
            this.Hide();
        }

        private void Coachlbl_Click(object sender, EventArgs e)
        {
            Coach obj = new Coach();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
        private void getMembers()
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("select * from MembersTb1", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Member = reader["MName"].ToString();
                            MemberTb.Items.Add(Member);
                        }
                    }
                }
            }
        }
        private void checkForNill()
        {
            string name = MemberTb.SelectedItem.ToString();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                    string query = "SELECT MMembership FROM MembersTb1 WHERE MName = @name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", MemberTb.SelectedItem.ToString());
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string membership = reader["MMembership"].ToString();
                                if (membership == "Nill")
                                {
                                    amountTb.Text = "";
                                    amountTb.ReadOnly = false;
                                }
                            }
                        }
                    }
            }
        }


       
        private void displayPrice()
        {
            string memberName = MemberTb.SelectedItem.ToString();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                //Fetch the membership ID for the selected member
                string query1 = "SELECT MShipId FROM MembersTb1 WHERE MName = @memberName";
                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@memberName", memberName);
                int membershipID = (int)command1.ExecuteScalar();

                //Fetch the price of the membership
                string query2 = "SELECT MCost FROM MemberShipsTb1 WHERE MShipId = @membershipID";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@membershipID", membershipID);
                int price = (int)command2.ExecuteScalar();
                if (price == 0)
                {
                    amountTb.Text = "";
                }
                else
                {
                    // set amountTb Text
                    amountTb.Text = price.ToString();
                    amountTb.ReadOnly=true;
                }
                
            }
        }
        private void reset()
        {
            amountTb.Text = "";
            MemberTb.SelectedIndex = -1;
            StatusTb.SelectedIndex = -1;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.Id == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("LOGIN FIRST !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (MemberTb.SelectedIndex == -1 || amountTb.Text == "" || StatusTb.SelectedIndex == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    int agent = Login.Id;
                    string Recep = Login.admin.ToString();
                    string Member = MemberTb.SelectedItem.ToString();
                    string Period = PTb.Value.Date.ToString(("dd/MM/yyyy"));
                    string Billing = BDOBTb.Value.Date.ToString(("yyyy-MM-dd"));

                    string amount = amountTb.Text;
                    string Query = "insert into FinanceTb1 values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Recep, Member, Period, Billing, amount);
                    Con.setData(Query);
                    updateStatus();
                    displayBillings();
                    DialogResult dialogResult = MessageBox.Show("BILLING INSERTED !!!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Billing_Load(object sender, EventArgs e)
        {
            amountTb.ReadOnly = true;
            guna2TextBox5.Text = Login.admin;
            Billinglbl.BackColor = Color.FromArgb(248, 84, 50);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(174, 59, 34);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            amountTb.Text = "";
            MemberTb.SelectedIndex = -1;
            StatusTb.SelectedIndex = -1;
        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
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

        private void PTb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CoachsList_Paint(object sender, PaintEventArgs e)
        {

        }
        private void updateStatus()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                string status = StatusTb.SelectedItem.ToString();
                string Member = MemberTb.SelectedItem.ToString();
                string updateSql = $"update MembersTb1 set MStatus = '{status}' where MName = '{Member}'";
                using (SqlCommand cmd = new SqlCommand(updateSql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void StatusTb_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.Text = guna2TextBox5.Text.ToUpper();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void MemberTb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MemberTb.SelectedIndex!=-1)
            {
                checkForNill();
                displayPrice();
            }
        }
    }
}