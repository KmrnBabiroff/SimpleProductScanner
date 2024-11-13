using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProductScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product p = cerateProduct();
            writeOnFile(p);
            ClearBox();
        }
        private void ClearBox()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private Product cerateProduct()
        {
            return new Product(textBox2.Text, textBox3.Text, textBox4.Text);
        }

        private void writeOnFile(Product p)
        {
            FileStream fs = new FileStream("ProductsFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(p.WriteData());

            sw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();

            
        }

        private string ReadData()
        {
            string line = "";
            FileStream fs = new FileStream("ProductsFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            line = sr.ReadLine();

            sr.Close();
            fs.Close();

            return line;
        }
    }
}
