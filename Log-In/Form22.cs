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
    public partial class Form22 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public string Email { get; set; }
        int customerID;
        public Form22()
        {
            InitializeComponent();
            BindGridView();
        }
        public Form22(string Email)
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

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select ProductID,ProductPic, ProductName, Category, Price, Quantity  from SAP_Products_List  where  Category = 'Laptop'  AND Quantity >= 1 ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dataGridView1.RowTemplate.Height = 80;
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
            return ms.GetBuffer();
        }

        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            pictureBox3.Image = Properties.Resources.no_image_avaiable;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6(Email);
            f6.BindGridView();
            f6.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pictureBox3.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            int Price = Convert.ToInt32(textBox3.Text);
            //int Quantity = Convert.ToInt32(numericUpDown1.Value);

            int Quantity = 1;

            string query = "INSERT INTO SAP_Add_To_Cart (ProductID, ProductPic, ProductName, Category, Price, Quantity) VALUES (@ProductID, @productImage, @ProductName, @ProductCategory, @Price, @Quantity)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ProductId", textBox1.Text);
            cmd.Parameters.AddWithValue("@productImage", SavePhoto());
            cmd.Parameters.AddWithValue("@ProductName", textBox2.Text);
            cmd.Parameters.AddWithValue("@ProductCategory", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            //cmd.Parameters.AddWithValue("@CustomerID", customerID);




            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully");
                //BindGridView(); 
            }
            con.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3(Email);
            f3.ShowDialog();
            this.Close();
        }
    }
}
