using StudentsDbApp.DTO;
using StudentsDbApp.Models;

namespace StudentsDbApp.Services
{
    public interface IStudentService
    {
        IList<Student> GetAllStudents();
        Student? GetStudent(int id);
        Student? InsertStudent(StudentInsertDTO dto);
        Student? UpdateStudent(StudentUpdateDTO dto);
        Student? DeleteStudent(int id);
    }
}
