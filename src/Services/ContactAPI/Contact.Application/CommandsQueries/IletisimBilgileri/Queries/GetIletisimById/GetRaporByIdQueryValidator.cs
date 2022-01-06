
using FluentValidation;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Queries.GetIletisimById
{
    public class GetRaporByIdQueryValidator : AbstractValidator<GetRaporByIdQuery>
    {
        public GetRaporByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Kimlik bilgisi boş bırakılamaz.");
        }
    }
}
