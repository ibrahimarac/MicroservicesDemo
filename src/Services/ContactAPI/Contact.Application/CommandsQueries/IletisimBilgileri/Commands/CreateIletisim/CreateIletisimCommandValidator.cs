
using FluentValidation;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Commands.CreateIletisim
{
    public class CreateIletisimCommandValidator:AbstractValidator<CreateIletisimCommand>
    {
        public CreateIletisimCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Geçerli bir eposta adresi girilmedi.")
                .MaximumLength(150).WithMessage("Eposta adresi en fazla 150 karakter olabilir.");

            RuleFor(p => p.Konum)
                .MaximumLength(30).WithMessage("Konum bilgisi en fazla 30 karakter olabilir.");

            RuleFor(p => p.Telefon)
                .MaximumLength(14).WithMessage("Telefon numarası en fazla 14 karakter olabilir.");

        }
    }
}
