using System;

public class Product
{
    // private fields
    private string _name;
    private string _productId;
    private decimal _pricePerUnit;
    private int _quantity;

    // constructor
    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    // getters/setters
    public string Name { get => _name; set => _name = value; }
    public string ProductId { get => _productId; set => _productId = value; }
    public decimal PricePerUnit { get => _pricePerUnit; set => _pricePerUnit = value; }
    public int Quantity { get => _quantity; set => _quantity = value; }

    // total cost for this product (price * qty)
    public decimal GetTotalCost() => _pricePerUnit * _quantity;
}
