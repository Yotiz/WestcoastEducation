namespace WestcoastEducation;

public class Address
{
    public string Street { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";
    public override string ToString()
    {
        return $"{Street}, {PostalCode} {City}";
    }
}
