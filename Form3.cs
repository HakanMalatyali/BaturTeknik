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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MetinBatur.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter da;
        DataTable dt = new DataTable();

        int lisetelemeTuru = 1;
        
        void Listele()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();

            dt.Clear();

            try
            {
                baglanti.Open();
                komut.Connection = baglanti;

                switch (lisetelemeTuru)
                {
                    case 1:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY Id ASC";
                        break;
                    case 2:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY İsim ASC";
                        break;
                    case 3:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY İsim DESC";
                        break;
                    case 4:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY Tarih DESC";
                        break;
                    case 5:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY Tarih ASC";
                        break;
                    case 6:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY İslem ASC";
                        break;
                    case 7:
                        komut.CommandText = "SELECT * FROM BaturTeknikDB ORDER BY İslem DESC";
                        break;

                    default:
                        break;

                }

                da = new OleDbDataAdapter(komut);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

       


        private void Form3_Load(object sender, EventArgs e)
        {
            Listele();

            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "İsim";
            dataGridView1.Columns[2].HeaderText = "Soyisim";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Tarih";
            dataGridView1.Columns[5].HeaderText = "İslem";
            dataGridView1.Columns[6].HeaderText = "Adres";

            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Rows[0].Height = 25;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 250;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
    
                    if (baglanti.State != ConnectionState.Open)
                    {
                        baglanti.Open();
                    }
                    OleDbCommand komutsil = new OleDbCommand("Delete from BaturTeknikDB where Id = @Id", baglanti);
                    komutsil.Parameters.AddWithValue("Id", dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                    DialogResult result = MessageBox.Show("Bu Müşteriyi Silmek İstiyor musunuz?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        komutsil.ExecuteNonQuery();
                        MessageBox.Show("Silme işlemi başarılı.");
                    }

                    OleDbCommand komut2 = new OleDbCommand("SELECT * FROM BaturTeknikDB", baglanti);  ///// liste reflesh atsın diye
                    DataTable dt = new DataTable();
                    dt.Load(komut2.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Id"].DisplayIndex = 0;
                    dataGridView1.Columns["İsim"].DisplayIndex = 1;
                    dataGridView1.Columns["Soyisim"].DisplayIndex = 2;
                    dataGridView1.Columns["Telefon"].DisplayIndex = 3;
                    dataGridView1.Columns["Tarih"].DisplayIndex = 4;
                    dataGridView1.Columns["İslem"].DisplayIndex = 5;
                    dataGridView1.Columns["Adres"].DisplayIndex = 6;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var myForm = new Form1();
            myForm.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (comboBox1.SelectedIndex == 0)
            {
                lisetelemeTuru = 2;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                lisetelemeTuru = 3;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                lisetelemeTuru = 4;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                lisetelemeTuru = 5;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                lisetelemeTuru = 6;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                lisetelemeTuru = 7;
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                lisetelemeTuru = 1;
            }
            Listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MetinBatur.mdb");
            if (comboBox2.SelectedIndex == 0)
            {
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM BaturTeknikDB Where İsim like '" + textBox1.Text + "%'", baglanti);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
                else if (comboBox2.SelectedIndex == 1)
            {
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM BaturTeknikDB Where Soyisim like '" + textBox1.Text + "%'", baglanti);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM BaturTeknikDB Where Telefon like '" + "%" + textBox1.Text + "%'", baglanti);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM BaturTeknikDB Where Tarih like '" + textBox1.Text + "%'", baglanti);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM BaturTeknikDB Where İslem like '" + "%" + textBox1.Text + "%'", baglanti);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (comboBox2.SelectedIndex == 5)
            {
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM BaturTeknikDB Where Adres like '" + "%" + textBox1.Text + "%'", baglanti);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
        }

        

       
    }
}
