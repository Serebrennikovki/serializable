using System.Diagnostics;
using OTUS.Serializable;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var product = new Product
        {
            i3 = 2,
            i2 = 10,
            Id = 1,
            Name = "Laptop",
            Price = 999.99m
        };
        var result = string.Empty;
        var sw = new Stopwatch(); 
        sw.Start();
        int i = 0;
        while (i < 100000)
        {
            result = new SerializableClass().SerializeObjectToString(product);
            i++;
        }
        sw.Stop();
        Console.WriteLine($"ResultSerializableTime= {sw.ElapsedMilliseconds}");
        sw.Reset();
        sw.Start();
        Console.WriteLine(result);
        Console.WriteLine($"ResultWriteLineTime= {sw.ElapsedMilliseconds}");
        sw.Stop();
        sw.Reset();
        sw.Start();
        var resultSystemTextJson = string.Empty;
        while (i > 0)
        {
            resultSystemTextJson = JsonSerializer.Serialize(product);
            i--;
        }
        sw.Stop();
        Console.WriteLine(resultSystemTextJson);
        Console.WriteLine($"ResultSerializableJSONTime= {sw.ElapsedMilliseconds}");
    }
    
    
}


public class Product
{
    public int i1, i2, i3;
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}