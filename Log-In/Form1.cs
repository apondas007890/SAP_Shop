using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Log_In
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;

                    // Check customer login first
                    cmd.CommandText = "select * from SAP_Customer_Login_Data where Email=@email and Password = @createPass";
                    cmd.Parameters.AddWithValue("@email", textBox1.Text);
                    cmd.Parameters.AddWithValue("@createPass", textBox2.Text);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string register = (string)dr["RegisterType"];
                                if (register == "Personal Account")
                                {
                                    string Email = textBox1.Text;
                                    this.Hide();
                                    Form3 f3 = new Form3(Email);
                                    f3.ShowDialog();
                                    this.Close();
                                    return; 
                                }
                            }
                        }
                    }

                    
                    cmd.CommandText = "select * from SAP_Seller_Login_Data where Email=@email and Password = @createPass";
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string register = (string)dr["RegisterType"];
                                if (register == "Business Account")
                                {
                                    string Email = textBox1.Text;
                                    this.Hide();
                                    Form16 f16 = new Form16(Email);
                                    f16.ShowDialog();
                                    this.Close();
                                    return; 
                                }
                            }
                        }
                    }

                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Enter Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            f2.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox1, "Please Enter Username");
                
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }*/
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;


            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(textBox2.Text))
            {
                
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Please Enter Password");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }*/
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Your Email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            f18.Close();
        }
    }
}
