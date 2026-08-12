using FluentValidation;

namespace proj1.Dtos.BusinessDtos.BusinessDtoValidators
{
    public class BusinessUpdateDtoValidator : AbstractValidator<BusinessUpdateDto>
    {
        public BusinessUpdateDtoValidator()
        {
            RuleFor(x => x.CompName).NotEmpty().MaximumLength(100);
        }
    }
}
