using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics
{
    internal class product
    {
        public class Product 
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
            public int QuantityInStock { get; set; }

            public Product(string name, string category, double price, int quantity)
            {
                Name = name;
                Category = category;
                Price = price;
                QuantityInStock = quantity;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Price: {Price}, Quantity in Stock: {QuantityInStock}";
            }
        }

    }
}
