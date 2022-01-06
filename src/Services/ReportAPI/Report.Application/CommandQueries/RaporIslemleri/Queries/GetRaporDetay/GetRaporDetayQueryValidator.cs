using FluentValidation;

namespace Report.Application.CommandQueries.RaporIslemleri.Queries.GetRaporDetay
{
    public class GetRaporDetayQueryValidator : AbstractValidator<GetRaporDetayQuery>
    {
        public GetRaporDetayQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Rapor kimlik numarası boş bırakılamaz.");
        }
    }

}
