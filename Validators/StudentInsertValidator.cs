using FluentValidation;
using StudentsDbApp.DTO;

namespace StudentsDbApp.Validators
{
    public class StudentInsertValidator : AbstractValidator<StudentInsertDTO>
    {
        public StudentInsertValidator()
        {
            RuleFor(s => s.Firstname)
                .NotEmpty().WithMessage("Field 'firstname' can not be empty")
                .Length(2, 255).WithMessage("Field 'firstname' must be between 2-255 characters");
            RuleFor(s => s.Lastname)
                .NotEmpty().WithMessage("Field 'lastname' can not be empty")
                .Length(2, 255).WithMessage("Field 'lastname must be between 2-255 characters");
        }
    }
}
