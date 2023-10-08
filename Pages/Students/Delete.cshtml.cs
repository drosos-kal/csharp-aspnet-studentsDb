using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsDbApp.Models;
using StudentsDbApp.Services;

namespace StudentsDbApp.Pages.Students
{
    public class DeleteModel : PageModel
    {

        private readonly IStudentService? _studentService;
        public List<Error> ErrorArray { get; set; } = new();

        public DeleteModel(IStudentService? studentService)
        {
            _studentService = studentService;
        }

        public void OnGet(int id)
        {
            try
            {
                Student? student = _studentService?.DeleteStudent(id);
                Response.Redirect("/Students/getall");
            } catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
            }
        }
    }
}
