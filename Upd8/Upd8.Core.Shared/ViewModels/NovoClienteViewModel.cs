
namespace Upd8.Core.Shared.ViewModels
{
    /// <summary>
    /// Objeto utilizado para inclusão de um novo cliente
    /// </summary>
    public class NovoClienteViewModel
    {
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        /// <example>João da Silva e Silva</example>
        public string Nome { get; set; }
        /// <summary>
        /// CPF do Cliente (Apenas Número)
        /// </summary>
        /// <example>78457889746</example>
        public string CPF { get; set; }
        /// <summary>
        /// Data de Nascimento do cliente
        /// </summary>
        /// <example>1991-12-31</example>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Sexo do Cliente (M or F)
        /// </summary>
        /// <example>M</example>
        public char Sexo { get; set; }
        
        public NovoEnderecoViewModel Endereco { get; set; }

    }    
}
