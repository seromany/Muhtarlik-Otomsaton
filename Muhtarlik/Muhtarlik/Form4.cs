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
    public partial class Form4 : Form
    {
        Classlar siniflar = new Classlar();
        public Form4()
        {
            InitializeComponent();
        }

        private void frm2_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.AnaMenuGecis(btn);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (siniflar.tiklandi == false)
                Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            siniflar.baglanti.Open();
            siniflar.komut = new OleDbCommand("Select * From YeniNufusBilgileri",siniflar.baglanti);
            OleDbDataReader data = siniflar.komut.ExecuteReader();
            while (data.Read())
            {
                comboBox1.Items.Add(data["tc"]);
                comboBox4.Items.Add(data["tc"]);
                comboBox6.Items.Add(data["tc"]);
                comboBox8.Items.Add(data["tc"]);
                comboBox10.Items.Add(data["tc"]);
            }
            siniflar.baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.sql = "Insert Into Yakinlik(tc, birTcNo, birYakinlik, ikiTcNo, ikiYakinlik, ucTcNo, ucYakinlik, dortTcNo, dortYakinlik) VALUES ('" + comboBox1.Text + "','" + comboBox4.Text + "', '" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + comboBox8.Text + "','" + comboBox9.Text + "','" + comboBox10.Text + "','" + comboBox11.Text + "')";
            siniflar.DatabaseIslem(btn);
            siniflar.sql = "Insert Into YeniKisiBilgileri(tc, cinsiyet, oncekiSoyad, uyruk, mail, meslek, kisiSonDurumu, cepTel, evTel, cadde, sokak, site, blok, binaNo, daireNo) VALUES ('" + comboBox1.Text + "', '" + comboBox2.Text + "','" + textBox1.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox16.Text + "','" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox11.Text + "')";
            siniflar.DatabaseIslem(btn);
        }
    }
}
