using FluentValidation;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Manager.Validations
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEnderecoViewModel>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.Complemento).NotEmpty().NotNull().WithMessage("Endereço deve ser Informado");
            RuleFor(p => p.CodigoIbge).NotEmpty().NotNull().WithMessage("Codigo do IBGE deve ser Informado");


        }
    }
}
