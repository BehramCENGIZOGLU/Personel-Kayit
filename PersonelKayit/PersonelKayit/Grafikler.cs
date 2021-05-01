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
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H8DO9QCK;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
           // Sehirler Grafigi //
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) from Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader drg1 = komutg1.ExecuteReader();
            while(drg1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(drg1[0], drg1[1]);
            }
            baglanti.Close();
            // Meslek-Maas Grafigi //
            baglanti.Open();
            SqlCommand komutmm1 = new SqlCommand("Select PerMeslek,AVG(PerMaas) from Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader drg2 = komutmm1.ExecuteReader();
            while(drg2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(drg2[0], drg2[1]);
            }
            baglanti.Close();
        }
    }
}
