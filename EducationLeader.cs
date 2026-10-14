namespace WestcoastEducation;

// ärver från lärare + anställningsdatum...
public class EducationLeader : Teacher
{
    public DateOnly EmploymentDate { get; set; }
    public override string ToString()
    {
        return $"{base.ToString()} | Anställd: {EmploymentDate:yyyy-MM-dd}";
    }
}
