using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3AFCJCF\\SQLEXPRESS;Initial Catalog=DbStokTakip;Integrated Security=True");
        private void btnListele_Click(object sender, EventArgs e)
        {

            SqlCommand k1 = new SqlCommand("select UrunId,UrunAd,Stok,kategori,UrunKategori,AlisFiyati,SatisFiyati from TblStok inner join TblKategori on TblStok.Kategori=TblKategori.Id", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(k1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false;

            txtAlFiy.Clear();
            txtId.Clear();
            txtSatFiy.Clear();
            txtUrunAd.Clear();
            cmbKategori.SelectedIndex = -1;
            nmrStok.Value = 0;


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand k2 = new SqlCommand("update tblstok set UrunAd=@p1,Stok=@p2,Kategori=@p3,alisfiyati=@p5,satisfiyati=@p6 where UrunId=@p4", baglanti);
            k2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            k2.Parameters.AddWithValue("@p2", nmrStok.Value);
            k2.Parameters.AddWithValue("@p3", cmbKategori.SelectedValue);
            k2.Parameters.AddWithValue("@p4", txtId.Text);
            k2.Parameters.AddWithValue("@p5", txtAlFiy.Text);
            k2.Parameters.AddWithValue("@p6", txtSatFiy.Text);

            k2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Tamamlandı");




            SqlCommand k1 = new SqlCommand("select UrunId,UrunAd,Stok,kategori,UrunKategori,AlisFiyati,SatisFiyati from TblStok inner join TblKategori on TblStok.Kategori=TblKategori.Id", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(k1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false;

            txtAlFiy.Clear();
            txtId.Clear();
            txtSatFiy.Clear();
            txtUrunAd.Clear();
            cmbKategori.SelectedIndex = -1;
            nmrStok.Value = 0;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand k3 = new SqlCommand("select * from tblkategori", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(k3);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbKategori.ValueMember = "Id";
            cmbKategori.DisplayMember = "UrunKategori";
            cmbKategori.DataSource = dt;




            SqlCommand k7 = new SqlCommand("select UrunId,UrunAd,Stok,kategori,UrunKategori,AlisFiyati,SatisFiyati from TblStok inner join TblKategori on TblStok.Kategori=TblKategori.Id", baglanti);
            SqlDataAdapter da1 = new SqlDataAdapter(k7);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["Kategori"].Visible = false;





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            nmrStok.Value = int.Parse( dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbKategori.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatFiy.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtAlFiy.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand k5 = new SqlCommand("Delete tblstok where urunıd=@p1", baglanti);
            k5.Parameters.AddWithValue("@p1", txtId.Text);
            k5.ExecuteNonQuery();

            MessageBox.Show("Silme Tamamlandı");
            baglanti.Close();



            SqlCommand k1 = new SqlCommand("select UrunId,UrunAd,Stok,kategori,UrunKategori,AlisFiyati,SatisFiyati from TblStok inner join TblKategori on TblStok.Kategori=TblKategori.Id", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(k1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false;

            txtAlFiy.Clear();
            txtId.Clear();
            txtSatFiy.Clear();
            txtUrunAd.Clear();
            cmbKategori.SelectedIndex = -1;
            nmrStok.Value = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand k6 = new SqlCommand("insert into tblstok (urunad,stok,kategori,alisfiyati,satisfiyati) values (@p1,@p2,@p3,@p4,@p5)  ", baglanti);
            k6.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            k6.Parameters.AddWithValue("@p2", nmrStok.Value);
            k6.Parameters.AddWithValue("@p3", cmbKategori.SelectedValue);
            k6.Parameters.AddWithValue("@p4", txtAlFiy.Text);
            k6.Parameters.AddWithValue("@p5", txtSatFiy.Text);

            k6.ExecuteNonQuery();

            MessageBox.Show("Ekleme Yapıldı");


            SqlCommand k1 = new SqlCommand("select UrunId,UrunAd,Stok,kategori,UrunKategori,AlisFiyati,SatisFiyati from TblStok inner join TblKategori on TblStok.Kategori=TblKategori.Id", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(k1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false;

            txtAlFiy.Clear();
            txtId.Clear();
            txtSatFiy.Clear();
            txtUrunAd.Clear();
            cmbKategori.SelectedIndex = -1;
            nmrStok.Value = 0;

        }
    }
}
