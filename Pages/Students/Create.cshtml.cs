using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsDbApp.DTO;
using StudentsDbApp.Models;
using StudentsDbApp.Services;

namespace StudentsDbApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        public List<Error> ErrorArray { get; set; } = new();
        public StudentInsertDTO StudentInsertDto { get; set; } = new();

        private readonly IStudentService? _studentService;
        private readonly IValidator<StudentInsertDTO> _StudentInsertvalidator;

        public CreateModel(IStudentService? studentService, IValidator<StudentInsertDTO> studentInsertvalidator)
        {
            _studentService = studentService;
            _StudentInsertvalidator = studentInsertvalidator;
        }

        public void OnGet()
        {

        }

        public void OnPost(StudentInsertDTO dto)
        {
            // When Submit clicked and page refreshes the text-box
            // retain the old values through StudentInsertDto
            StudentInsertDto = dto;

            var validationResult = _StudentInsertvalidator.Validate(dto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors) 
                {
                    ErrorArray!.Add(new Error(error.ErrorCode, error.ErrorMessage, error.PropertyName));
                }
                return;
            }

            try
            {
                Student student = _studentService?.InsertStudent(dto)!;
                Response.Redirect("/Students/getall");
            } catch (Exception ex)
            {
                ErrorArray!.Add(new Error("", ex.Message, ""));
            }
        }
    }
}
