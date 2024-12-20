using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_In
{
    public partial class Form3 : Form
    {
        bool sidebarExpand;
        public string Email { get; set; }

        public Form3(string Email)
        {
            InitializeComponent();
            this.Email = Email;
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void sidebartimer_Tick(object sender, EventArgs e)
        {
            /*if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebartimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebartimer.Stop();
                }
            }*/

        }

        private void Menubar_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Hom_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();
            f13.Close();
        }

        private void circularPictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5(Email);
            f5.BindGridView();
            f5.ShowDialog();
            f5.Close();
        }

        private void circularPictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.BindGridView();
            f7.ShowDialog();
            f7.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void circularPictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.BindGridView();
            f8.ShowDialog();
            f8.Close();
        }

        private void circularPictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.BindGridView();
            f9.ShowDialog();
            f9.Close();
        }

        private void circularPictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f21 = new Form21();
            f21.BindGridView();
            f21.ShowDialog();
            f21.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            f1.Close();
        }

        private void sidebartimer1_Tick(object sender, EventArgs e)
        {
            /*if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebartimer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebartimer1.Stop();
                }
            }*/
        }

        private void menubar_Click_1(object sender, EventArgs e)
        {
            //sidebartimer1.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            f1.Close();
        }

        private void circularPictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form22 f22 = new Form22();
            //f22.ShowDialog();
            f22.ShowDialog();
            f22.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            //f22.ShowDialog();
            f6.ShowDialog();
            f6.Close();
        }
    }
}
