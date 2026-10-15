namespace WestcoastEducation;

public class Address
{
    // string.Empty istället för ""...
    public string Street { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"{Street}, {PostalCode} {City}";
    }
}
