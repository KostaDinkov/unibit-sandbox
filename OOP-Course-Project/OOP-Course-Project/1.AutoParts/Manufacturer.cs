public class Manufacturer
{
    private readonly string address;
    private readonly string country;
    private readonly string fax;
    private readonly string name;
    private readonly string phoneNumber;

    public Manufacturer(string name, string country,
        string address, string phoneNumber, string fax)
    {
        this.name = name;
        this.country = country;
        this.address = address;
        this.phoneNumber = phoneNumber;
        this.fax = fax;
    }


    public override string ToString()
    {
        return this.name + " <" + this.country + "," + this.address
               + "," + this.phoneNumber + "," + this.fax + ">";
    }
}