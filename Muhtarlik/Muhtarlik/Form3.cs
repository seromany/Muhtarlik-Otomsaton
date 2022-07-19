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
    public partial class Form3 : Form
    {
        Classlar siniflar = new Classlar();
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.AnaMenuGecis(btn);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (siniflar.tiklandi == false)
                Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.sql = "Insert Into YeniNufusBilgileri(tc, ad, soyad, babaAdi, anneAdi, dogumTarihi, dogumYeri, medeniHali, dini, kanGrubu, il, ilce, mahalleKoy, ciltNo, aileSiraNo, siraNo) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + maskedTextBox1.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "','" + comboBox4.Text + "','" + comboBox2.Text + "','" + comboBox5.Text + "','" + textBox10.Text + "','" + textBox7.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox11.Text + "')";
            siniflar.DatabaseIslem(btn);
        }

        private void SadeceSayiGirisi(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
