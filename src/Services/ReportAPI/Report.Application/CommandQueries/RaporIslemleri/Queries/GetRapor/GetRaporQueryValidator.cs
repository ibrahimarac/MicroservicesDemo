using FluentValidation;

namespace Report.Application.CommandQueries.RaporIslemleri.Queries.GetRapor
{
    public class GetRaporQueryValidator : AbstractValidator<GetRaporQuery>
    {
        public GetRaporQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Rapor kimlik numarası boş bırakılamaz.");
        }
    }

}
