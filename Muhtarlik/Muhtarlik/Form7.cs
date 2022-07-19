using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Muhtarlik
{
    public partial class Form7 : Form
    {
        string sql;
        Classlar siniflar = new Classlar();
        public Form7()
        {
            InitializeComponent();
        }

        private void frm2_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.AnaMenuGecis(btn);
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (siniflar.tiklandi == false)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("Arama yapabilmek için bir değer seçmelisiniz!", "Uyarı", MessageBoxButtons.OK);
            else
            {
                this.Location = new Point(100, 100);
                this.Height = 624;
                sql = "SELECT tc,ad,soyad,babaAdi,anneAdi,dogumTarihi,dogumYeri,medeniHali FROM YeniNufusBilgileri WHERE tc = '" + comboBox1.Text + "'";
                siniflar.TabloOlustur(dataGridView1, sql);
                sql = "SELECT dini,kanGrubu,il,ilce,mahalleKoy,ciltNo,aileSiraNo,siraNo FROM YeniNufusBilgileri WHERE tc = '" + comboBox1.Text + "'";
                siniflar.TabloOlustur(dataGridView2, sql);
                sql = "SELECT cinsiyet,oncekiSoyad,uyruk,mail,meslek,kisiSonDurumu,cepTel FROM YeniKisiBilgileri WHERE tc = '" + comboBox1.Text + "'";
                siniflar.TabloOlustur(dataGridView3, sql);
                sql = "SELECT evTel,cadde,sokak,site,blok,binaNo,daireNo FROM YeniKisiBilgileri WHERE tc = '" + comboBox1.Text + "'";
                siniflar.TabloOlustur(dataGridView4, sql);
                sql = "SELECT birTcNo,birYakinlik,ikiTcNo,ikiYakinlik,ucTcNo,ucYakinlik,dortTcNo,dortYakinlik FROM Yakinlik WHERE tc = '" + comboBox1.Text + "'";
                siniflar.TabloOlustur(dataGridView5, sql);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            siniflar.TcCekme(comboBox1);
        }
    }
}
