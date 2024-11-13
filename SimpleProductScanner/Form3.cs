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
    public partial class Form3 : Form
    {
        List<Product> AllProduct = new List<Product>();
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            if (path != null)
            {

                ReadDataAndCreateProduct(path);
                AllProductToListbox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        private void ReadDataAndCreateProduct(string path)
        {
            AllProduct.Clear();

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Product p = new Product(line);
                AllProduct.Add(p);
            }
            sr.Close();
            fs.Close();
        }
        private void AllProductToListbox()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < AllProduct.Count; i++)
            {
                listBox1.Items.Add(AllProduct[i].ReadData()); 
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
