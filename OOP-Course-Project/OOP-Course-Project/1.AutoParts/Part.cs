using System.Collections.Generic;
using System.Text;

public class Part
{
    private readonly double buyPrice;
    private readonly PartCategory category;
    private readonly string code;
    private readonly Manufacturer manufacturer;
    private readonly string name;
    private readonly double sellPrice;
    private readonly HashSet<Car> supportedCars;


    public Part(string name, double buyPrice, double sellPrice,
        Manufacturer manufacturer, string code,
        PartCategory category)
    {
        this.name = name;
        this.buyPrice = buyPrice;
        this.sellPrice = sellPrice;
        this.manufacturer = manufacturer;
        this.code = code;
        this.category = category;
        this.supportedCars = new HashSet<Car>();
    }


    public void AddSupportedCar(Car car)
    {
        this.supportedCars.Add(car);
    }


    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("Part: " + this.name + "\n");
        result.Append("-code: " + this.code + "\n");
        result.Append("-category: " + this.category + "\n");
        result.Append("-buyPrice: " + this.buyPrice + "\n");
        result.Append("-sellPrice: " + this.sellPrice + "\n");
        result.Append("-manufacturer: " +
                      this.manufacturer + "\n");
        result.Append("---Supported cars---" + "\n");
        foreach (var car in this.supportedCars)
        {
            result.Append(car);
            result.Append("\n");
        }
        result.Append("----------------------\n");
        return result.ToString();
    }
}