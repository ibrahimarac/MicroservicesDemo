
using FluentValidation;

namespace Report.Application.CommandQueries.RaporIslemleri.Commands.UpdateRapor
{
    public class UpdateRaporCommandValidator:AbstractValidator<UpdateRaporCommand>
    {
        public UpdateRaporCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Rapor kimlik numarası gerekli bir alandır.");

            RuleFor(v => v.DurumId)
                .NotEmpty().WithMessage("Rapor durumu gerekli bir alandır.");
        }
    }
}
