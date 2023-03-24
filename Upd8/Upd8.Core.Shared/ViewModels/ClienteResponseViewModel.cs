using Upd8.Core.Domain;

namespace Upd8.Core.Shared.ViewModels
{
    public class ClienteResponseViewModel : ICloneable
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public char Sexo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        public EnderecoResponseViewModel Endereco { get; private set; }


        public static ClienteResponseViewModel ToMapResponse(Cliente cliente)
        {
            if(cliente == null) return null;

            return new ClienteResponseViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                DataCriacao = cliente.DataCriacao,
                DataAtualizacao = cliente.DataAtualizacao,
                Endereco = new EnderecoResponseViewModel(
                    cliente.Endereco.Complemento, 
                    cliente.Endereco.Cidade.CodigoIbge, 
                    cliente.Endereco.Cidade.Nome,
                    cliente.Endereco.Cidade.Estado
                    )
            };
        }

        public object Clone()
        {
            var cliente = (ClienteResponseViewModel)MemberwiseClone();
            cliente.Endereco = (EnderecoResponseViewModel)cliente.Endereco.Clone();
            return cliente;
        }

        public ClienteResponseViewModel CloneTipado()
        {
            return (ClienteResponseViewModel)Clone();
        }
    }
}
