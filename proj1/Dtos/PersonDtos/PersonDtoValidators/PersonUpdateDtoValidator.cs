using FluentValidation;

namespace proj1.Dtos.PersonDtos.PersonDtoValidators
{
    public class PersonUpdateDtoValidator : AbstractValidator<PersonUpdateDto>
    {
        public PersonUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Age).GreaterThan(0).LessThan(150);
        }
    }
}
