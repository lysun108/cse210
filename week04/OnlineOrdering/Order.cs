using System;
using System.Text;
using System.Collections.Generic;

public class Order
{
    private readonly List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product p) => _products.Add(p);

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        foreach (var p in _products)
        {
            sb.AppendLine($"{p.Name}  (ID: {p.ProductId})");
        }
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.GetFormatted()}";
    }

    public decimal GetTotalPrice()
    {
        decimal subtotal = 0m;
        foreach (var p in _products)
        {
            subtotal += p.GetTotalCost();
        }
        decimal shipping = _customer.IsInUSA() ? 5m : 35m;
        return subtotal + shipping;
    }
}
