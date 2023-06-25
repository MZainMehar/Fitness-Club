using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        StudentTable model = new StudentTable();
        AddressTable model1 = new AddressTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            model.Id = 0;
            model1.Id = 0;
            populateDataGridView();
        }
        private void Reset()
        {
            fnameTb.Text = ("");
            lnameTb.Text = ("");
            emailTb.Text = ("");
            phoneTb.Text = ("");
            streetTb.Text = ("");
            cityTb.Text = ("");
            stateTb.Text = ("");
            zipTb.Text = ("");

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (fnameTb.Text == "" || lnameTb.Text == "" || emailTb.Text == "" || phoneTb.Text == "" || streetTb.Text == "" || cityTb.Text == "" || stateTb.Text == "" || zipTb.Text == "")
            {
                MessageBox.Show("MISSING CREDENTIALS!");
            }
            else
            {


                model.FirstName = fnameTb.Text.Trim();
                model.LastName = lnameTb.Text.Trim();
                model.Email = emailTb.Text.Trim();
                model.Phone = phoneTb.Text.Trim();
                model1.Street = streetTb.Text.Trim();
                model1.City = cityTb.Text.Trim();
                model1.State = stateTb.Text.Trim();
                model1.ZipCode = zipTb.Text.Trim();

                using (DBEntities1 db = new DBEntities1())
                {
                    db.StudentTables.Add(model);
                    db.AddressTables.Add(model1);
                    db.SaveChanges();

                }
                Reset();
                populateDataGridView();
                MessageBox.Show("RECORD ENTERED SUCCESSFULLY");
            }
        }
        void populateDataGridView()
        {
            using (DBEntities1 db = new DBEntities1())
            {
                dataGridView1.DataSource = db.StudentTables.ToList<StudentTable>();
                dataGridView2.DataSource = db.AddressTables.ToList<AddressTable>();

            }
        }
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (fnameTb.Text == "" || lnameTb.Text == "" || emailTb.Text == "" || phoneTb.Text == "" || streetTb.Text == "" || cityTb.Text == "" || stateTb.Text == "" || zipTb.Text == "")
            {
                MessageBox.Show("MISSING CREDENTIALS!");
            }
            else
            {
                model.FirstName = fnameTb.Text.Trim();
                model.LastName = lnameTb.Text.Trim();
                model.Email = emailTb.Text.Trim();
                model.Phone = phoneTb.Text.Trim();
                model1.Street = streetTb.Text.Trim();
                model1.City = cityTb.Text.Trim();
                model1.State = stateTb.Text.Trim();
                model1.ZipCode = zipTb.Text.Trim();
                using (DBEntities1 db = new DBEntities1())
                {
                    if (model.Id == 0 && model1.Id == 0)
                    {
                        db.StudentTables.Add(model);
                        db.AddressTables.Add(model1);
                    }
                    else
                    {
                        db.Entry(model).State = EntityState.Modified;
                        db.Entry(model1).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                Reset();
                populateDataGridView();
                MessageBox.Show("RECORD UPDATED SUCCESSFULLY");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (fnameTb.Text == "" || lnameTb.Text == "" || emailTb.Text == "" || phoneTb.Text == "" || streetTb.Text == "" || cityTb.Text == "" || stateTb.Text == "" || zipTb.Text == "")
            {
                MessageBox.Show("MISSING CREDENTIALS!");
            }
            else
            {
                using (DBEntities1 db = new DBEntities1())
                {
                    var entry = db.Entry(model);
                    var entry1 = db.Entry(model1);
                    if (entry.State == EntityState.Detached && entry1.State == EntityState.Detached)
                    {
                        db.StudentTables.Attach(model);
                        db.AddressTables.Attach(model1);
                    }
                    db.StudentTables.Remove(model);
                    db.AddressTables.Remove(model1);
                    db.SaveChanges();
                    populateDataGridView();
                    Reset();
                    MessageBox.Show("RECORD DELETED SUCCESSFULLY");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fnameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            lnameTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            emailTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            phoneTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();


            model.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            using (DBEntities1 db = new DBEntities1())
            {
                model = db.StudentTables.Where(x => x.Id == model.Id).FirstOrDefault();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            streetTb.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            cityTb.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            stateTb.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            zipTb.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            model1.Id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            using (DBEntities1 db = new DBEntities1())
            {
                model1 = db.AddressTables.Where(x => x.Id == model1.Id).FirstOrDefault();
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            using (DBEntities1 db = new DBEntities1())
            {
                /*if(checkBox1.Checked)
                {
                    dataGridView1.DataSource = db.StudentTables.Where(x => x.Id.ToString().Contains(searchTb.Text)).ToList();
                }
                else
                dataGridView1.DataSource = db.StudentTables.Where(x => x.FirstName.Contains(searchTb.Text)).ToList();
                */
                if(comboBox1.SelectedIndex==0)
                {
                    //label12.Text = "FNAME";
                    dataGridView1.DataSource = db.StudentTables.Where(x => x.FirstName.Contains(searchTb.Text)).ToList();

                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    //label12.Text = "ID";
                    dataGridView1.DataSource = db.StudentTables.Where(x => x.Id.ToString().Contains(searchTb.Text)).ToList();
                    dataGridView2.DataSource = db.AddressTables.Where(x => x.Id.ToString().Contains(searchTb.Text)).ToList();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                searchTb.Text = "";
                label12.Text = "Fname";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                searchTb.Text = "";
                label12.Text = "ID";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }
    }
}

    