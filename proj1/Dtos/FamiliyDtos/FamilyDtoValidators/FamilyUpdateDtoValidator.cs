using FluentValidation;

namespace proj1.Dtos.FamiliyDtos.FamilyDtoValidators
{
    public class FamilyUpdateDtoValidator : AbstractValidator<FamilyUpdateDto>
    {
        public FamilyUpdateDtoValidator()
        {
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(100);
        }

    }
}
