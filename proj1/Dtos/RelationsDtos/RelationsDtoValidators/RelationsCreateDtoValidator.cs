using FluentValidation;

namespace proj1.Dtos.RelationsDtos.RelationsDtoValidators
{
    public class RelationsCreateDtoValidator :AbstractValidator<RelationsCreateDto>
    {
        public RelationsCreateDtoValidator()
        {
            RuleFor(x => x.Relation).NotEmpty();
        }
    }
}
