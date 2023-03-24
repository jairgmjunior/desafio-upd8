namespace Upd8.Core.Shared.ViewModels
{
    public class NovoEnderecoViewModel
    {
        /// <summary>
        /// Descrição do Endereço do Cliente
        /// </summary>
        /// <example>Rua 9 de julho</example>
        public string Complemento { get; set; }
        /// <summary>
        /// Codigo do IBGE da Cidade
        /// </summary>
        /// <example>5101407</example>
        public string CodigoIbge { get; set; }
    }
}
