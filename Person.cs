namespace WestcoastEducation;

public class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PersonalNumber { get; set; } = string.Empty;

    // komposition.. person skapar och äger sin egen adress..
    public Address Address { get; } = new Address();
    public override string ToString()
    {
        return $"{FirstName} {LastName} | Telefon: {Phone} | " +
               $"Personnummer: {PersonalNumber} | {Address}";
    }
}
