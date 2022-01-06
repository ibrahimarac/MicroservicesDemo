
using FluentValidation;

namespace Contact.Application.CommandsQueries.Kisiler.Commands.UpdateKisi
{
    public class UpdateKisiCommandValidator : AbstractValidator<UpdateKisiCommand>
    {
        public UpdateKisiCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id bilgisi gönderilmelidir.");

            RuleFor(v => v.Ad)
                .MaximumLength(30).WithMessage("Ad alanı en fazla 30 karakter olabilir.")
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.");

            RuleFor(v => v.Soyad)
                .MaximumLength(30).WithMessage("Soyad alanı en fazla 30 karakter olabilir.")
                .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.");

            RuleFor(v => v.Firma)
                .MaximumLength(30).WithMessage("Firma alanı en fazla 100 karakter olabilir.")
                .NotEmpty().WithMessage("Firma alanı boş bırakılamaz.");
        }
    }
}
