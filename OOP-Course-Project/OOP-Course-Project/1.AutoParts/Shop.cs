using System.Collections.Generic;
using System.Text;

public class Shop

{
    private readonly string name;
    private readonly List<Part> parts;


    public Shop(string name)
    {
        this.name = name;
        this.parts = new List<Part>();
    }


    public void AddPart(Part part)
    {
        this.parts.Add(part);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("Shop: " + this.name + "\n\n");

        foreach (var part in this.parts)
        {
            result.Append(part);

            result.Append("\n");
        }

        return result.ToString();
    }
}