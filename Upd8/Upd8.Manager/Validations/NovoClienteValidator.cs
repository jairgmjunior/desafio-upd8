using FluentValidation;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Manager.Validations
{
    public class NovoClienteValidator : AbstractValidator<NovoClienteViewModel>
    {
        public NovoClienteValidator()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().MinimumLength(6).MaximumLength(100);
            RuleFor(p => p.CPF).NotNull().NotEmpty().Length(11).WithMessage("O CPF deve conter apenas 11 caracteres numéricos");
            RuleFor(p => p.DataNascimento).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddYears(-120));
            RuleFor(p => p.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
            RuleFor(p => p.Endereco).NotEmpty().NotNull().SetValidator(new NovoEnderecoValidator()).WithMessage("Endereço deve ser informado");
        }

        private bool IsMorF(char gender)
        {
            return gender == 'M' || gender == 'F';
        }
    }

}
