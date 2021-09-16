using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace $safeprojectname$
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MetinBatur.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO BaturTeknikDB (İsim, Soyisim, Telefon, Tarih, İslem, Adres) VALUES ('" + textBox1.Text + "','"+ textBox2.Text+ "','" + textBox3.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                komut.ExecuteNonQuery();
                MessageBox.Show("Kişi başarılı bir şekilde eklendi.");
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message.ToString());
            }
            finally
            {
                var myForm = new Form1();
                myForm.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new Form1();
            myForm.Show();
            this.Hide();
        }
    }
}
