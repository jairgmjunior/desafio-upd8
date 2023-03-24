using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Upd8.Web.Helpers;
using Upd8.Web.Models;

namespace Upd8.Web.Dtos
{
    public class ResponseClienteDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string CPF { get; init; }
        [Display(Name = "Nacimento")]
        public DateTime DataNascimento { get; init; }
        public char Sexo { get; init; }
        public DateTime DataCriacao { get; init; }
        public DateTime? DataAtualizacao { get; init; }

        public ResponseEnderecoDto Endereco { get; init; }

        
    }
}
