
using FluentValidation;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Commands.DeleteIletisim
{
    public class DeleteIletisimCommandValidator : AbstractValidator<DeleteIletisimCommand>
    {
        public DeleteIletisimCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Silinecek kaydın kimlik değeri gönderilmelidir.");

        }
    }
}
