using FluentValidation;

namespace Contact.Application.CommandsQueries.Queries.GetKisiDetay
{
    public class GetKisilerCommandValidator : AbstractValidator<KisiDetayQuery>
    {
        public GetKisilerCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Kimlik bilgisi boş bırakılamaz.");
        }
    }
}
