using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BetaMart_crud
{
    public partial class Form1 : Form
    {

        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\XII RPL 5\UKK\Pemograman Berorientasi Objek\BetaMart_crud\BetaMart_crud\mydb.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mydbDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.mydbDataSet.Barang);

        }

        void ShowData()
        {
            koneksi.Open();
            string query = "select * from Barang";
            OleDbDataAdapter data = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Insert into Barang (nama, kode, harga, stok) values ('" + textNama.Text + "', '" + textKode.Text + "', '" + textHarga.Text + "', '" + textStok.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Tersimpan");
            ClearText();
            ShowData();
        }

        void ClearText()
        {
            textID.Clear();
            textNama.Clear();
            textKode.Clear();
            textStok.Clear();
            textHarga.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from Barang where Nama='" + textSearch.Text + "'";
            OleDbDataAdapter data = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "DELETE FROM Barang WHERE ID = " + textID.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Terhapus");
            ShowData();
            ClearText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE Barang SET nama = '" + textNama.Text + "', kode = '" + textKode.Text + "', harga = '" + textHarga.Text + "', stok = '" + textStok.Text + "' where ID="+textID.Text+" ", koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Diupdate");
            ClearText();
            ShowData();
        }
    }
}
