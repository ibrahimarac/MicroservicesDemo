using FluentValidation;

namespace Contact.Application.CommandsQueries.RaporTalep.Queries
{
    public class RaporTalepQueryValidator : AbstractValidator<RaporTalepQuery>
    {
        public RaporTalepQueryValidator()
        {
            RuleFor(p => p.Konum)
                .NotEmpty().WithMessage("Konum bilgisi boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Konum bilgisi en fazla 30 karakter olabilir.");
        }
    }
}
