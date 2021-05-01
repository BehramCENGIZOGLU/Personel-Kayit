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

namespace PersonelKayit
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H8DO9QCK;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            TxtPersonelİd.Text = "";
            TxtPersonelAd.Text = "";
            TxtPersonelSoyad.Text = "";
            CmbPersonelSehir.Text = "";
            MskPersonelMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtPersonelMeslek.Text = "";
            TxtPersonelAd.Focus();

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPersonelSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbPersonelSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskPersonelMaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", TxtPersonelMeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt başarıyla eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { 
                label8.Text = "true"; 
            }
                
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "false";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPersonelİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPersonelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPersonelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbPersonelSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskPersonelMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtPersonelMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        
        private void label8_TextChanged(object sender, EventArgs e)
        {
             if(label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel where Perİd= @k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", TxtPersonelİd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("kayit basarili bir sekilde silinmistir");


            baglanti.Close();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perİd=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", TxtPersonelAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtPersonelSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", CmbPersonelSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", MskPersonelMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", TxtPersonelMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", TxtPersonelİd.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("islem basarili bir sekilde guncellenmistir");
        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Istatistik frm = new Istatistik();
            frm.Show();
            
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            Grafikler frmg = new Grafikler();
            frmg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Raporlama frmr = new Raporlama();
            frmr.Show();
        }
    }
}
          
            
        



