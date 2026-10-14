namespace WestcoastEducation;

public class Teacher : Person
{
    public string KnowledgeArea { get; set; } = "";

    // aggregation.. listan pekar på kurser som även finns utanför läraren...
    public List<Course> ResponsibleCourses { get; } = new List<Course>();

    public void AddCourse(Course course)
    {
        // contains kontroll för kursobjekt i lista...
        if (ResponsibleCourses.Contains(course))
        {
            Console.WriteLine("Läraren ansvarar redan för kursen.");
            return;
        }
        ResponsibleCourses.Add(course);
        Console.WriteLine("Kursen har kopplats till personen.");
    }
    // beskriver lärare med uppgifter, kunskapsområde och ansvariga kurser...
    public override string ToString()
    {
        string courses = "";
        foreach (Course course in ResponsibleCourses)
        {
            courses += course.CourseNumber + " ";
        }
        return $"{base.ToString()} | Kunskapsområde: {KnowledgeArea} | Ansvariga kurser: {courses}";
    }
}
