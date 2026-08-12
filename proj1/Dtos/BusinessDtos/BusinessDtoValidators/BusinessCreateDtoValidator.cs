using FluentValidation;

namespace proj1.Dtos.BusinessDtos.BusinessDtoValidators
{
    public class BusinessCreateDtoValidator : AbstractValidator<BusinessCreateDto>
    {
        public BusinessCreateDtoValidator()
        {
            RuleFor(x => x.CompName).NotEmpty().MaximumLength(100);
            // diğer property'lerine göre kural ekle
        }
    }
}
