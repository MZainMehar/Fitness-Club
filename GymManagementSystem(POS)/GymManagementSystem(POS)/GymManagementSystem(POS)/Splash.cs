using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace GymManagementSystem_POS_
{
    public partial class Splash : Form
    {
    
        public Splash()
        {
            InitializeComponent();
        }
        private void Loadingpage_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value < 20)
            {
                 guna2CircleProgressBar1.Value += 1;
                
                label3.Text = "Turning On Modules_ ";


            }
            else if ( guna2CircleProgressBar1.Value >= 20 &&  guna2CircleProgressBar1.Value < 50)
            {
                 guna2CircleProgressBar1.Value += 1;
                
                label3.Text = "Loading Modules_ ";
            }
            else if ( guna2CircleProgressBar1.Value >= 50 &&  guna2CircleProgressBar1.Value < 80)
            {
                 guna2CircleProgressBar1.Value += 1;
                 label3.Text = "Connecting to Database_ ";


            }
            else if ( guna2CircleProgressBar1.Value >= 80 &&  guna2CircleProgressBar1.Value < 90)
            {
                 guna2CircleProgressBar1.Value += 1;
                 label3.Text = "Connection Successful!!!_ ";
            }
            else if ( guna2CircleProgressBar1.Value >= 90 &&  guna2CircleProgressBar1.Value < 99)
            {
                 guna2CircleProgressBar1.Value += 1;
                label3.Text = "Launching Application_ ";
            }
            else
            {
                timer1.Stop();
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
