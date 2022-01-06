using FluentValidation;

namespace Report.Application.CommandQueries.RaporIslemleri.Queries.RaporTalep
{
    public class RaporTalepQueryValidator:AbstractValidator<RaporTalepQuery>
    {
        public RaporTalepQueryValidator()
        {
            RuleFor(v => v.Konum)
                .NotEmpty().WithMessage("Konum bilgisi zorunlu bir alandır.");
        }
    }
}
