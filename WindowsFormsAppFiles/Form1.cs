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
using System.Web;

namespace WindowsFormsAppFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNev.Text))
            {
                MessageBox.Show("Nem adott meg nevet!");
                return;
            }
            if (string.IsNullOrEmpty(richTextBoxSzoveg.Text))
            {
                MessageBox.Show("Nem adott meg szöveget!");
                return ;
            }
            saveFileDialog1.Filter = "Egyszerű sövegfájl (*.txt)| *.txt | Vesszővel tagoltszövegfájl (*.csv) | *.csv | Minden fájl |*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szoveg = string.Join(";", textBoxNev.Text, dateTimePicker1.Value, richTextBoxSzoveg.Text);
                string kivFile = saveFileDialog1.FileName;
                File.WriteAllText(kivFile, szoveg);
                MessageBox.Show("Kiválasztott fájl: " + kivFile);
                textBoxNev.Text = "";
                richTextBoxSzoveg.Text = "";
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva!");
            }

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string kivFile = openFileDialog1.FileName;
                string beolvasottSzoveg = File.ReadAllText(kivFile);
                string[] adatok = beolvasottSzoveg.Split(';');
                textBoxNev.Text = adatok[0];
                richTextBoxSzoveg.Text = adatok[2];
                dateTimePicker1.Text = adatok[1];
            }
        }
    }
}
