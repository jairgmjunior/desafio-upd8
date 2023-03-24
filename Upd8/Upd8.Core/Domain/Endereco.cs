using Upd8.Core.Enums;

namespace Upd8.Core.Domain
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
