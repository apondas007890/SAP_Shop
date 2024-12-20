using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using Microsoft.Win32;
using System.DirectoryServices.ActiveDirectory;
using System.IO;

namespace Log_In
{
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox5.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox5.UseSystemPasswordChar = true;
                    break;


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form14 f14 = new Form14();
            f14.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""  || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || !checkBox3.Checked || dateTimePicker1.Value == null)
            {
                MessageBox.Show("Please fulfill the requirements!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                
                string registerType = comboBox2.Text;
                string query;
                SqlCommand cmd;
                SqlConnection con = new SqlConnection(cs);
                con.Open();

                if (registerType == "Business Account")
                {
                    string enteredEmail = textBox3.Text;
                    if (!enteredEmail.EndsWith("@gmail.com"))  
                    {
                        MessageBox.Show("Please use a Gmail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    query = "SELECT COUNT(*) FROM SAP_Seller_Login_Data WHERE Email = @email";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", enteredEmail);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Email address already exists. Please use a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    query = "INSERT INTO SAP_Seller_Login_Data (ProfilePicture,FirstName, LastName, Email, PhoneNumber, Gender, DateOfBirth,RegisterType, Password) VALUES (@pic,@first, @last, @email, @phone, @gender, @dateOfBirth,@register, @createPass);";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@pic", SavePhoto());
                    cmd.Parameters.AddWithValue("@first", textBox1.Text);
                    cmd.Parameters.AddWithValue("@last", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@register", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@createPass", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    string enteredEmail = textBox3.Text;
                    if (!enteredEmail.EndsWith("@gmail.com"))
                    {
                        MessageBox.Show("Please use a Gmail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    query = "SELECT COUNT(*) FROM SAP_Customer_Login_Data WHERE Email = @email";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", enteredEmail);
                    int count = (int)cmd.ExecuteScalar();


                    if (count > 0)
                    {
                        MessageBox.Show("Email address already exists. Please use a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    query = "insert into SAP_Customer_Login_Data(ProfilePicture,FirstName, LastName, Email, PhoneNumber, Gender, DateOfBirth, RegisterType, Password ) values(@pic,@first, @last, @email, @phone, @gender, @dateOfBirth, @register, @createPass);";
                    //"INSERT INTO SAP_Login_Data VALUES(@first, @last, @email, @phone, @gender,  @dateOfBirth, @register, @createPass);";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@pic", SavePhoto());
                    cmd.Parameters.AddWithValue("@first", textBox1.Text);
                    cmd.Parameters.AddWithValue("@last", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@register", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@createPass", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();

            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}