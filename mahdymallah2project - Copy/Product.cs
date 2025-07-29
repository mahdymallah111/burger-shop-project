using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahdymallah2project
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }

    public class Burger : Product
    {
        public bool HasCheese { get; set; }
        public string PattyType { get; set; }

        public override string ToString()
        {
            string cheese = HasCheese ? "with cheese" : "no cheese";
            return $"{base.ToString()} ({PattyType} patty, {cheese})";
        }
    }

    public class Side : Product
    {
        public string Size { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} ({Size})";
        }
    }

    public class Drink : Product
    {
        public string Size { get; set; }
        public bool IsDiet { get; set; }

        public override string ToString()
        {
            string diet = IsDiet ? "Diet" : "Regular";
            return $"{base.ToString()} ({Size}, {diet})";
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string SpecialInstructions { get; set; }

        public decimal TotalPrice => Product.Price * Quantity;

        public override string ToString()
        {
            return $"{Quantity}x {Product.Name} - {TotalPrice:C}";
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public bool IsCompleted { get; set; }

        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

        public override string ToString()
        {
            return $"Order #{OrderId} - {CustomerName} - {TotalAmount:C} - {(IsCompleted ? "Completed" : "Pending")}";
        }
    }

}
