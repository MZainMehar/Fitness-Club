using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GymManagementSystem_POS_
{
    public partial class Coach : Form
    {
        dbConncetion Con;
        public Coach()
        {
            InitializeComponent();
            Con = new dbConncetion();
            displayCoach();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2TextBox5.Text = Login.admin;
            Coachlbl.BackColor = Color.FromArgb(200, 210, 86);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(141, 148, 59 );
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void displayCoach()
        {
            string Query = "Select * from CoachsTb1";
            dataGridView1.DataSource = Con.GetData(Query);


        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChNameTb.Text == "" || PhoneTb.Text == "" || ExpTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || GenTb.SelectedIndex == -1 || CnicTb.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                string password = PassTb.Text;

                if (password.All(char.IsLetterOrDigit))
                {
                    MessageBox.Show("Weak password. Please use a combination of letters, numbers and special characters.");
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string nic = CnicTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query= "insert into CoachsTb1 values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}')";
                    //string Query = "insert into CoachsTb1 (Cname,Cgen,CDOB,CPhone,CExperience,CAddress,CPass, Ccnic) values ('" + CName + "','" + Gender + "','" + dob + "','" + Phone + "'," + experience + ",'" + Add + "','" + Password + "','" + nic + "')";
                    Query = string.Format(Query, CName, Gender, dob, Phone, experience, Add, Password,nic);
                    Con.setData(Query);
                    displayCoach();
                    DialogResult dialogResult = MessageBox.Show("COACH INSERTED !!!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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

                        string CName = ChNameTb.Text;
                        string Gender = GenTb.SelectedItem.ToString();
                        string Phone = PhoneTb.Text;
                        string nic = CnicTb.Text;
                        int experience = Convert.ToInt32(ExpTb.Text);
                        string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                        string Add = AddTb.Text;
                        string Password = PassTb.Text;
                        string Query = "delete from CoachsTb1 where Cid={0}";
                        //string Query = "update CoachsTb1 set Cname='" + CName + "',Cgen='" + Gender + "',CDOB='" + dob + "',CPhone='" + Phone + "',CExperience=" + experience + ",CAddress='" + Add + "',CPass='" + Password + "', Ccnic='" + nic + "'  where Cid=17)";
                        Query = string.Format(Query, Key);
                        Con.setData(Query);
                        displayCoach();
                        MessageBox.Show("COACH DELETED !!!");
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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        int Key = 0;
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            GenTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            ExpTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            AddTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            PassTb.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            CnicTb.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            if (ChNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }

           
            

        }
        private void reset()
        {
            ChNameTb.Text = "";
            PhoneTb.Text = "";
            ExpTb.Text = "";
            AddTb.Text = "";
            PassTb.Text = "";
            GenTb.Text = "";
            CnicTb.Text = "";
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChNameTb.Text == "" || PhoneTb.Text == "" || ExpTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || GenTb.SelectedIndex == -1 || CnicTb.Text == "" && Key==0)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string nic = CnicTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "update CoachsTb1 set CName='{0}',CGen='{1}',CDOB='{2}',CPhone='{3}',CExperience={4},CAddress='{5}',CPass='{6}',Ccnic='{7}' where Cid={8}";
                    //string Query = "update CoachsTb1 set Cname='\" + CName + \"',Cgen='\" + Gender + \"',CDOB='\" + dob + \"',CPhone='\" + Phone + \"',CExperience=\" + experience + ,CAddress='\" + Add + \"',CPass='\" + Password + "', Ccnic='" + nic + "'";
                    Query = string.Format(Query, CName, Gender, dob, Phone, experience, Add, Password, nic, Key);
                    //string Query = "update CoachsTb1 set Cname='"+CName+ "',Cgen='"+Gender+ "',CDOB='"+dob+ "',CPhone='"+Phone+ "',CExperience="+experience+ ",CAddress='"+Add+ "',CPass='"+Password+ "', Ccnic='"+nic+"'";
                    Con.setData(Query);
                    displayCoach();
                    DialogResult dialogResult = MessageBox.Show("COACH INFO UPDATED !!!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

                
              
        private void Coachlbl_Click(object sender, EventArgs e)
        {

        }

        private void Memberlbl_Click(object sender, EventArgs e)
        {
            Members obj = new Members();
            obj.Show();
            this.Hide();
        }

        private void Membershipslbl_Click(object sender, EventArgs e)
        {
            Memberships obj = new Memberships();
            obj.Show();
            this.Hide();
        }

        private void Receptionistlbl_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void Billinglbl_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void label11_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.Text = guna2TextBox5.Text.ToUpper();
        }

        private void CnicTb_MouseClick(object sender, MouseEventArgs e)
        {
            CnicTb.SelectionStart = 0;
        }
    } 
}
