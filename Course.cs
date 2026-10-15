namespace WestcoastEducation;
public class Course
{
    public string CourseNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsDistance { get; set; }

    // listan o kurs skickas in till metoden..
    public static void AddCourse(List<Course> courses, Course course)
    {
        if (course.EndDate < course.StartDate)
        {
            Console.WriteLine("Slutdatum får inte vara före startdatum.");
            return; // avsluta metoden utan att lägga till kursen...
        }
        courses.Add(course);
    }

    public static void ListCourses(List<Course> courses)
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("Inga kurser finns ännu.");
        }

        // foreach går igenom listan....
        foreach (Course course in courses)
        {
            Console.WriteLine(course);
        }
    }

    // hur kursen visas i text...
    public override string ToString()
    {
        string format = "Klassrum";
        if (IsDistance)
        {
            format = "Distans";
        }
        // +1 för att start/slutdagen ska räknas med...
        int days = EndDate.DayNumber - StartDate.DayNumber + 1;
        return $"{CourseNumber}: {Title}, {format}, {days} kalenderdagar, " + $"{StartDate:yyyy-MM-dd} till {EndDate:yyyy-MM-dd}";
    }
}