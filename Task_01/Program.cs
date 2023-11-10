using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    internal class Program
    {
        static void Main()
        {
            var shop = new Shop();

            var user1 = new User { Username = "user1", Password = "pass1" };
            var user2 = new User { Username = "user2", Password = "pass2" };

            shop.Users.Add(user1);
            shop.Users.Add(user2);

            var product1 = new Product { Name = "Product1", Price = 60.5, Category = "Category1" };
            var product2 = new Product { Name = "Product2", Price = 36.0, Category = "Category2" };

            shop.Products.Add(product1);
            shop.Products.Add(product2);

            var order1Products = new List<Product> { product1, product2 };
            var order1Quantities = new List<int> { 2, 1 };

            shop.PlaceOrder(user1, order1Products, order1Quantities);

            var order2Products = new List<Product> { product2 };
            var order2Quantities = new List<int> { 3 };

            shop.PlaceOrder(user2, order2Products, order2Quantities);

            foreach (var order in shop.Orders)
            {
                Console.WriteLine($"Order Total Price: {order.TotalPrice}, Completed: {order.IsCompleted}");
            }
        }
    }
}




