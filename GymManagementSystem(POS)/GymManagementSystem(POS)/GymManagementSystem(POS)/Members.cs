using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace GymManagementSystem_POS_
{
    public partial class Members : Form
    {
        dbConncetion Con;
        public Members()
        {
            InitializeComponent();
            Con = new dbConncetion();
            displayMembers();
            getCoaches();
            getMemberships();
            reset();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            guna2TextBox5.Text = Login.admin;
            Memberlbl.BackColor = Color.FromArgb(255, 152, 0);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(186, 106, 0);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void displayMembers()
        {
            string Query = "Select * from MembersTb1";
            dataGridView1.DataSource = Con.GetData(Query);
        }
       
        private void reset()
        {
            MNameTb.Text = "";
            GenTb.SelectedIndex = -1;
            MShipTb.Text="";
            CoachTb.Text = "";
            MShipTb.SelectedIndex = -1;
            CoachTb.SelectedIndex=-1;
            PhoneTb.Text = "";
            TimingsTb.SelectedIndex = -1;
            StatusTb.SelectedIndex = -1;

        }
       
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void getCoaches()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("select * from CoachsTb1", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string coach = reader["Cname"].ToString();
                            CoachTb.Items.Add(coach);
                        }
                    }
                }
            }
        }
        private void getMemberships()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("select * from MemberShipsTb1", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Memberships = reader["MName"].ToString();
                            MShipTb.Items.Add(Memberships);
                        }
                    }
                }
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || GenTb.SelectedIndex == -1 || MShipTb.SelectedIndex == -1 || PhoneTb.Text == "" || TimingsTb.SelectedIndex == -1 || StatusTb.SelectedIndex == -1 || CoachTb.SelectedIndex == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenTb.SelectedItem.ToString();
                    string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                    string jdob = JDTb.Value.Date.ToString(("yyyy-MM-dd"));
                    int MShipId = GetMShipId(MShipTb.SelectedItem.ToString()); //Getting the MShipId from the selected membership in combobox
                    string MMembership= MShipTb.SelectedItem.ToString();
                    string MCoach = CoachTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Mtiming = TimingsTb.SelectedItem.ToString();
                    string MStatus = StatusTb.SelectedItem.ToString();
                    string Query = "insert into MembersTb1 (MShipId,MName, MGen, MDOB, MJDate, MMembership, MCoach, MPhone, MTimings, MStatus) values({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                    Query = string.Format(Query,MShipId, MName, Gender, dob, jdob, MMembership, MCoach, Phone, Mtiming, MStatus);
                    Con.setData(Query);
                    displayMembers();
                    DialogResult dialogResult = MessageBox.Show("MEMBER INSERTED !!!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
            private int GetMShipId(string MShip)
            {
                int MShipId = 0;
                string Query = "SELECT MShipId FROM MemberShipsTb1 WHERE MName='" + MShip + "'";
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count > 0)
                {
                    MShipId = int.Parse(dt.Rows[0]["MShipId"].ToString());
                }
                return MShipId;
            }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || GenTb.SelectedIndex == -1 || MShipTb.SelectedIndex == -1 || PhoneTb.Text == "" || TimingsTb.SelectedIndex == -1 || StatusTb.SelectedIndex == -1 || CoachTb.SelectedIndex == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenTb.SelectedItem.ToString();
                    string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                    string jdob = JDTb.Value.Date.ToString(("yyyy-MM-dd"));
                    int MShipId = GetMShipId(MShipTb.SelectedItem.ToString()); //Getting the MShipId from the selected membership in combobox
                    string MMembership = MShipTb.SelectedItem.ToString();
                    string MCoach = CoachTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Mtiming = TimingsTb.SelectedItem.ToString();
                    string MStatus = StatusTb.SelectedItem.ToString();
                    string Query = "update MembersTb1 set MShipId={0},MName='{1}',MGen='{2}',MDOB='{3}',MJDate='{4}',MMembership='{5}',MCoach='{6}',MPhone='{7}',MTimings='{8}',MStatus='{9}' where MId={10}";
                    Query = string.Format(Query, MShipId, MName, Gender, dob, jdob, MMembership, MCoach, Phone, Mtiming, MStatus, Key);
                    Con.setData(Query);
                    displayMembers();
                    DialogResult dialogResult = MessageBox.Show("MEMBER UPDATED !!!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MNameTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            GenTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            JDTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            MShipTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            CoachTb.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            PhoneTb.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            TimingsTb.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            StatusTb.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();


            if (MNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("NO COACH SELECTED !!!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string Query = "delete from MembersTb1 where MId={0}";
                        Query = string.Format(Query, Key);
                        Con.setData(Query);
                        displayMembers();
                        MessageBox.Show("MEMBER DELETED !!!");
                        reset();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        reset();
                    }


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }


        private void Coachlbl_Click(object sender, EventArgs e)
        {
            Coach obj = new Coach();
            obj.Show();
            this.Hide();
        }

        private void Membershipslbl_Click(object sender, EventArgs e)
        {
            Memberships obj=new Memberships();
            obj.Show();
            this.Hide();
        }

        private void Billinglbl_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        private void Receptionistlbl_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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

        private void CoachsList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            if (searchTb.Text == "")
            {
                displayMembers();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell Inc\Documents\FitnessDataBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT * FROM MembersTb1 WHERE MName LIKE '%" + searchTb.Text + "%'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }


        }

        private void searchTb_MouseClick(object sender, MouseEventArgs e)
        {
            searchTb.Text = "";
            displayMembers();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.Text = guna2TextBox5.Text.ToUpper();
        }
    }
}
