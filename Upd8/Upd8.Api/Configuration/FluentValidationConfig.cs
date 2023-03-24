using FluentValidation.AspNetCore;
using FluentValidation;
using System.Globalization;
using Upd8.Manager.Validations;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfig(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            services.AddTransient<IValidator<NovoClienteViewModel>, NovoClienteValidator>();
            services.AddTransient<IValidator<NovoEnderecoViewModel>, NovoEnderecoValidator>();
            services.AddTransient<IValidator<AtualizaClienteViewModel>, AtualizaClienteValidator>();
        }
    }
}
