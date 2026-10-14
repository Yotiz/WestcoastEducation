namespace WestcoastEducation;

public class Program
{
    static School school = new School();

    static void Main()
    {
        // menyn upprepas...
        while (true)
        {
            Console.WriteLine("\n--- Westcoast Education ---");
            Console.WriteLine("1. Lägg till kurs");
            Console.WriteLine("2. Lägg till lärare");
            Console.WriteLine("3. Lägg till studerande");
            Console.WriteLine("4. Lägg till handledare/utbildningsledare");
            Console.WriteLine("5. Lista kurser");
            Console.WriteLine("6. Lista studerande");
            Console.WriteLine("0. Avsluta");

            switch (ReadText("Välj: "))
            {
                case "1": AddCourse(); 
                break;

                case "2": AddPerson(new Teacher()); 
                break;

                case "3": AddPerson(new Student()); 
                break;

                case "4": AddPerson(new EducationLeader()); 
                break;

                case "5": Course.ListCourses(school.Courses); 
                break;

                case "6": ListStudents(); 
                break;

                case "0": 
                return;

                default: Console.WriteLine("Välj 1, 2, 3, 4, 5, 6 eller 0."); 
                break;
            }

            // paus innan meny...
            Console.WriteLine("\nTryck Enter för att återgå till menyn.");
            Console.ReadLine();
        }
    }

    // skapa och lägg till kurser...
    static void AddCourse()
    {
        Course course = new Course();
        course.CourseNumber = ReadText("Kursnummer: ");
        course.Title = ReadText("Titel: ");
        course.StartDate = ReadDate("Startdatum (ÅÅÅÅ-MM-DD): ");
        course.EndDate = ReadDate("Slutdatum (ÅÅÅÅ-MM-DD): ");

        while (course.EndDate < course.StartDate)
        {
            Console.WriteLine("Slutdatum får inte vara före startdatum.");
            course.EndDate = ReadDate("Slutdatum (ÅÅÅÅ-MM-DD): ");
        }

        course.IsDistance = ReadYesNo("Är kursen på distans? (j/n): ");
        Course.AddCourse(school.Courses, course);
        Console.WriteLine($"Kurs tillagd: {course}");
    }

    // lägg till person/student metod, kan återanvändas...
    static void AddPerson(Person person)
    {
        person.FirstName = ReadText("Förnamn: ");
        person.LastName = ReadText("Efternamn: ");
        person.Phone = ReadText("Telefon: ");
        person.PersonalNumber = ReadText("Personnummer: ");
        person.Address.Street = ReadText("Gatuadress: ");
        person.Address.PostalCode = ReadText("Postnummer: ");
        person.Address.City = ReadText("Ort: ");

        // is typ kontroll...
        if (person is Teacher teacher)
        {
            teacher.KnowledgeArea = ReadText("Kunskapsområde: ");
            AssignCourses(teacher);
        }
        // handledare? be dem att ange anställningsdatum...
        if (person is EducationLeader leader)
        {
            leader.EmploymentDate = ReadDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ");
        }

        school.People.Add(person);
        Console.WriteLine($"Person tillagd: {person}");
    }

    static void ListStudents()
    {
        bool foundStudent = false;
        foreach (Person person in school.People)
        {
            // visa endast studerande...
            if (person is Student)
            {
                Console.WriteLine(person);
                foundStudent = true;
            }
        }
        if (!foundStudent)
        {
            Console.WriteLine("Inga studerande finns ännu.");
        }
    }
    static void AssignCourses(Teacher teacher)
    {
        // kontroll för kursansvar...
        foreach (Course course in school.Courses)
        {
            Console.WriteLine(course);
            if (ReadYesNo("Ska personen ansvara för denna kurs? (j/n): "))
            {
                teacher.AddCourse(course);
            }
        }
    }

    // gemensamma metoder för inmatning...
    static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();
            if (text == null)
            {
                Environment.Exit(0); // avsluta...
                return "";
            }
            if (!string.IsNullOrWhiteSpace(text)) // kontroll efter tom text...
            {
                return text.Trim(); // ta bort mellanslag..
            }
            Console.WriteLine("Fältet får inte vara tomt.");
        }
    }

    // kontroll j/n...
    static bool ReadYesNo(string question)
    {
        while (true)
        {
            string answer = ReadText(question).ToLower();
            if (answer == "j")
            {
                return true;
            }
            if (answer == "n")
            {
                return false;
            }
            Console.WriteLine("Skriv j för ja eller n för nej.");
        }
    }

    static DateOnly ReadDate(string prompt)
    {
        while (true)
        {
            if (DateOnly.TryParseExact(ReadText(prompt), "yyyy-MM-dd", out DateOnly date))
            {
                return date;
            }
            Console.WriteLine("Skriv ett giltigt datum som ÅÅÅÅ-MM-DD.");
        }
    }
}