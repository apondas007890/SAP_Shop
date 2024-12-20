using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_In
{
    public partial class Form6 : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public string Email { get; set; }
        int customerID;
        
        public Form6()
        {
            InitializeComponent();
            BindGridView();
        }

        public Form6(string Email)
        {
            InitializeComponent();
            this.Email = Email;
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT ID FROM SAP_Customer_Login_Data WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", Email);
            con.Open();
            customerID = (int)cmd.ExecuteScalar();
        }
        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            
            /*int productID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            SqlConnection con = new SqlConnection(cs);

            int Price = Convert.ToInt32(textBox3.Text);
            int Quantity = Convert.ToInt32(numericUpDown1.Value);

            
            string query = "SELECT Quantity FROM SAP_Products_List WHERE ProductID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", productID);  

            int existingQuantity = 0;
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    existingQuantity = reader.GetInt32(0);
                }
            }

            
            if (Quantity <= existingQuantity)
            {
                query = "UPDATE SAP_Products_List SET Quantity=@P_quantity WHERE ProductID=@id";
                cmd.CommandText = query;
                cmd.Parameters.Clear();  
                cmd.Parameters.AddWithValue("@P_quantity", Quantity);
                cmd.Parameters.AddWithValue("@id", productID);

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //MessageBox.Show("Data Updated Successfully");
                    BindGridView();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data Not Updated");
                }
            }
            else
            {
                MessageBox.Show("Invalid quantity. Please enter a quantity less than or equal to the existing quantity.");
            }

            con.Close();*/

        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select ProductID,ProductPic, ProductName, Category, Price, Quantity  from SAP_Products_List  where  SellerID = 7 ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@customerID", customerID);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dataGridView1.RowTemplate.Height = 80;
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            //textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            pictureBox1.Image = Properties.Resources.no_image_avaiable;
        }
        

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from SAP_Products_List  where ProductID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id", textBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int totalPrice = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Quantity, Price FROM SAP_Add_To_Cart WHERE CustomerID = @customerID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@customerID", customerID);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int quantity = reader.GetInt32(0);
                        int price = reader.GetInt32(1); 
                        totalPrice += quantity * price;
                    }
                }
            }

            //textBox4.Text = "Total Price: " + totalPrice.ToString("C");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*decimal TotalPriceToPass = decimal.Parse(textBox4.Text.Substring(13)); 
            Form23 f23 = new Form23(Email.ToString(), TotalPriceToPass.ToString); 
            f23.ShowDialog();
            this.Close();*/
            this.Hide();
            Form23 f23 = new Form23();
            f23.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3(Email);
            f3.ShowDialog();
            this.Close();
        }
    }
}
