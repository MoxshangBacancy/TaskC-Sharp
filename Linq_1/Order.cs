using System;
using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double? OrderAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public List<string> Products { get; set; }

    public Order(int orderId, string customerName, double? orderAmount, DateTime orderDate, List<string> products)
    {
        OrderId = orderId;
        CustomerName = customerName;
        OrderAmount = orderAmount;
        OrderDate = orderDate;
        Products = products;
    }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {CustomerName}, Amount: ${OrderAmount:F2}, Date: {OrderDate.ToShortDateString()}, Products: {string.Join(", ", Products)}";
    }
}

public class OrderService
{
    public static List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order(1, "John Doe", 150.50, DateTime.Now.AddDays(-1), new List<string> { "Laptop", "Mouse" }),
            new Order(2, "Jane Smith", 200.00, DateTime.Now.AddDays(-2), new List<string> { "Phone", "Charger" }),
            new Order(3, "Alice Johnson", 340.75, DateTime.Now.AddDays(-3), new List<string> { "Tablet", "Headphones" }),
            new Order(4, "Bob Williams", 120.00, DateTime.Now.AddDays(-4), new List<string> { "Smartwatch", "USB Cable" }),
            new Order(5, "Charlie Brown", 500.25, DateTime.Now.AddDays(-5), new List<string> { "Monitor", "Keyboard", "Mouse" }),
            new Order(6, "David Wilson", 80.00, DateTime.Now.AddDays(-6), new List<string> { "Flash Drive", "Power Bank" }),
            new Order(7, "Emma Davis", 210.90, DateTime.Now.AddDays(-7), new List<string> { "Camera", "Tripod" }),
            new Order(8, "Frank Miller", 130.60, DateTime.Now.AddDays(-8), new List<string> { "Desk Lamp", "Notebook" }),
            new Order(9, "Grace Lee", 275.40, DateTime.Now.AddDays(-9), new List<string> { "External HDD", "Cooling Pad" }),
            new Order(10, "Hank Green", 620.30, DateTime.Now.AddDays(-10), new List<string> { "Gaming Console", "Controller" }),
            new Order(11, "Isabella Moore", 75.25, DateTime.Now.AddDays(-11), new List<string> { "Wireless Mouse", "Mouse Pad" }),
            new Order(12, "Jack White", 340.00, DateTime.Now.AddDays(-12), new List<string> { "Desk Chair", "Office Supplies" }),
            new Order(13, "Kelly Black", null, DateTime.Now.AddDays(-13), new List<string> { "Speaker", "USB Hub" }),
            new Order(14, "Liam Harris", 199.99, DateTime.Now.AddDays(-14), new List<string> { "Graphics Tablet", "Pen Stylus" }),
            new Order(15, "Mia King", 450.45, DateTime.Now.AddDays(-15), new List<string> { "Fitness Tracker", "Earbuds" }),
            new Order(16, "Noah Wright", 520.00, DateTime.Now.AddDays(-16), new List<string> { "Smart TV", "HDMI Cable" }),
            new Order(17, "Olivia Scott", 640.70, DateTime.Now.AddDays(-17), new List<string> { "Gaming Chair", "Desk Mat" }),
            new Order(18, "Paul Adams", 310.10, DateTime.Now.AddDays(-18), new List<string> { "WiFi Router", "Ethernet Cable" }),
            new Order(19, "Quinn Baker", 85.30, DateTime.Now.AddDays(-19), new List<string> { "Keyboard Cover", "Cleaning Kit" }),
            new Order(20, "Ryan Young", 990.90, DateTime.Now.AddDays(-20), new List<string> { "PC Build Kit", "Cooling System" }),
        };
    }
}
