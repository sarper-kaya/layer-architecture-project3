using FluentValidation;

namespace proj1.Dtos.PersonDtos.PersonDtoValidators
{
    public class PersonCreateDtoValidator : AbstractValidator<PersonCreateDto>
    {
        public PersonCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Age).GreaterThan(0).LessThan(150);
            RuleFor(x => x.FamilyId).GreaterThan(0);
        }
    }
}
