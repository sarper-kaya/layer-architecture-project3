using FluentValidation;

namespace proj1.Dtos.FamiliyDtos.FamilyDtoValidators
{
    public class FamilyCreateDtoValidator : AbstractValidator<FamilyCreateDto>
    {
        public FamilyCreateDtoValidator()
        {
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(100);
        }   
    
    }
}
