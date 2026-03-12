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

namespace PraktikumADO
{
    public partial class Form1: Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        // Method untuk menyimpan string koneksi
        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=RIZOO\\MUHAMMADRIO; Initial Catalog=DBAkademikADO; Integrated Security=True"
            );
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); // Panggil method koneksi
                conn.Open(); // Buka koneksi

                MessageBox.Show("Koneksi ke Database Berhasil!");

                conn.Close(); // Tutup koneksi
            }
            catch (Exception ex) // Tangkap dan tampilkan pesan error jika koneksi gagal
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); // Panggil method koneksi
                conn.Open(); // Buka koneksi

                string query = "SELECT COUNT(*) FROM Mahasiswa"; // Query untuk menghitung jumlah mahasiswa

                cmd = new SqlCommand(query, conn); // Buat SqlCommand dengan query dan koneksi

                int jumlah = (int)cmd.ExecuteScalar(); // Eksekusi query dan dapatkan hasil

                txtHasil.Text = jumlah.ToString(); // Tampilkan hasil di TextBox

                conn.Close(); // Tutup koneksi
            }
            catch (Exception ex) // Tangkap dan tampilkan pesan error jika terjadi kesalahan
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); // Panggil method koneksi
                conn.Open(); // Buka koneksi

                string query = "SELECT COUNT(*) FROM MataKuliah"; // Query untuk menghitung jumlah mata kuliah

                cmd = new SqlCommand(query, conn); // Buat SqlCommand dengan query dan koneksi

                int jumlah = (int)cmd.ExecuteScalar(); // Eksekusi query dan dapatkan hasil
            }
        }
    }
}
