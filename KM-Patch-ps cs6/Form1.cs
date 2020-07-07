using System;
using System.Drawing;
using System.IO;
 using System.Windows.Forms;
namespace KM_Patch_ps_cs6
{
    public partial class Form1 : Form
    {
        private bool _dragging = false;
        
        private Point _start_point = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (IntPtr.Size == 4)
            {
                label2.Text = "CPU: 32 bit";
                pictureBox3.Enabled = false;
                pictureBox3.Cursor = Cursors.No;
            }
            else if (IntPtr.Size == 8)
            {
                label2.Text = "CPU: 64 bit";
            }

            label3.Text ="Name: " + System.Environment.MachineName;
            label4.Text = "Time: " + DateTime.Now.ToString("h:mm:ss tt");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if ( IntPtr.Size == 4)
            {
                File.WriteAllBytes(@"C:\Program Files\Adobe\Adobe Photoshop CS6\amtlib.dll", KM.Properties.Resources.amtlib);
                MessageBox.Show("Done !");
            }
            else if (IntPtr.Size == 8)
            {
                File.WriteAllBytes(@"C:\Program Files (x86)\Adobe\Adobe Photoshop CS6\amtlib.dll", KM.Properties.Resources.amtlib);
                MessageBox.Show("Done !");
            }
            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            File.WriteAllBytes(@"C:\Program Files\Adobe\Adobe Photoshop CS6 (64 Bit)\amtlib.dll", KM.Properties.Resources.amtlib1);
            MessageBox.Show("Done !");
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.MediumBlue;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.MediumBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(9, 0, 95);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(9, 0, 95);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false; 
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text =
            DateTime.Now.ToString("h:mm:ss tt");
            timer1.Enabled = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (IntPtr.Size == 4)
            {
                MessageBox.Show("you are 32-bit" + Environment.NewLine + "----------------" + Environment.NewLine + "- Click on the button 32-bit only");
            }
            else if (IntPtr.Size == 8)
            {
                MessageBox.Show("you are 64-bit" + Environment.NewLine + "----------------" + Environment.NewLine + "1- Click on the button 32-bit + 64-bit");
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Karim Elshimi" + Environment.NewLine + "----------------" + Environment.NewLine + "karimelshimi@gmail.com");
        }

        
    }
}
