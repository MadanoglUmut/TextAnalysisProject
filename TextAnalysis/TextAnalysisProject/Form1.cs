using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Linq;


namespace deneme2
{
    public partial class Form1 : Form
    {



        static string icerik;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            OpenFileDialog dosyaSec = new OpenFileDialog();
            dosyaSec.Filter = "Metin Dosyaları|*.txt";
            dosyaSec.Title = "Bir metin dosyası seçin";


            if (dosyaSec.ShowDialog() == DialogResult.OK)
            {

                string dosyaYolu = dosyaSec.FileName;
                richTextBox1.Text = dosyaYolu;

                try
                {
                    icerik = File.ReadAllText(dosyaYolu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya okunamadı: " + ex.Message);
                }


            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            string aramaMetni = textBox1.Text;
            aramaSonuc view = new aramaSonuc();
            view.icerik = icerik;
            view.aramaMetni = aramaMetni;
            view.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            morpho viewTwo = new morpho();
            viewTwo.icerik2 = icerik;
            viewTwo.icerik3 = icerik;
            viewTwo.ShowDialog();

        }
    }
}
