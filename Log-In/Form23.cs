using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Log_In
{
    public partial class Form23 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public string Email { get; set; }
        public string TotalPriceToPass { get; set; }
        int customerID;
        public Form23()
        {
            InitializeComponent();
        }
        public Form23(string Email)
        {
            InitializeComponent();
            this.Email = Email;
            this.TotalPriceToPass = TotalPriceToPass;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Successfully Purcheshed");
            this.Hide();
            Form3 f3 = new Form3(Email);
            //f22.ShowDialog();
            f3.ShowDialog();
            f3.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Form6 f6 = new Form6(Email);
            f6.ShowDialog();
            this.Close();*/
        }
    }
}
