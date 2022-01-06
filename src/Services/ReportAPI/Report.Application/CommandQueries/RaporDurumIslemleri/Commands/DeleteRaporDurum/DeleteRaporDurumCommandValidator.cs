using FluentValidation;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Commands.DeleteRaporDurum
{
    public class DeleteRaporDurumCommandValidator:AbstractValidator<DeleteRaporDurumCommand>
    {
        public DeleteRaporDurumCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Rapor durumu kimlik numarası boş bırakılamaz.");
        }
    }
}
