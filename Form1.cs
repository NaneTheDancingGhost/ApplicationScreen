using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApplicationScreen
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=DESKTOP-ND9GR9V;Database=Basvuru;Trusted_Connection=True;TrustServerCertificate=True";
        private bool _isDragging = false;
        private Point _startPoint = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
            // Attach event handlers for dragging
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

            // If you want to drag the form using a specific control (e.g., panel1)
            panel1.MouseDown += Form1_MouseDown;
            panel1.MouseMove += Form1_MouseMove;
            panel1.MouseUp += Form1_MouseUp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _startPoint = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(newPoint.X - _startPoint.X, newPoint.Y - _startPoint.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }
        private void dungeonLabel1_Click(object sender, EventArgs e)
        {

        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            skyButton2.Enabled = false;
            panel2.Visible = false;
            string customerNo = musteriNo.Text;

            string query = "SELECT FirstName, LastName, TcNo FROM dbo.Musteriler WHERE CustomerNo = @CustomerNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CustomerNo", customerNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();
                                string tcNo = reader["TcNo"].ToString();

                                Ad.Text = firstName;
                                Soyad.Text = lastName;
                                TcNo.Text = tcNo;
                                skyButton2.Enabled = true;
                                panel2.Visible = true;  
                                LoadDataIntoListView(customerNo);

                            }
                            else
                            {
                                MessageBox.Show("Bu müþteri numarasýna ait bir kayýt bulunamamýþtýr.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                  
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
     
        private void LoadDataIntoListView(string CustomerNo)
        {
           
            try
            {
                int customerNo = int.Parse(CustomerNo);
                string query = "SELECT refNo, subeNo,bolumAd, status, krediTutar, urunAd , tarih, urunSira FROM basvuruAyrinti WHERE customerNo = @CustomerNo";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                   
                    command.Parameters.AddWithValue("@CustomerNo", customerNo);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string refNo = reader["refNo"].ToString();
                        string subeNo = reader["subeNo"].ToString();
                        string bolumAd = reader["bolumAd"].ToString();
                        string status = reader["status"].ToString();
                        string krediTutar = reader["krediTutar"].ToString();
                        string urunAd = reader["urunAd"].ToString();
                        string tarih = reader["tarih"].ToString();
                        string urunSira = reader["urunSira"].ToString();
                        // Durumu iþle
                        string durum = "";
                        if (status == "accepted")
                            durum = "kabul edildi";
                        else if (status == "denied")
                            durum = "reddedildi";
                        else
                            durum = "bekliyor";
                
                        ListViewItem item = new ListViewItem(new string[]
                        {
                    refNo,
                    bolumAd,
                    tarih,
                    "1", 
                    urunSira,
                    "",
                    krediTutar,
                    "",
                    urunAd,
                    durum,
                        });
                        poisonListView1.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dungeonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void dreamTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void dreamTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void dreamTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dungeonLabel4_Click(object sender, EventArgs e)
        {

        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void headerLabel1_Click(object sender, EventArgs e)
        {

        }

        private void aloneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void foreverComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dungeonLabel7_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel5_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel6_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel6_Click_1(object sender, EventArgs e)
        {

        }

        private void materialListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dungeonLabel5_Click_1(object sender, EventArgs e)
        {

        }
        private void skyButton2_Click(object sender, EventArgs e)
        {
            string customerNo = musteriNo.Text;
            Form2 form = new Form2(customerNo);
            form.Show();
        }

        private void dungeonLabel13_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel8_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel10_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel11_Click(object sender, EventArgs e)
        {

        }
    }
}
