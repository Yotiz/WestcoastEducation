namespace WestcoastEducation;

public class Person
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string PersonalNumber { get; set; } = "";

    // komposition.. person skapar och äger sin egen adress..
    public Address Address { get; } = new Address();
    public override string ToString()
    {
        return $"{FirstName} {LastName} | Telefon: {Phone} | " +
               $"Personnummer: {PersonalNumber} | {Address}";
    }
}
