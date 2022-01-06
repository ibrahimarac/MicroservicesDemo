using FluentValidation;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Commands.UpdateRaporDurum
{
    public class UpdateRaporDurumCommandValidator:AbstractValidator<UpdateRaporDurumCommand>
    {
        public UpdateRaporDurumCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Rapor durumu kimlik numarası boş bırakılamaz.");

            RuleFor(v => v.Durum)
                .NotEmpty().WithMessage("Rapor durumu boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Rapor durum alanı en fazla 50 karakter olabilir.");
        }
    }
}
