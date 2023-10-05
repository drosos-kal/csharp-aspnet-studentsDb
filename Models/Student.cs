namespace StudentsDbApp.Models
{
    /// <summary>
    /// POCO (Plain Old CLR Object)
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;

    }
}
