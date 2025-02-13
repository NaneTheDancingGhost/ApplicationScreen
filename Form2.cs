using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationScreen
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=DESKTOP-ND9GR9V;Database=Basvuru;Trusted_Connection=True;TrustServerCertificate=True";
        string customerNu;
        public Form2(string customerNo)
        {  
            InitializeComponent();
            customerNu = customerNo;
            musNo.Text = customerNu;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void dungeonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dreamTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dungeonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void airSeparator1_Click(object sender, EventArgs e)
        {

        }
        private void dreamTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dreamTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (dreamTextBox3.Text.Length > 10)
            {
                dreamTextBox3.Text = dreamTextBox3.Text.Substring(0, 10);
                dreamTextBox3.SelectionStart = dreamTextBox3.Text.Length;
            }

        }

        private void dungeonLabel6_Click(object sender, EventArgs e)
        {

        }

        private void dreamTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void crownDropDownList3_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel10_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel11_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel12_Click(object sender, EventArgs e)
        {

        }

        private void dreamTextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void foreverButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void skyButton1_Click(object sender, EventArgs e)
        {   
            var selectedItem = crownDropDownList2.SelectedItem;

            if (selectedItem != null )
            {
                var maas = selectedItem.Text;
                if (maas == "Emekli")
                {
                    dreamTextBox4.Text = "10.000";
                }
                else if (maas == "Yarı Zaman")
                {
                    dreamTextBox4.Text = "11.052";
                }
                else if (maas == "Seçim Yapınız...")
                {    
                    dreamTextBox4.Text = "";
                    MessageBox.Show("Lütfen maaş türünü seçiniz.");  
                }
                else 
                {
                    dreamTextBox4.Text = "22.104";
                }
            }
            else
            {   
                dreamTextBox4.Text = "";
                MessageBox.Show("Lütfen maaş türünü seçiniz.");   
            }
        }
        private void skyButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dreamTextBox6.Text) || string.IsNullOrEmpty(dreamTextBox7.Text))
            {
                MessageBox.Show("Lütfen vade ve ana para alanlarını doldurunuz.");
                return; 
            }

            
            if (!int.TryParse(dreamTextBox6.Text, out int vade) || !int.TryParse(dreamTextBox7.Text, out int anaPara))
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler giriniz.");
                return; 
            }

            
            if (vade <= 0 || anaPara <= 0)
            {
                MessageBox.Show("Vade ve ana para pozitif değerler olmalıdır.");
                return; 
            }

            double faizoran = 4.35 / 100;
            double faizCarpani = Math.Pow(1 + faizoran, vade);
            double aylikTaksit = anaPara * faizoran * faizCarpani / (faizCarpani - 1);
            dreamTextBox8.Text = aylikTaksit.ToString("N2");
        }
        private void skyButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
