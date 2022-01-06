using FluentValidation;

namespace Contact.Application.CommandsQueries.Queries.GetKisiDetay
{
    public class KisiDetayQueryValidator : AbstractValidator<KisiDetayQuery>
    {
        public KisiDetayQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Kimlik bilgisi boş bırakılamaz.");
        }
    }
}
