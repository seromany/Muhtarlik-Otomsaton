using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Muhtarlik
{
    public partial class Form5 : Form
    {
        Classlar siniflar = new Classlar();
        public Form5()
        {
            InitializeComponent();
        }

        private void frm2_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.AnaMenuGecis(btn);
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (siniflar.tiklandi == false)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siniflar.tiklandi = true;
            Button btn = sender as Button;
            siniflar.sql = "DELETE FROM YeniNufusBilgileri WHERE tc = '" + comboBox1.Text + "'";
            siniflar.DatabaseIslem(btn);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            siniflar.TcCekme(comboBox1);
        }
    }
}
