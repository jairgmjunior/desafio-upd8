using FluentValidation;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Manager.Validations
{
    public class AtualizaClienteValidator : AbstractValidator<AtualizaClienteViewModel>
    {
        public AtualizaClienteValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NovoClienteValidator());
        }
    }
}
