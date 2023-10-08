using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsDbApp.DTO;
using StudentsDbApp.Models;
using StudentsDbApp.Services;

namespace StudentsDbApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        public Error? ErrorObj { get; set; }
        public IList<StudentReadOnlyDTO> StudentsDto { get; set; } = null!;

        private readonly IStudentService? _studentService;
        private readonly IMapper? _mapper;

        public IndexModel(IStudentService? studentService, IMapper? mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            try
            {
                ErrorObj = null;
                IList<Student> students = _studentService!.GetAllStudents();
                StudentsDto = new List<StudentReadOnlyDTO>();
                foreach (Student student in students)
                {
                    StudentReadOnlyDTO? studentDto = _mapper!.Map<StudentReadOnlyDTO>(student);
                    StudentsDto.Add(studentDto);
                }
            } catch (Exception ex)
            {
                ErrorObj = new Error("", ex.Message, "");
            }
            return Page();
        }
    }
}
