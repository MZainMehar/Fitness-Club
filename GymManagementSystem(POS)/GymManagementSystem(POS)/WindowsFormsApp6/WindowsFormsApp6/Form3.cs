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

namespace WindowsFormsApp6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.ForeColor = Color.Orange;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 20)
            {
                progressBar1.Value += 1;
                label3.Text = "Turning On Modules_ " + progressBar1.Value.ToString() + "%";


            }
            else if (progressBar1.Value >= 20 && progressBar1.Value < 50)
            {
                progressBar1.Value += 1;
                label3.Text = "Loading Modules_ " + progressBar1.Value.ToString() + "%";
            }
            else if (progressBar1.Value >= 50 && progressBar1.Value < 80)
            {
                progressBar1.Value += 1;
                label3.Text = "Connecting to Database_ " + progressBar1.Value.ToString() + "%";


            }
            else if (progressBar1.Value >= 80 && progressBar1.Value < 90)
            {
                progressBar1.Value += 1;
                label3.Text = "Connection Successful!!!_ " + progressBar1.Value.ToString() + "%";
            }
            else if (progressBar1.Value >= 90 && progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                label3.Text = "Launching Application_ " + progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                Form2 obj = new Form2();
                obj.Show();
                this.Hide();
            }
        }
    }
}
