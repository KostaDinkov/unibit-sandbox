using System;

public class TestShop

{
    public static void Main()

    {
        var bmw = new Manufacturer("BWM",
            "Germany", "Bavaria", "665544", "876666");

        var lada = new Manufacturer("Lada",
            "Russia", "Moscow", "653443", "893321");

        var bmw316i = new Car("BMW", "316i", 1994);

        var ladaSamara = new Car("Lada", "Samara", 1987);

        var mazdaMX5 = new Car("Mazda", "MX5", 1999);

        var mercedesC500 = new Car("Mercedes", "C500", 2008);

        var trabant = new Car("Trabant", "super", 1966);

        var opelAstra = new Car("Opel", "Astra", 1997);

        var cheapPart = new Part("Tires 165/50/13", 302.36,
            345.58, lada, "T332", PartCategory.Tires);

        cheapPart.AddSupportedCar(ladaSamara);
        cheapPart.AddSupportedCar(trabant);
        var expensivePart = new Part("BMW Engine Oil",
            633.17, 670.0, bmw, "Oil431", PartCategory.Engine);

        expensivePart.AddSupportedCar(bmw316i);
        expensivePart.AddSupportedCar(mazdaMX5);
        expensivePart.AddSupportedCar(mercedesC500);
        expensivePart.AddSupportedCar(opelAstra);

        var newShop = new Shop("Tunning shop");

        newShop.AddPart(cheapPart);
        newShop.AddPart(expensivePart);
        Console.WriteLine(newShop);
    }
}