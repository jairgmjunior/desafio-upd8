using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Upd8.Web.Dtos;
using Upd8.Web.Enums;
using Upd8.Web.Helpers;

namespace Upd8.Web.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [MinLength(7)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nacimento")]
        public string DataNascimento { get; set; }
        public bool IsMasculino { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Complemento { get; set; }

        [Display(Name = "Cidade")]
        public string CodigoIbge { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        public EEStado Estado { get; set; }

        public static ClienteViewModel Bind(ResponseClienteDto dto)
        {
            return new ClienteViewModel
            {
                Id = dto.Id,
                Nome = dto.Nome,
                CPF = Convert.ToUInt64(dto.CPF).ToString(@"000\.000\.000\-00"),
                IsMasculino = dto.Sexo.ToString().ToUpper().Equals("M") ? true : false,
                DataNascimento = dto.DataNascimento.ToShortDateString(),
                Complemento = dto.Endereco.Complemento,
                CodigoIbge = dto.Endereco.CodigoIbge,
                Estado = Enum.Parse<EEStado>(dto.Endereco.Estado)
            };
        }

        public static RequestClienteDto Bind(ClienteViewModel viewModel)
        {
            return new RequestClienteDto
            {
                Nome = viewModel.Nome,
                CPF = viewModel.CPF.Clear(),
                DataNascimento = Convert.ToDateTime(viewModel.DataNascimento),
                Sexo = viewModel.IsMasculino ? 'M' : 'F',
                Endereco = new RequestEnderecoDto
                {
                    Complemento = viewModel.Complemento,
                    CodigoIbge = viewModel.CodigoIbge
                }
            };
        }

        public static RequestUpdateClienteDto BindUpdate(ClienteViewModel viewModel)
        {
            return new RequestUpdateClienteDto
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                CPF = viewModel.CPF.Clear(),
                DataNascimento = Convert.ToDateTime(viewModel.DataNascimento),
                Sexo = viewModel.IsMasculino ? 'M' : 'F',
                Endereco = new RequestEnderecoDto
                {
                    Complemento = viewModel.Complemento,
                    CodigoIbge = viewModel.CodigoIbge
                }
            };
        }
    }
}
