using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProductScanner
{
    internal class Product
    {
        public string ProductName, ProductBrand, Price;
        private string id;
 public Product(string ProductName, string ProductBrand, string Price)
  {
      this.ProductName = ProductName;
         this.ProductBrand = ProductBrand;
            this.Price = Price;
        this.id = GenerateProductID();
        }

 public Product(string data)
        {
            string[] splitedData = data.Split('$');
            id = splitedData[0];
       ProductName = splitedData[1];
            ProductBrand = splitedData[2];
            Price = splitedData[3];
        }

        public string GetId()
        {
            return id;
        }
        private string GenerateProductID()
        {
            Random rnd = new Random();
            int totalNumberOfTest = ProductName.Length;
            int rand = rnd.Next(0, totalNumberOfTest);

            string id = ProductName.Substring(rand, 1);
            rand = rnd.Next(0, totalNumberOfTest);
            id += ProductName.Substring(rand, 1) + "-";

            id += new Random().Next(1000, 10000).ToString();
            return id;
        }
        public string ReadData()
        {
            return $"{GetId()}\t{ProductName}\t{ProductBrand}\t{Price}";
        }
        public string WriteData()
        {
            return $"{GetId()}${ProductName}${ProductBrand}${Price}";
        }
    }
}
