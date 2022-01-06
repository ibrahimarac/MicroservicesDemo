
using FluentValidation;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Queries.GetIletisimByKonum
{
    public class CreateIletisimCommandValidator:AbstractValidator<GetRaporByKonumQuery>
    {
        public CreateIletisimCommandValidator()
        {
            RuleFor(p => p.Konum)
                .NotEmpty().WithMessage("Konum bilgisi boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Konum bilgisi en fazla 30 karakter olabilir.");
        }
    }
}
