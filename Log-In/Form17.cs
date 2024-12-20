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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Log_In
{
    public partial class Form17 : Form
    {
        bool sidebarExpand;
        bool productbar2Collapse;
        int sellerID;
        
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public string Email { get; set; }
        public Form17()
        {
            BindGridView();
            InitializeComponent();
            

        }
        public Form17(string Email)
        {
            InitializeComponent();
            this.Email = Email;

            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT ID FROM SAP_Seller_Login_Data WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", Email);
            con.Open();
            sellerID = (int)cmd.ExecuteScalar();

        }



        private void menubar_Click(object sender, EventArgs e)
        {
            //sidebartimer.Start();
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

        private void producttimer_Tick(object sender, EventArgs e)
        {
            /*if (productbar2Collapse)
            {
                productbar2.Height += 10;
                if (productbar2.Height == productbar2.MaximumSize.Height)
                {
                    productbar2Collapse = false;
                    producttimer.Stop();

                }
            }
            else
            {
                productbar2.Height -= 10;
                if (productbar2.Height == productbar2.MinimumSize.Height)
                {
                    productbar2Collapse = true;
                    producttimer.Stop();
                }
            }*/
        }

        private void product_Click(object sender, EventArgs e)
        {
            //producttimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged in user's email: " + Email);
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f21 = new Form21();
            f21.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select ProductID,ProductPic, ProductName, Category, Price, Quantity  from SAP_Products_List  where  SellerID = @sellerID ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@sellerID", sellerID);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dataGridView1.RowTemplate.Height = 80;
            
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
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void ResetControl()
        {
            
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            pictureBox1.Image = Properties.Resources.no_image_avaiable;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if( textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1|| numericUpDown1.Value == 0||pictureBox1.Image == null) 
            {
                MessageBox.Show("Please fulfill the requirements!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                int Price = Convert.ToInt32(textBox3.Text);
                int Quantity = Convert.ToInt32(numericUpDown1.Value);

                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string query = "INSERT INTO SAP_Products_List (ProductPic, ProductName, Category, Price, Quantity, SellerID) VALUES (@P_pic,@P_name,@P_Category,@P_price,@P_quantity, @SellerID);";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@P_pic", SavePhoto());
                cmd.Parameters.AddWithValue("@P_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@P_Category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@P_price", Price);
                cmd.Parameters.AddWithValue("@P_quantity", Quantity);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Inserted Successfully");
                    BindGridView();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data Not Inserted");
                }

                con.Close();
            }
            
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 f16 = new Form16(Email);
            f16.ShowDialog();
            this.Close();
        }
    }
}
