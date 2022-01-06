using FluentValidation;

namespace Contact.Application.CommandsQueries.Kisiler.Commands.DeleteKisi
{
    public class DeleteKisiCommandValidator : AbstractValidator<DeleteKisiCommand>
    {
        public DeleteKisiCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Kimlik bilgisi boş bırakılamaz.");
        }
    }
}
