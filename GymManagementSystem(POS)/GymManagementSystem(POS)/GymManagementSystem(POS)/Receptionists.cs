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

namespace GymManagementSystem_POS_
{
    public partial class Receptionists : Form
    {
        dbConncetion Con;
        public Receptionists()
        {
            InitializeComponent();
            Con = new dbConncetion();
            displayReceptionist();
        }
        private void displayReceptionist()
        {
            string Query = "Select * from ReceptionistTb1";
            dataGridView1.DataSource = Con.GetData(Query);


        }
        private void reset()
        {
            RecepNameTb.Text = "";
            PhoneTb.Text = "";
            AddTb.Text = "";
            PassTb.Text = "";
            GenTb.Text = "";
            
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || GenTb.SelectedIndex == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string RecepName = RecepNameTb.Text;
                    string Gender = GenTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "insert into ReceptionistTb1 values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    //string Query = "insert into CoachsTb1 (Cname,Cgen,CDOB,CPhone,CExperience,CAddress,CPass, Ccnic) values ('" + CName + "','" + Gender + "','" + dob + "','" + Phone + "'," + experience + ",'" + Add + "','" + Password + "','" + nic + "')";
                    Query = string.Format(Query, RecepName, Gender, dob, Add,Phone, Password);
                    Con.setData(Query);
                    displayReceptionist();
                    DialogResult dialogResult = MessageBox.Show("RECEPTIONIST INSERTED !!!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            RecepNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            GenTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            AddTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            PhoneTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            PassTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            
            if (RecepNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Receptionists_Load(object sender, EventArgs e)
        {
            guna2TextBox5.Text = Login.admin;
            Receptionistlbl.BackColor=Color.FromArgb(246, 116, 110);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(175, 80, 76);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("NO RECEPTIONIST SELECTED !!!!", "WARNING !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string RecepName = RecepNameTb.Text;
                        string Gender = GenTb.SelectedItem.ToString();
                        string Phone = PhoneTb.Text;
                        string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                        string Add = AddTb.Text;
                        string Password = PassTb.Text;
                        string Query = "delete from ReceptionistTb1 where ReceptId={0}";
                        //string Query = "update CoachsTb1 set Cname='" + CName + "',Cgen='" + Gender + "',CDOB='" + dob + "',CPhone='" + Phone + "',CExperience=" + experience + ",CAddress='" + Add + "',CPass='" + Password + "', Ccnic='" + nic + "'  where Cid=17)";
                        Query = string.Format(Query, Key);
                        Con.setData(Query);
                        displayReceptionist();
                        MessageBox.Show("RECEPTIONIST DELETED !!!");
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
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || GenTb.SelectedIndex == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("MISSING DETAILS !!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string RecepName = RecepNameTb.Text;
                    string Gender = GenTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string dob = DOBTb.Value.Date.ToString(("yyyy-MM-dd"));
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "update ReceptionistTb1 set RecepName='{0}',RecepGen='{1}',RecepDOB='{2}',RecepAdd='{3}',RecepPhone='{4}',RecepPass='{5}' where ReceptId={6}";
                    //string Query = "update CoachsTb1 set Cname='\" + CName + \"',Cgen='\" + Gender + \"',CDOB='\" + dob + \"',CPhone='\" + Phone + \"',CExperience=\" + experience + ,CAddress='\" + Add + \"',CPass='\" + Password + "', Ccnic='" + nic + "'";
                    Query = string.Format(Query, RecepName, Gender, dob, Add, Phone, Password, Key);
                    //string Query = "update CoachsTb1 set Cname='"+CName+ "',Cgen='"+Gender+ "',CDOB='"+dob+ "',CPhone='"+Phone+ "',CExperience="+experience+ ",CAddress='"+Add+ "',CPass='"+Password+ "', Ccnic='"+nic+"'";
                    Con.setData(Query);
                    displayReceptionist();
                    DialogResult dialogResult = MessageBox.Show("RECEPTIONIST INFO UPDATED !!!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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

                
        private void Coachlbl_Click(object sender, EventArgs e)
        {
            Coach obj = new Coach();
            obj.Show();
            this.Hide();
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

        private void Billinglbl_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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
