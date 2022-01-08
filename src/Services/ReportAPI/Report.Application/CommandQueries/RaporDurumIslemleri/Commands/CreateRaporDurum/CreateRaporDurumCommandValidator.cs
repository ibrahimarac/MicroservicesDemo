using FluentValidation;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum
{
    public class CreateRaporDurumCommandValidator:AbstractValidator<CreateRaporDurumCommand>
    {
        public CreateRaporDurumCommandValidator()
        {
            RuleFor(v => v.Durum.RaporDurum)
                .NotEmpty().WithMessage("Rapor durumu boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Rapor durum alanı en fazla 50 karakter olabilir.");
        }
    }
}
