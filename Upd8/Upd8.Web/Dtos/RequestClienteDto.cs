namespace Upd8.Web.Dtos
{
    public class RequestClienteDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }

        public RequestEnderecoDto Endereco { get; set; }
    }
}
