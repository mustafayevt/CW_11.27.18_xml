using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
class Program
{
    public static void Main(string[] args)
    {
        List<Product> product = new List<Product>();
        var xmlSerializer = new XmlSerializer(typeof(List<Product>));
        if (!File.Exists("Product.xml"))
        {
            product.Add(new Product("PS4", 500, 5));
            product.Add(new Product("XboxOne", 600, 3));
            FileStream file = new FileStream("Product.xml", FileMode.OpenOrCreate);
            xmlSerializer.Serialize(file, product);
            file.Close();
        }
        else
        {
            FileStream file = new FileStream("Product.xml", FileMode.Open);
            product = xmlSerializer.Deserialize(file) as List<Product>;
            file.Close();
        }
        foreach (var item in product)
        {
            if (Console.ReadLine() == item.name) if (item.quantity - Convert.ToInt32(Console.ReadLine()) >= 0) item.quantity -= Convert.ToInt32(Console.ReadLine());
                else Console.WriteLine($"Not Enough {item.name}");
        }
        FileStream file1 = new FileStream("Product.xml", FileMode.Open);
        xmlSerializer.Serialize(file1, product);
    }
}
public class Product
{
    public Product() { }
    public Product(string name, decimal price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
    public string name { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
}