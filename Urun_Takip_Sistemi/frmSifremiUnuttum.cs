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
    public partial class frmSifremiUnuttum : Form
    {
        public frmSifremiUnuttum()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3AFCJCF\\SQLEXPRESS;Initial Catalog=DbStokTakip;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex==1 || comboBox1.SelectedIndex==2)
            {
                baglanti.Open();
                SqlCommand k1 = new SqlCommand("select kullanici,teyitsorusu1 ,teyitsorusu2  from tbladmin where kullanici=@p1 and teyitsorusu1=@p2 or kullanici=@p3 and teyitsorusu2=@p4 or kullanici=@p5 and teyitsorusu3=@p6 ", baglanti);
                k1.Parameters.AddWithValue("@p1", txtkullaniciadi.Text);
                k1.Parameters.AddWithValue("@p2", txtcevabi.Text);
                k1.Parameters.AddWithValue("@p3", txtkullaniciadi.Text);
                k1.Parameters.AddWithValue("@p4", txtcevabi.Text);
                k1.Parameters.AddWithValue("@p5", txtkullaniciadi.Text);
                k1.Parameters.AddWithValue("@p6", txtcevabi.Text);

                SqlDataReader dr = k1.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Şifreniz: 12345 ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hatalı Veriş Girişi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                baglanti.Close();
            }
            




            
        }
    }
}
