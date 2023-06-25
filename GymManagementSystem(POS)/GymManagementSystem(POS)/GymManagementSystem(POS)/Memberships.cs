using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Xml.Linq;

namespace GymManagementSystem_POS_
{
    public partial class Memberships : Form
    {
        dbConncetion Con;
        public Memberships()
        {
            InitializeComponent();
            Con = new dbConncetion();
            displayMemberShips();
        }

        private void displayMemberShips()
        {
            string Query = "Select * from MemberShipsTb1";
            dataGridView1.DataSource = Con.GetData(Query);


        }
        private void Memberships_Load(object sender, EventArgs e)
        {
            guna2TextBox5.Text = Login.admin;
            Membershiplbl.BackColor =Color.FromArgb(11, 97, 133);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 97, 133);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void reset()
        {
            MNameTb.Text = "";
            CostTb.Text = "";
            MDurationTb.Text = "";
            GoalTb.Text = "";
        }
        int Key = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    string Query = "insert into MemberShipsTb1 values('{0}',{1},'{2}',{3})";
                    //string Query = "insert into CoachsTb1 (Cname,Cgen,CDOB,CPhone,CExperience,CAddress,CPass, Ccnic) values ('" + CName + "','" + Gender + "','" + dob + "','" + Phone + "'," + experience + ",'" + Add + "','" + Password + "','" + nic + "')";
                    Query = string.Format(Query, MName, Duration, Goal, Cost);
                    Con.setData(Query);
                    displayMemberShips();
                    DialogResult dialogResult = MessageBox.Show("MEMBERSHIP INSERTED !!!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            MDurationTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            GoalTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            
            
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
                    DialogResult dialogResult = MessageBox.Show("NO MEMBERSHIP SELECTED !!!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string MName = MNameTb.Text;
                        int Duration = Convert.ToInt32(MDurationTb.Text);
                        string Goal = GoalTb.Text;
                        int Cost = Convert.ToInt32(CostTb.Text);
                        string Query = "delete from MemberShipsTb1 where MShipId={0}";
                        //string Query = "insert into CoachsTb1 (Cname,Cgen,CDOB,CPhone,CExperience,CAddress,CPass, Ccnic) values ('" + CName + "','" + Gender + "','" + dob + "','" + Phone + "'," + experience + ",'" + Add + "','" + Password + "','" + nic + "')";
                        Query = string.Format(Query, Key);
                        Con.setData(Query);
                        displayMemberShips();
                        MessageBox.Show("MEMBERSHIP DELETED !!!");
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "" && Key == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    string Query = "update MemberShipsTb1 set MName='{0}',MDuration={1},MGoal='{2}',MCost={3} where MShipId={4}";
                    //string Query = "update CoachsTb1 set Cname='\" + CName + \"',Cgen='\" + Gender + \"',CDOB='\" + dob + \"',CPhone='\" + Phone + \"',CExperience=\" + experience + ,CAddress='\" + Add + \"',CPass='\" + Password + "', Ccnic='" + nic + "'";
                    Query = string.Format(Query, MName, Duration, Goal, Cost, Key);
                    Con.setData(Query);
                    displayMemberShips();
                    DialogResult dialogResult = MessageBox.Show("MEMBERSHIP INFO UPDATED !!!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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

       
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void CoachsList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void label7_Click(object sender, EventArgs e)
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
