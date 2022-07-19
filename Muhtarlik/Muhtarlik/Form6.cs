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
    public partial class Form6 : Form
    {
        string tabloAdi;
        string[] nufusBilgileri = { "tc", "ad", "soyad", "babaAdi", "anneAdi", "dogumTarihi", "dogumYeri", "medeniHali", "dini", "kanGrubu", "il", "ilce", "mahalleKoy", "ciltNo", "aileSiraNo", "siraNo" };
        string[] kisiBilgileri = { "cinsiyet", "oncekiSoyad", "uyruk", "mail", "meslek", "kisiSonDurumu", "cepTel", "evTel", "cadde", "sokak", "site", "blok", "binaNo", "daireNo" };
        string[] yakinlik = { "birTcNo", "birYakinlik", "ikiTcNo", "ikiYakinlik", "ucTcNo", "ucYakinlik", "dortTcNo", "dortYakinlik" };
        Classlar siniflar = new Classlar();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (siniflar.tiklandi == false)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            if (comboBox1.Text == "dogumTarihi")
                siniflar.sql = "UPDATE " + tabloAdi + " SET " + comboBox1.Text + " = '" + maskedTextBox1.Text + "' WHERE tc = '" + comboBox3.Text + "'";
            else
                siniflar.sql = "UPDATE " + tabloAdi + " SET " + comboBox1.Text + " = '" + textBox2.Text + "' WHERE tc = '" + comboBox3.Text + "'";
            siniflar.DatabaseIslem(btn);
        }

        private void frm2_Click_1(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.AnaMenuGecis(btn);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            siniflar.TcCekme(comboBox3);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "dogumTarihi")
            {
                maskedTextBox1.Visible = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (comboBox2.Text == "Nufus Bilgisi")
            {
                comboBox1.Items.AddRange(nufusBilgileri);
                tabloAdi = "YeniNufusBilgileri";
            }
            if (comboBox2.Text == "Kişi Bilgisi")
            {
                comboBox1.Items.AddRange(kisiBilgileri);
                tabloAdi = "YeniKisiBilgileri";
            }
            if (comboBox2.Text == "Yakinlik")
            {
                comboBox1.Items.AddRange(yakinlik);
                tabloAdi = "Yakinlik";
            }
        }
    }
}
