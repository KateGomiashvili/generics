using static generics.product;

namespace generics
{
    internal class Program
    {
        public static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        
        public static IEnumerable<TResult> Transform<TSource, TResult>(IEnumerable<TSource> collection, Func<TSource, TResult> transformer)
        {
            foreach (var item in collection)
            {
                yield return transformer(item);
            }
        }

        public static double CalculateTotalInventoryValue(IEnumerable<Product> products)
        {
            
            var inStockProducts = Filter(products, product => product.QuantityInStock > 0);

            var productValues = Transform(inStockProducts, product => product.Price * product.QuantityInStock);

            double totalValue = 0;
            foreach (var value in productValues)
            {
                totalValue += value;
            }

            return totalValue;
        }




        static void Main(string[] args)
        {

            // Sample data
            List<Product> products = new List<Product>
            {
              new Product("Laptop", "Electronics", 1200.99, 10),
              new Product("Headphones", "Electronics", 150.50, 5),
              new Product("Bananas", "Grocery", 0.99, 0),
              new Product("Apples", "Grocery", 1.49, 20),
              new Product("Desk Chair", "Furniture", 85.75, 7)
             };


            //Filter by Category
            var grocery = Filter(products, product => product.Category == "Grocery");
            Console.WriteLine("Grocery items:");
            foreach (var product in grocery)
            {
                Console.WriteLine(product.ToString());
            }
            //Transform to Product Summaries
            var productsByCategory = Transform(products, product => $"{product.Name} - {product.Category}");
            Console.WriteLine("Products by categories:");
            foreach (var product in productsByCategory)
            {
                Console.WriteLine(product);
            }
            //Filter Out-of-Stock Products
            var outOfStock = Filter(products, product => product.QuantityInStock == 0);
            Console.WriteLine("Out of stock:");
            foreach (var product in outOfStock)
            {
                Console.WriteLine(product.ToString());
            }
            //Calculate Total Inventory Value
            Console.WriteLine($"Total inventory value: {CalculateTotalInventoryValue(products)}");


        }

    }
}

