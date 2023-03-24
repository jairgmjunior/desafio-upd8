using Upd8.Web.Enums;

namespace Upd8.Web.Dtos
{
    public class ResponseEnderecoDto
    {
        public string? Complemento { get; init; }
        public string? CodigoIbge { get; init; }
        public string? NomeCidade { get; init; }
        public string? Estado { get; init; }
    }
}
