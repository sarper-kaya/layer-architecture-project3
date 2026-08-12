using FluentValidation;

namespace proj1.Dtos.RelationsDtos.RelationsDtoValidators
{
    public class RelationsUpdateDtoValidator : AbstractValidator<RelationsUpdateDto>
    {
        public RelationsUpdateDtoValidator()
        {
            RuleFor(x => x.Relation).NotEmpty();
        }
    }
}
