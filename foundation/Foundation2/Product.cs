using System;

public class Product
{
    private string _name;
    private int _productId;
    private decimal _price;
    private int _quantity;

    public Product()
    {
        _name = "";
        _productId = 0;
        _price = 0;
        _quantity = 0;
    }

    public Product(decimal price)
    {
        _name = "";
        _productId = 0;
        _price = price;
        _quantity = 0;
    }

    public Product(string name, int productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductInfo()
    {
        return $"{_name} (ID: {_productId})";
    }
}
