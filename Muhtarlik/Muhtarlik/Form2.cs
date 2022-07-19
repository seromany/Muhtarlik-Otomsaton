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
    public partial class Form2 : Form
    {
        bool tiklandi = false;
        Button btn;
        Classlar siniflar = new Classlar();
        public Form2()
        {
            InitializeComponent();
        }

        private void FormaGit(object sender, EventArgs e)
        {
            tiklandi = true;
            btn = sender as Button;
            siniflar.FormlariOlustur(btn);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            siniflar.cikis(tiklandi);
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
