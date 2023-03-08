using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Sistemi
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3AFCJCF\\SQLEXPRESS;Initial Catalog=DbStokTakip;Integrated Security=True");



        private void btnGiris_Click(object sender, EventArgs e)
        {

           if(txtGuvYaz.Text!=""&& txtkullaniciad.Text != "" && txtSifre.Text != "")
            {

                baglanti.Open();
                SqlCommand k1 = new SqlCommand("select * from tbladmin where kullanici=@p1 and Sifre=@p2", baglanti);
                k1.Parameters.AddWithValue("@p1", txtkullaniciad.Text);
                k1.Parameters.AddWithValue("@p2", txtSifre.Text);


                SqlDataReader dr = k1.ExecuteReader();

                if (dr.Read() && txtGuv.Text == txtGuvYaz.Text)
                {

                    Form1 fr = new Form1();
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Bilgileri", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    int s1, s2, s3, s4;
                    Random rn = new Random();
                    s1 = rn.Next(0, 10);
                    s2 = rn.Next(0, 10);
                    s3 = rn.Next(0, 10);
                    s4 = rn.Next(0, 10);
                    string[] dogrulama = { "a", "A", "b", "B", "c", "C", "d", "D", "e", "E" };
                    txtGuv.Text = (dogrulama[s1] + s2 + dogrulama[s3] + s4);
                }
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmadan Devam Edin", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                int s1, s2, s3, s4;
                Random rn = new Random();
                s1 = rn.Next(0, 10);
                s2 = rn.Next(0, 10);
                s3 = rn.Next(0, 10);
                s4 = rn.Next(0, 10);
                string[] dogrulama = { "a", "A", "b", "B", "c", "C", "d", "D", "e", "E" };
                txtGuv.Text = (dogrulama[s1] + s2 + dogrulama[s3] + s4);

            }

            





        }

        private void admin_Load(object sender, EventArgs e)
        {

            int s1, s2, s3, s4;
            Random rn = new Random();
            s1 = rn.Next(0, 10);
            s2 = rn.Next(0, 10); 
            s3 = rn.Next(0, 10);
            s4 = rn.Next(0, 10);
            string[] dogrulama= {"a","A","b","B","c","C","d","D","e","E"};
            txtGuv.Text = (dogrulama[s1] + s2 + dogrulama[s3] + s4);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSifremiUnuttum fr = new frmSifremiUnuttum();
            fr.Show();
            this.Hide();
        }
    }
}
