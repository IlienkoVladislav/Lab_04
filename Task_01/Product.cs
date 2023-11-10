using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
    interface ISearchable
    {
        IEnumerable<Product> SearchByPrice(double maxPrice);
        IEnumerable<Product> SearchByCategory(string category);
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> PurchaseHistory { get; set; } = new List<Order>();
    }

    class Order
    {
        public List<Product> Products { get; set; }
        public List<int> Quantities { get; set; }
        public double TotalPrice => Products.Zip(Quantities, (product, quantity) => product.Price * quantity).Sum();
        public bool IsCompleted { get; set; }
    }

    class Shop : ISearchable
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>();

        public IEnumerable<Product> SearchByPrice(double maxPrice)
        {
            return Products.Where(product => product.Price <= maxPrice);
        }

        public IEnumerable<Product> SearchByCategory(string category)
        {
            return Products.Where(product => product.Category == category);
        }


        public void PlaceOrder(User user, List<Product> products, List<int> quantities)
        {
            var order = new Order
            {
                Products = products,
                Quantities = quantities,
                IsCompleted = false
            };

            user.PurchaseHistory.Add(order);
            Orders.Add(order);
        }

        public void CompleteOrder(Order order)
        {
            order.IsCompleted = true;
        }
    }
}
