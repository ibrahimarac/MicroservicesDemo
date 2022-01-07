using FluentValidation;

namespace Contact.Application.CommandsQueries.RaporTalep.Commands
{
    public class RaporTalepCommandValidator : AbstractValidator<RaporTalepCommand>
    {
        public RaporTalepCommandValidator()
        {
            RuleFor(p => p.Konum)
                .NotEmpty().WithMessage("Konum bilgisi boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Konum bilgisi en fazla 30 karakter olabilir.");
        }
    }
}
