namespace WestcoastEducation;

public class Program
{
    static void Main()
    {
        // Menyn upprepas...
        while (true)
        {
            Console.WriteLine("\n--- Westcoast Education ---");
            Console.WriteLine("0. Avsluta");

            switch (ReadText("Välj: "))
            {
                case "0": return;

                default: Console.WriteLine("Välj 0 för att avsluta."); 
                break;
            }

            Console.WriteLine("\nTryck Enter för att återgå till menyn.");
            Console.ReadLine();
        }
    }

    static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();
            if (text == null)
            {
                
                Environment.Exit(0);
                return "";
            }
            if (!string.IsNullOrWhiteSpace(text))
            {
                return text.Trim(); // ta bort mellanslag...
            }
            Console.WriteLine("Fältet får inte vara tomt.");
        }
    }

}
