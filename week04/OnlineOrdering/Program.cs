using System;
using System.Collections.Generic;

namespace OnlineOrdering
{ }

// =========================================================================
// 1. ADDRESS CLASS
// =========================================================================
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _streetAddress = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    //Returns true if the country is the USA
    public bool IsInUSA()
    {
        return _country.Trim().ToUpper() == "USA";
    }
    // Formats the entire address with newlines
    public string GetFullAddressString()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// =========================================================================
// 2. CUSTOMER CLASS
// =========================================================================
public class Customer
{
    private string _name;
    private Address _address; // Customer HAS-A Address

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    // Encapsulation: Customer asks its Address objetc to check the country
    public bool LiveInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetAddressString()
    {
        return _address.GetFullAddressString();

    }
}

// =========================================================================
// 3. PRODUCT CLASS
// =========================================================================
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    //Computes total cost for this specific product entry
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

}

// =========================================================================
// 4. ORDER CLASS
// =========================================================================
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        // Apply shipping fee rules based on customer location
        double shippingCost = _customer.LiveInUSA() ? 5.00 : 35.00;

        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "---PACKING LABEL ___\n";
        foreach (Product product in _products)
        {
            label += $"ID: {product.GetProductId()} | Name: {product.GetName()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "---SHIPPING LABEL ___\n";
        label += $"{_customer.GetName()}\n{_customer.GetAddressString()}\n";
        return label;
    }
}

// =========================================================================
// 5. PROGRAM CLASS
// =========================================================================
class Program
{
    static void Main(string[] args)
    {
        // -----------------------------------------------------------------
        // ORDER 1: Domestic Customer (USA)
        // -----------------------------------------------------------------
        Address address1 = new Address("675 Palm St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("Erika Lopez", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "M702", 25.95, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "K840", 79.89, 1));
        order1.AddProduct(new Product("USB-C Cable", "C203", 8.55, 3));

        // -----------------------------------------------------------------
        // ORDER 2: International Customer (Canada)
        // -----------------------------------------------------------------
        Address address2 = new Address("322 Silver Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Isbelia Burnhams", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("27-inch Monitor", "MON27", 295.99, 1));
        order2.AddProduct(new Product("HDMI 2.1 Cable", "H21", 12.00, 2));

        // -----------------------------------------------------------------
        // DISPLAY RESULTS
        // -----------------------------------------------------------------
        List<Order> orders = new List<Order> { order1, order2 };
        int orderNum = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine($"==================================================");
            Console.WriteLine($"                    ORDER #{orderNum}                    ");
            Console.WriteLine($"==================================================");

            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
            Console.WriteLine();

            orderNum++;
        }
    }
}
