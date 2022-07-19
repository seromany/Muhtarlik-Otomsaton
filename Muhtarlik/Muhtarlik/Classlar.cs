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
    class Classlar
    {
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0; Data Source =" + Application.StartupPath + "/VeriTabani.mdb");
        public OleDbCommand komut = new OleDbCommand();
        public OleDbDataAdapter adtr;
        public OleDbDataReader data;

        public bool tiklandi;
        public string sql;
        public Form frm;
        public void AnaMenuGecis(Button btn)
        {
            DialogResult gecis = MessageBox.Show(" Ana Menüye dönmek istediğinize emin misiniz ? \n Kaydetmediğiniz veya yarım bıraktığınız işlemler silinecektir", "Uyarı", MessageBoxButtons.YesNo);
            if (gecis == DialogResult.Yes)
            {
                Form.ActiveForm.Close();
                frm = new Form2();
                frm.Show();
            }
            else
            {
                tiklandi = false;
            }
        }
        public void cikis(bool tiklandi)
        {
            if (tiklandi == false)
            {
                DialogResult cikis;
                cikis = MessageBox.Show("Programı kapatmak istediğinize emin misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                    Application.Exit();
                else
                {
                    frm = new Form2();
                    frm.Show();
                }
            }
        }
        public void FormlariOlustur(Button btn)
        {
            Form.ActiveForm.Close();
            if (btn.Name == "frm2")
                frm = new Form2();
            if (btn.Name == "frm3")
                frm = new Form3();
            if (btn.Name == "frm4")
                frm = new Form4();
            if (btn.Name == "frm5")
                frm = new Form5();
            if (btn.Name == "frm6")
                frm = new Form6();
            if (btn.Name == "frm7")
                frm = new Form7();
            if (btn.Name == "frm8")
                frm = new Form8();
            frm.Show();
        }
        public void DatabaseIslem(Button btn)
        {
            try 
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = @sql;
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("İşleminiz Başarıyla Gerçekleştirildi!", "Mesaj", MessageBoxButtons.OK);
                tiklandi = false;
            }
            catch 
            {
                Form.ActiveForm.Close();
                MessageBox.Show("İşlem yapılırken bir hata oluştu. Hatalı bir değer girmiş olabilirsiniz. Lütfen tekrar deneyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (btn.Name == "frm3")
                    frm = new Form3();
                if (btn.Name == "frm4")
                    frm = new Form4();
                if (btn.Name == "frm5")
                    frm = new Form5();
                if (btn.Name == "frm6")
                    frm = new Form6();
                frm.Show();
            }
        }
        public void TabloOlustur(DataGridView datagridview, string sql)
        {
            DataTable tablo = new DataTable();
            adtr = new OleDbDataAdapter(sql, baglanti);
            adtr.Fill(tablo);
            datagridview.DataSource = tablo;
        }
        public void TcCekme(ComboBox cmb)
        {
            baglanti.Open();
            komut = new OleDbCommand("Select * From YeniNufusBilgileri", baglanti);
            data = komut.ExecuteReader();
            while (data.Read())
            {
                cmb.Items.Add(data["tc"]);
            }
            baglanti.Close();
        }
    }
}
